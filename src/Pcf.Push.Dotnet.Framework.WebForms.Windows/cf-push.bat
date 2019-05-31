cf target -s pcf-push
pause
@cls

cf delete pcf-push-dotnet-framework-webforms-windows -r -f
pause
@cls

cf push
pause
@cls