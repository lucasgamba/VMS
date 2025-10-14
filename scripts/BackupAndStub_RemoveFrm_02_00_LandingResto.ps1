# Moves Frm_02_00_LandingResto.vb to a backup folder and writes a minimal safe stub.
$projectRoot = (Get-Location).Path
$orig = Join-Path $projectRoot "Frm_02_00_LandingResto.vb"
$backupDir = Join-Path $projectRoot ("backup_before_delete_" + (Get-Date -Format "yyyyMMdd_HHmmss"))
New-Item -ItemType Directory -Path $backupDir | Out-Null

if (Test-Path $orig) {
    Copy-Item -LiteralPath $orig -Destination (Join-Path $backupDir "Frm_02_00_LandingResto.vb") -Force
    Remove-Item -LiteralPath $orig -Force
    Write-Host "Backed up and removed original: $orig -> $backupDir"
} else {
    Write-Host "Original file not found: $orig"
}

# Write a minimal stub so Designer partial still has a matching constructor and handlers won't be missing.
$stub = @"
Public Class Frm_02_00_LandingResto
    Inherits System.Windows.Forms.Form

    Public Sub New()
        InitializeComponent()
    End Sub

    ' Keep the form minimal — add your logic later.
End Class
"@

$stubPath = Join-Path $projectRoot "Frm_02_00_LandingResto.vb"
Set-Content -LiteralPath $stubPath -Value $stub -Encoding UTF8
Write-Host "Wrote minimal stub to: $stubPath"