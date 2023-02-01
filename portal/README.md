# Partner API Documentation Portal

This website is built using [Docusaurus 2](https://docusaurus.io/), a modern static website generator. It contains
information to help our partners integrate with [Kiva's Partner API](https://partner-api.k1.kiva.org/swagger-ui/#/partners).

## General Usage

### Installation

```
$ yarn
```

This command installs the necessary packages for building and running the site.

### Build

Run this command in the `fps-sdk/portal` directory:

```
$ yarn build
```

This will generate static content into the `fps-sdk/portal/build` directory and can be served using any static content
hosting service.

The build output will contain a directory for each locale present in [docusaurus.config.js](docusaurus.config.js):

* `build` - EN (default locale)
* `build/es` - ES (Spanish)
* `build/fr` - FR (French)

## Local Development

### Running the site with `yarn`

Run this command in the `fps-sdk/portal` directory:

```
$ yarn start
```

This will start a local development server and open up a browser window. Most changes are reflected live without
having to restart the server.

_Note: the best way to test the full site is on the [Firebase Emulator](#testing-on-the-firebase-emulator). Some
features, such as i18n, behave differently when the full site is deployed to Firebase._

### Testing a specific language

First, build the site for the locale you want to test. This example rebuilds French (FR). To rebuild a different
language, replace `fr` with the appropriate language code.

```
yarn run write-translations -- --locale fr
```

This example tests French. To test a different language, replace `fr` with the appropriate language code.

```
yarn run start -- --locale fr
```

## Firebase Deployment and Testing

We are using Firebase to host the portal. Firebase is a Google service for hosting static websites. These instructions
assume you have installed the [Firebase CLI](https://firebase.google.com/docs/cli).

The following sections assume you have run the [Install](#install) and [Build](#build) steps.

### Testing on the Firebase Emulator

Follow the instructions
on [Google's documentation for testing a site locally](https://firebase.google.com/docs/hosting/test-preview-deploy).
*Once you are satisfied with your work, please follow the steps for creating a Preview site, and link that in your pull
request!*

### Deploying to Firebase

The Firebase project is located at https://console.firebase.google.com/project/fps-sdk-portal/hosting/sites. If you
don't have access to this project, request it from one of the [CODEOWNERS](../CODEOWNERS).

Firebase access is linked to your Google account. Please log in using your google account:

```
firebase login
```

Run these Firebase commands:

```
firebase use --add
firebase target:apply hosting dec2022 fps-sdk-portal
firebase deploy
```
