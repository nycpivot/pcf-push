cf target -s pcf-push
pause
@cls

cf delete pcf-push-dotnet-core-api-routing-customers -r -f
pause
@cls

cf push
pause
@cls