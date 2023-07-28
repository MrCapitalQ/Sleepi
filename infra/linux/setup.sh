# Installs system dependencies needed for the app to run properly.

sudo apt update
sudo apt upgrade

# Install .NET 7.0 runtime for ASP.NET Core API server app.
sudo apt-get install -y aspnetcore-runtime-7.0

# VLC is used to play audio on Linux.
sudo apt-get install -y vlc
