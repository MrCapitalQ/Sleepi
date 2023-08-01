# Give app execution permission.
chmod +x /var/www/Sleepi/MrCapitalQ.Sleepi.Api

# Optionally, stop and disable existing service.
sudo systemctl stop kestrel-sleepi.service
sudo systemctl disable kestrel-sleepi.service

# Move latest service definition file to systemd.
sudo mv /var/www/Sleepi/kestrel-sleepi.service /etc/systemd/system
sudo systemctl daemon-reload

# Enable auto startup and start the service.
sudo systemctl enable kestrel-sleepi.service
sudo systemctl start kestrel-sleepi.service

# Optionally, check the status and logs of the service.
sudo systemctl status kestrel-sleepi.service
sudo journalctl -fu kestrel-sleepi.service --since today