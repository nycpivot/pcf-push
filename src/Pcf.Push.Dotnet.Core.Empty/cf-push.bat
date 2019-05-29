cf target -s pcf-push
pause

cf delete pcf-push-dotnet-core-empty -r -f
pause

cf push
pause