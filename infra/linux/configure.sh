# Give app execution permission.
chmod +x /var/www/Sleepi/MrCapitalQ.Sleepi.Api

# Optionally, stop and disable existing service.
systemctl stop kestrel-sleepi.service
systemctl disable kestrel-sleepi.service

# Copy latest service definition file to systemd.
cp /var/www/Sleepi/kestrel-sleepi.service /etc/systemd/system
systemctl daemon-reload

# Enable auto startup and start the service.
systemctl enable kestrel-sleepi.service
systemctl start kestrel-sleepi.service

# Optionally, check the status and logs of the service.
systemctl status kestrel-sleepi.service
# journalctl -fu kestrel-sleepi.service --since today
