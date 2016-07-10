param(
[string]$folderPathWithExtension = "C:\Temp\*.log"
)

if(Test-Path $folderPathWithExtension -eq True)
{
    throw [System.Exception] $folderPathWithExtension
}
