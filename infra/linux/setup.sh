# Installs system dependencies needed for the app to run properly.

sudo apt update
sudo apt upgrade

# Install .NET 7.0 runtime for ASP.NET Core API server app.
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
chmod +x ./dotnet-install.sh
./dotnet-install.sh --channel STS --runtime aspnetcore
echo 'export DOTNET_ROOT=$HOME/.dotnet' >> ~/.bashrc
echo 'export PATH=$PATH:$DOTNET_ROOT:$DOTNET_ROOT/tools' >> ~/.bashrc
source ~/.bashrc

# VLC is used to play audio on Linux.
sudo apt-get install -y vlc
