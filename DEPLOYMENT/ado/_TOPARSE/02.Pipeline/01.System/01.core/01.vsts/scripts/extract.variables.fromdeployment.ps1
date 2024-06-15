param (
    [Parameter(Mandatory=$true)][string] $armOutputString
)


$armOutputObj = $armOutputString | convertfrom-json


$armOutputObj.PSObject.Properties | ForEach-Object {
    $type = ($_.value.type).ToLower()
    $key = $_.name
    $value = $_.value.value

    if ($type -eq "securestring") {
        Write-Host "##vso[task.setvariable variable=$key;issecret=true]$value"
        Write-Host "Create VSTS variable with key '$key' and value '$value' of type '$type'!"
    } elseif ($type -eq "string") {
        Write-Host "##vso[task.setvariable variable=$key;issecret=true]$value"
        Write-Host "Create VSTS variable with key '$key' and value '$value' of type '$type'!"
    } else {
        Write-Host "Type '$type' not supported!"
    }
}