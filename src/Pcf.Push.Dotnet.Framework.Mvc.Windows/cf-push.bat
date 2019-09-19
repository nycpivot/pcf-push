cf target -s pcf-push
pause
@cls

cf delete pcf-dotnet-framework-push-mvc-windows -r -f
pause
@cls

cf push
pause
@cls