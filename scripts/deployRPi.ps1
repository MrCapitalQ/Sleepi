$publishDirectory = ".\src\MrCapitalQ.Sleepi.Api\bin\Release\net8.0\linux-arm64\publish"
$deployDirectory = "/var/www/Sleepi"
$sshUser = "q"
$sshHostName = "sleepi"

$sshDeployTarget = "$sshUser@$sshHostName"
$currentDir = Get-Location

try {
    Set-Location $PSScriptRoot
    Set-Location ..

    # Clean publish directory
    Remove-Item -LiteralPath $publishDirectory -Force -Recurse -ErrorAction Ignore

    # Build and publish app for Raspberry Pi OS 64 bit.
    dotnet publish .\src\MrCapitalQ.Sleepi.Api --configuration Release --runtime linux-arm64 --self-contained true
    if (!$?) { Exit $LASTEXITCODE }

    # Include service definition file in publish directory.
    Copy-Item .\infra\linux\kestrel-sleepi.service $publishDirectory

    # Include service definition file in publish directory.
    Copy-Item .\infra\linux\configure.sh $publishDirectory

    # Stop existing sevice
    ssh $sshDeployTarget "systemctl --user stop kestrel-sleepi.service"
    
    # Ensure deploy destination exists
    ssh $sshDeployTarget "sudo mkdir -p $deployDirectory && sudo chown $sshUser $deployDirectory"
    if (!$?) { Exit $LASTEXITCODE }

    # Copy publish directory to Raspberry Pi deploy destination
    scp -r $publishDirectory\* "$($sshDeployTarget):$deployDirectory"
    if (!$?) { Exit $LASTEXITCODE }

    # Run script to configure service
    ssh $sshDeployTarget "bash $deployDirectory/configure.sh"
}
finally {
    # Return to original directory
    Set-Location $currentDir
}
