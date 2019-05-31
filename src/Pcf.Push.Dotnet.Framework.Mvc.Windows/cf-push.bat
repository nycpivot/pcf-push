cf target -s pcf-dotnet-push
pause
@cls

cf delete pcf-dotnet-framework-push-mvc-windows -r -f
pause
@cls

cf push
pause
@cls