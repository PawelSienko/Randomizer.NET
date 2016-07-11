param(
[string]$folderPathWithExtension = "C:\Temp\*.log"
)

if(Test-Path $folderPathWithExtension)
{
 	throw [System.Exception] "Some wrong test results came up."
}

