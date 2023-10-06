$publishDirectory = ".\src\MrCapitalQ.Sleepi.Api\bin\Release\net7.0\linux-arm64\publish"

$currentDir = Get-Location

try {
    # Clean publish directory
    Remove-Item -LiteralPath $publishDirectory -Force -Recurse -ErrorAction Ignore

    # Build and publish app for Raspberry Pi OS 64 bit.
    dotnet publish .\src\MrCapitalQ.Sleepi.Api --configuration Release --runtime linux-arm64 --self-contained true
    if (!$?) { Exit $LASTEXITCODE }

    # Include service definition file in publish directory.
    Copy-Item .\infra\linux\kestrel-sleepi.service $publishDirectory

    # Include service definition file in publish directory.
    Copy-Item .\infra\linux\configure.sh $publishDirectory

    # Copy publish directory to Raspberry Pi deploy destination
    scp -r $publishDirectory\* q@raspberrypi:/var/www/Sleepi
    if (!$?) { Exit $LASTEXITCODE }

    # SSH into Raspberry Pi and execute the following command
    # sudo bash /var/www/Sleepi/configure.sh
    Write-Host "Build and file transfer complete." -ForegroundColor green
    Write-Host "To complete the deployment, SSH into the Raspberry Pi and execute the following:" -ForegroundColor green
    Write-Host "    sudo bash /var/www/Sleepi/configure.sh" -ForegroundColor yellow
}
finally {
    # Return to original directory
    Set-Location $currentDir
}
