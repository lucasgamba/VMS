# FindDuplicates.ps1
# Usage: run from solution root in PowerShell (close Visual studio first)
$root = Get-Location
$targets = @(
    "Frm_00_01_Landing",
    "Frm_02_00_LandingResto",
    "Mesas_exemplo"
)

Write-Host "Searching for class and member declarations for: $($targets -join ', ')`n"

foreach ($t in $targets) {
    Write-Host "=== Matches for '$t' ===`n"
    $patternClass = "Class\s+$t\b"
    $patternPartial = "Partial\s+Class\s+$t\b"
    $patternNew = "Public\s+Sub\s+New\("
    $patternInit = "InitializeComponent\("
    $patternHandlers = "Private\s+Sub\s+(.*)\("

    $files = Get-ChildItem -Recurse -Include *.vb -File | Where-Object {
        Select-String -Path $_.FullName -Pattern $patternClass,$patternPartial,$patternNew,$patternInit -Quiet
    }

    if ($files.Count -eq 0) {
        Write-Host "No files found mentioning $t"
        continue
    }

    foreach ($f in $files) {
        Write-Host "`n--- $($f.FullName) ---"
        Select-String -Path $f.FullName -Pattern $patternClass,$patternPartial,$patternNew,$patternInit -Context 0,2 | ForEach-Object {
            Write-Host "Line $($_.LineNumber): $($_.Line.Trim())"
            if ($_.Context.PostContext) { $_.Context.PostContext | ForEach-Object { Write-Host "  > " $_ } }
        }
    }
    Write-Host "`n"
}

# Also search for duplicate DesignerGenerated attributes or 'components' declarations
Write-Host "=== Global checks ===`n"
Get-ChildItem -Recurse -Include *.vb -File | ForEach-Object {
    $path = $_.FullName
    $text = Get-Content $path -Raw
    if ($text -match "DesignerGenerated") {
        Write-Host "DesignerGenerated in: $path"
    }
    if ($text -match "Private\s+components\s+As\s+System\.ComponentModel\.IContainer" -or $text -match "Private\s+components\s+As\s+IContainer") {
        Write-Host "components declared in: $path"
    }
}