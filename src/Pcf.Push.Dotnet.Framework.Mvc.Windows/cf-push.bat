cf target -s pcf-dotnet-push
pause

cf delete pcf-dotnet-framework-push-mvc-windows -r -f
pause

cf push
pause