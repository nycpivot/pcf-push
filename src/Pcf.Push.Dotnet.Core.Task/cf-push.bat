cf target -s pcf-push
pause
@cls

cf delete pcf-push-dotnet-core-task -r -f
pause
@cls

cf push
pause
@cls

cf stop pcf-push-dotnet-core-task
pause
@cls

cf run-task pcf-push-dotnet-core-task "cd ${HOME} && exec dotnet ./Pcf.Push.Dotnet.Core.Task.dll --server.urls http://0.0.0.0:${PORT}" --name "pcf-push-dotnet-core-task"
pause
@cls