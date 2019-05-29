cf target -s pcf-push
pause

cf delete pcf-push-dotnet-core-task -r -f
pause

cf push
pause

cf stop pcf-push-dotnet-core-task
pause

cf run-task pcf-push-dotnet-core-task "cd ${HOME} && exec dotnet ./Pcf.Push.Dotnet.Core.Task.dll --server.urls http://0.0.0.0:${PORT}" --name "pcf-push-dotnet-core-task"
pause