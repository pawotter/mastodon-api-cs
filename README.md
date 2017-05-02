Mastodon API client library for C#
======

[![Build Status](https://travis-ci.org/pawotter/mastodon-api-cs.svg?branch=master)](https://travis-ci.org/pawotter/mastodon-api-cs) [![NuGet](https://img.shields.io/nuget/v/Mastodon.API.svg)](https://www.nuget.org/packages/Mastodon.API) [![License](https://img.shields.io/cocoapods/l/BadgeSwift.svg?style=flat)](/LICENSE)

The Mastodon API Client Library for C# (PCL 4.5, Profile 111)

Pull reqeusts are always welcome!

# Install

```
Install-Package Mastodon.API
```

# Registering an app to Mastodon instance

```csharp
var authClient = new MastodonAuthClient(new Uri("https://friends.nico"));
var redirectUri = new Uri("urn:ietf:wg:oauth:2.0:oob");
var scope = OAuthAccessScope.of(OAtuhAccessScopeType.Read);
var app = await authClient.CreateApp("client_name", redirectUri, scope);
```

A registered OAuth application is assigned a unique Client ID and Client Secret.

# Login with email address and password

Not recommended to use in service. The Authorization Code Grant flow is recommended for applications.

```csharp
var token = await authClient.GetOAuthToken(app.ClientId, app.ClientSecret, "username", "password", scope);
```

# Making API Calls

```csharp
var config = new MastodonApiConfig(instanceUrl, token.AccessToken);
var api = new MastodonApi(config);
var account = await api.GetCurrentAccount();
```

# Error Handling

All error responses are thrown as the type MastodonApiException.  Please be sure to catch this in your code and respond to any error condtions appropriately.

```csharp
try
{
  // api calls here
}
catch (MastodonApiException e)
{
  // error handling here (i.e., no results found, login failed, server error, etc)
}
```

# License

MIT

# Author

gomi_ningen (@53ningen)

