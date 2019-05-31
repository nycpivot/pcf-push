cf target -s pcf-push
pause
@cls

cf delete pcf-push-dotnet-core-mvc-windows -r -f
pause
@cls

cf push
pause
@cls