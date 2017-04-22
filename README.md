Mastodon API client library for C#
======

[![License](https://img.shields.io/cocoapods/l/BadgeSwift.svg?style=flat)](/LICENSE)

The Mastodon API Client Library for C# (PCL 4.5, Profile 111)

Pull reqeusts are always welcome!

# Registering an app to Mastodon instance

```csharp
var http = new HttpClient();
var authClient = new MastodonAuthClient(new Uri("https://friends.nico"), http);
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
var api = new MastodonApi(config, http);
var account = await api.GetCurrentAccount();
```

# License

MIT

# Author

gomi_ningen (@53ningen)

