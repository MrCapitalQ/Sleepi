$publishDirectory = ".\src\MrCapitalQ.Sleepi.Api\bin\Release\net7.0\linux-arm64\publish"

# Clean publish directory
Remove-Item -LiteralPath $publishDirectory -Force -Recurse -ErrorAction Ignore

# Build and publish app for Raspberry Pi OS 64 bit.
dotnet publish .\src\MrCapitalQ.Sleepi.Api --configuration Release --runtime linux-arm64  --self-contained true

# Include service definition file in publish directory.
Copy-Item .\infra\linux\kestrel-sleepi.service $publishDirectory

# Include service definition file in publish directory.
Copy-Item .\infra\linux\configure.sh $publishDirectory

# Copy publish directory to Raspberry Pi deploy destination
scp -r $publishDirectory\* q@raspberrypi:/var/www/Sleepi

# SSH into Raspberry Pi and execute the following command
# sudo bash /var/www/Sleepi/configure.sh
