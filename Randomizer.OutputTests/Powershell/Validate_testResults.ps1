param(
[string]$folderPathWithExtension = "C:\Temp\*.log"
)

if(Test-Path $folderPathWithExtension)
{
 	return -1;
}

return 0;
