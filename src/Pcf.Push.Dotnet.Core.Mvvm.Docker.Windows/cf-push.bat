cf target -s pcf-push
pause
@cls

cf delete pcf-push-dotnet-core-mvvm-docker-windows -r -f
pause
@cls

cf push pcf-push-dotnet-core-mvvm-docker-windows --docker-image nycpivot/pcf-push-dotnet-core-mvvm-docker-windows
pause
@cls