cf target -s pcf-push
pause

cf delete pcf-push-dotnet-core-api-routing-customers -r -f
pause

cf push
pause