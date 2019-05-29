cf target -s pcf-push
pause

cf delete pcf-push-dotnet-core-mvc-linux -r -f
pause

cf push
pause