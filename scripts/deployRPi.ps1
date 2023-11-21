$publishDirectory = ".\src\MrCapitalQ.Sleepi.Api\bin\Release\net8.0\linux-arm64\publish"

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
    ssh q@raspberrypi systemctl --user stop kestrel-sleepi.service

    # Copy publish directory to Raspberry Pi deploy destination
    scp -r $publishDirectory\* q@raspberrypi:/var/www/Sleepi
    if (!$?) { Exit $LASTEXITCODE }

    # Run script to configure service
    ssh q@raspberrypi bash /var/www/Sleepi/configure.sh
}
finally {
    # Return to original directory
    Set-Location $currentDir
}
