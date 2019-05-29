The ideal means of deploying a task is to be able to not have to start it.

cf push --no-start

However, this will not create a droplet, and therefore, will fail to launch when executing a task against it.

It is necessary to omit the --no-start flag to allow the server to stage it as a droplet.

https://github.com/cloudfoundry/cli/issues/1045