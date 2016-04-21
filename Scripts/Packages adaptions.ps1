Get-ChildItem -Recurse -Include "*.csproj" | Select-String "MVCMultiLayer" | Select-Object -Unique Path | foreach {
    
    $a = (Get-Content $_.Path).Replace("MVCMultiLayer", "$safeprojectname$")
    $a | Out-File $_.Path -Force 
} 
  

Get-ChildItem -Recurse -Include "*.csproj" | Select-String "packages" | Select-Object -Unique Path | foreach {
    
    $a = (Get-Content $_.Path).Replace("..\packages\", "..\..\packages\")
    $a | Out-File $_.Path -Force 
} 
  