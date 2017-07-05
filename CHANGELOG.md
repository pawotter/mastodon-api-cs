# CHANGE LOG

## 0.4.0
### BREAKING CHANGES

* Add static factory method to `Tag` and `Token` entities.  ([#37](https://github.com/pawotter/mastodon-api-cs/pull/37))$
* Rename all the static factory methods of entities from `create` to `Create`. ([#35](https://github.com/pawotter/mastodon-api-cs/pull/35))$
* Rename method `OAuthAccessScope.of` to `OAuthAccessScope.Of`. ([#36](https://github.com/pawotter/mastodon-api-cs/pull/36))$

## 0.3.0
### BREAKING CHANGES

* All error responses are thrown as the type MastodonApiException. ([#26](https://github.com/pawotter/mastodon-api-cs/pull/26))$

## 0.2.1
### Features

* The constructor parameter of MastodonAuthClient and MastodonApi had become optional. ([#23](https://github.com/pawotter/mastodon-api-cs/pull/23))

## 0.2.0
### Anomalies

* Fix a problem of deserializing Account entity. Avatar and AvatarStatic properties could not derived from JSON. But now fiexed. ([#20](https://github.com/pawotter/mastodon-api-cs/pull/20))
* Fix a problem of deserializing Header/HeaderStatic properties of Account entity. ([#20](https://github.com/pawotter/mastodon-api-cs/pull/20))

### BREAKING CHANGES

* All the contructors of entities had been replaced to static factory methods `Create`.  ([#22](https://github.com/pawotter/mastodon-api-cs/pull/22))
* The type of Header/AvaterHeader properties of Account was changed from Uri to string.  ([#20](https://github.com/pawotter/mastodon-api-cs/pull/20))

## 0.1.4
### Features

* Add Link property to Response class ([#8](https://github.com/pawotter/mastodon-api-cs/pull/8))
  * this enabled getting next/prev link from array response easily.

## 0.1.3
### Anomalies

* Regression bug fix for pull request [#2](https://github.com/pawotter/mastodon-api-cs/pull/2) ((#7)[https://github.com/pawotter/mastodon-api-cs/pull/7])

## 0.1.2
### Anomalies

* Fix a bug of endpoint url([#5](https://github.com/pawotter/mastodon-api-cs/pull/5))

## 0.1.1
### BREAKING CHANGES

* Use StatusVisibility instead of string in Visibility field of Status class.

## 0.1.0

Release.

