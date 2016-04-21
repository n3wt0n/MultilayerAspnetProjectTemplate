# Susbtitution for the references in .csproj files
Get-ChildItem -Recurse -Include "*.csproj" | Select-String "MVCMultiLayer" | Select-Object -Unique Path | foreach {
    
    $a = (Get-Content $_.Path).Replace("MVCMultiLayer", '$saferootprojectname$')
    $a | Out-File $_.Path -Encoding utf8 -Force 
} 
  
# Packages folder change in .csproj files: when it create the solution, the "Packages" folder is one level down
Get-ChildItem -Recurse -Include "*.csproj" | Select-String "packages" | Select-Object -Unique Path | foreach {
    
    $a = (Get-Content $_.Path).Replace("..\packages\", "..\..\packages\")
    $a | Out-File $_.Path -Encoding utf8 -Force 
}

# Change remaining fixed project names to dynamic root solution name
Get-ChildItem -Recurse -Exclude ("*.zip","*InputStream*","*.vstemplate") | Select-String "MVCMultiLayer" | Select-Object -Unique Path | foreach {
    if ($_ -ne "InputStream") {
        $a = (Get-Content $_.Path).Replace("MVCMultiLayer", '$saferootprojectname$')
        $a | Out-File $_.Path -Encoding utf8 -Force 
    }
} 
Get-ChildItem -Recurse -Exclude ("*.zip","*InputStream*","*.vstemplate") | Select-String 'rootsafeprojectname' | Select-Object -Unique Path | foreach {
    if ($_ -ne "InputStream") {
        $a = (Get-Content $_.Path)
        $b = $a.Replace('$saferootprojectname$Db', "MVCMultiLayerDb")        
        if ($a -ne $b) {
            $b | Out-File $_.Path -Encoding utf8 -Force 
        }
    }
} 