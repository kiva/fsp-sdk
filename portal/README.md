# Website

This website is built using [Docusaurus 2](https://docusaurus.io/), a modern static website generator.

### Installation

```
$ yarn
```

### Local Development

```
$ yarn start
```

This command starts a local development server and opens up a browser window. Most changes are reflected live without having to restart the server.

### Testing a specific language

Rebuild for a language first.  This example rebuilds French.  To rebuild a different language, replace `fr` with the appropriate language code.
```
yarn run write-translations -- --locale fr
```

This example tests French.  To test a different language, replace `fr` with the appropriate language code.
```
yarn run start -- --locale fr
```

### Build

```
$ yarn build
```

This command generates static content into the `build` directory and can be served using any static contents hosting service.

### Deployment

We are using firebase for hosting the portal.  These instructions 
assumed you have installed the [firebase CLI](https://firebase.google.com/docs/cli).

Firebase access is linked to your Google account.  Please log in using your google account.

```
firebase login
```

Next build using the build command above then run these firebase commands.

```
firebase use --add
firebase target:apply hosting dec2022 fps-sdk-portal
firebase deploy
```