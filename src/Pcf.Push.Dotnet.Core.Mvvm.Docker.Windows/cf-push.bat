cf target -s pcf-push
pause

cf delete pcf-push-dotnet-core-mvvm-docker-windows -r -f
pause

cf push pcf-push-dotnet-core-mvvm-docker-windows --docker-image nycpivot/pcf-push-dotnet-core-mvvm-docker-windows
pause