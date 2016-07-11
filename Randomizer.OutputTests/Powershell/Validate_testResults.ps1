param(
[string]$folderPathWithExtension = "C:\Temp\*.log"
)

if(Test-Path $folderPathWithExtension)
{
    Write-Error 'Folder is not empty. It contains errors.'
    [System.Environment]::Exit(-1)
}
[System.Environment]::Exit(0)