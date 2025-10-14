Param(
    [string]$SolutionPath = ".",
    [string]$From = "Frm_02_00_LandingResto",
    [string]$To = "Mesas_exemplo"
)

# Confirm
Write-Host "This will replace '$From' -> '$To' in text files under $SolutionPath"
Write-Host "Make sure Visual Studio is closed and you have a backup or git commit."
if (-not (Read-Host "Type YES to continue") -eq "YES") { Write-Host "Aborted"; exit }

$backupDir = Join-Path $SolutionPath "replace_backup_$(Get-Date -Format 'yyyyMMdd_HHmmss')"
New-Item -ItemType Directory -Path $backupDir | Out-Null

$patterns = @("*.vb","*.resx","*.sln","*.config","*.vbproj","*.csproj","*.xml","*.xaml")
$files = Get-ChildItem -Path $SolutionPath -Recurse -Include $patterns -File -ErrorAction SilentlyContinue

foreach ($file in $files) {
    try {
        $text = Get-Content -Raw -LiteralPath $file.FullName -ErrorAction Stop
    } catch {
        Write-Host "Skipping (binary or locked): $($file.FullName)"
        continue
    }

    if ($text -like "*$From*") {
        # Backup original
        $rel = $file.FullName.Substring((Get-Item $SolutionPath).FullName.Length).TrimStart("\/")
        $bkPath = Join-Path $backupDir $rel
        $bkDir = Split-Path $bkPath -Parent
        if (-not (Test-Path $bkDir)) { New-Item -ItemType Directory -Path $bkDir | Out-Null }
        Copy-Item -LiteralPath $file.FullName -Destination $bkPath -Force

        # Replace
        $newText = $text -replace [regex]::Escape($From), $To
        Set-Content -LiteralPath $file.FullName -Value $newText -Encoding UTF8
        Write-Host "Updated: $($file.FullName)"
    }
}

Write-Host ""
Write-Host "Done. Backups stored in: $backupDir"
Write-Host "Open solution in Visual Studio and rebuild. If something is wrong, restore files from the backup folder."