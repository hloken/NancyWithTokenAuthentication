# NancyWithTokenAuthentication
Nancy API with token-based authentication

Contains:
* IdentityServer.ConsoleHost - console-based, self-hosted IdentityServer with client definitions for both user-based authentication and mobile devices
  (please note SSL has been disabled, not at all safe for production environments)
* NancyWithTokenAuthentication.RestApi - Nancy-modules detailing the Rest-Api
* NancyWithTokenAuthentication.RestApi.ConsoleHost - console self-hoster for RestApi
* SimpleClient - Console client that using first machine-based and then user-based authentication with the IdentityServer for calling a secured hello-world Rest API get method.

