cf target -s pcf-push

cf cups pcf-cups-app-settings -p '{\"appName\":\"Config\",\"appVersion\":\"2.0\"}'
cf cups pcf-cups-connection-strings -p '{\"name\":\"DefaultDatabase\",\"connectionString\":\"Server=server;InitialCatalog=database;UserName=user;Password=password;\"}'
pause