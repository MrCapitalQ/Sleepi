# Build and publish app for Raspberry Pi OS 64 bit.
dotnet publish .\src\MrCapitalQ.Sleepi.Api --configuration Release --runtime linux-arm64  --self-contained true

# Copy app to Raspberry Pi deploy destination
scp -r .\src\MrCapitalQ.Sleepi.Api\bin\Release\net7.0\linux-arm64\publish\* q@raspberrypi:/var/www/Sleepi

# Copy service definition file to Raspberry Pi deploy destination
scp -r .\infra\linux\kestrel-sleepi.service q@raspberrypi:/var/www/Sleepi

# SSH into Raspberry Pi and run commands in infra/linux/configure.sh