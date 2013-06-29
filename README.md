Nodule-wCI
==========

A very simple Node module windows CI server. These projects do what https://travis-ci.org/ does for linux.
The site offers the webhook endpoint and a very simple web interface to see the PRs and their status.
The DB offers a storage on sdf file. In order to scale better one should definitely consider using a sql server (fairly easy to do since you already have the schema).
The worker is a wcf service that does the npm install on the pull request and updates the db. Although it’s a wcf service, if you host it on IIS keep in mind that despite the user this service is running as, the process.start will run with restricted permissions (http://stackoverflow.com/questions/4679561/system-diagnostics-process-start-not-work-fom-an-iis)
The worker.host is a simple windows service that can host the application and expose the worker wcf service. To install use install-util. Make sure that the associated user profile, has all the required environment variables (like node, npm, node-gyp etc).
You could also create an application that could be scheduled with windows task scheduler. 
