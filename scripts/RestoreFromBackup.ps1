$backup = ".\replace_backup_20251010_203828"
$restoreList = @(
    "Frm_00_01_Landing.vb",
    "Frm_02_00_LandingResto.vb",
    "Frm_02_00_LandingResto.Designer.vb"
)

foreach ($f in $restoreList) {
    $src = Join-Path $backup $f
    $dst = Join-Path (Get-Location) $f
    if (Test-Path $src) {
        Copy-Item -LiteralPath $src -Destination $dst -Force
        Write-Host "Restored $f"
    } else {
        Write-Host "Backup not found for $f -> $src"
    }
}
Write-Host "Restore completed. Open solution and build."