# Give app execution permission.
chmod +x /var/www/Sleepi/MrCapitalQ.Sleepi.Api

# Optionally, stop and disable existing service.
systemctl --user stop kestrel-sleepi.service
systemctl --user disable kestrel-sleepi.service

# Copy latest service definition file to systemd.
sudo cp /var/www/Sleepi/kestrel-sleepi.service /etc/systemd/user
systemctl --user daemon-reload

# Enable auto startup and start the service.
systemctl --user enable kestrel-sleepi.service
systemctl --user start kestrel-sleepi.service

# Optionally, check the status and logs of the service.
systemctl --user status kestrel-sleepi.service
# journalctl -fu kestrel-sleepi.service --since today --user
