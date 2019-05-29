cf target -s pcf-push
pause

cf delete pcf-push-dotnet-framework-webforms-windows -r -f
pause

cf push
pause