cf target -s pcf-push
pause
@cls

cf delete pcf-push-dotnet-core-api-routing-products -r -f
pause
@cls

cf push
pause
@cls