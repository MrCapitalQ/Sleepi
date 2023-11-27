# Installs system dependencies needed for the app to run properly.

sudo apt update
sudo apt upgrade

sudo apt-get install -y vlc pulseaudio pulseaudio-module-bluetooth

# Configure auto-login for headless setups.
#   sudo raspi-config 
# Choose System Options > Boot / Auto Login > Console Autologin

# Connect to bluetooth speaker.
#   bluetoothctl scan on
# Once device is visible with its mac address in scan output, stop scan.
#   bluetoothctl trust <mac-address>
#   bluetoothctl pair <mac-address>
# Optionally test connection
#   bluetoothctl connect <mac-address>
#   bluetoothctl disconnect <mac-address>
