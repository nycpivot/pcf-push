cf target -s pcf-push
pause
@cls

cf unbind-service pcf-cups-app-settings pcf-push-dotnet-framework-mvc-windows-config
cf unbind-service pcf-cups-connection-strings pcf-push-dotnet-framework-mvc-windows-config
pause
@cls

cf delete-service pcf-cups-app-settings -f
cf delete-service pcf-cups-connection-strings -f
pause
@cls

cf delete pcf-push-dotnet-framework-mvc-windows-config -r -f
pause
@cls