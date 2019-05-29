cf target -s pcf-push
pause

cf delete pcf-push-dotnet-core-mvvm-docker-linux -r -f
pause

cf push pcf-push-dotnet-core-mvvm-docker-linux --docker-image nycpivot/pcf-push-dotnet-core-mvvm-docker-linux
pause