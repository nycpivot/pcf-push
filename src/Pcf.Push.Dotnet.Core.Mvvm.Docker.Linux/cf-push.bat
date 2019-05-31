cf target -s pcf-push
pause
@cls

cf delete pcf-push-dotnet-core-mvvm-docker-linux -r -f
pause
@cls

cf push pcf-push-dotnet-core-mvvm-docker-linux --docker-image nycpivot/pcf-push-dotnet-core-mvvm-docker-linux
pause
@cls