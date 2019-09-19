cf target -s pcf-push
pause
@cls

cf delete pcf-push-dotnet-framework-mvc-windows-config -r -f
pause
@cls

cf push
pause
@cls