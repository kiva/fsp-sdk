# Typescript Sample


# Getting started
1. download the code from github
2. navigate to `samples\typescript directory` and run `npm install`
3. copy dummy.env to .env
4. update .env client_id and client_secret to the values given to you by your coordinator

## Getting an authorization token example
This example shows how to retrieve an auth token with the credentials provided.  This example 
demostrates using `https://auth-stage.dk1.kiva.org/oauth/token` api.  
   
1. run `npm run auth`  
[Code](./src/demo/auth.ts)

## Using the authorization token example
This example shows how to use the auth token to make another API call, in this case getting a list of loans. This example 
uses the auth API (as above) as well as `https://partner-api-stage.dk1.kiva.org/v3/partner/{partnerId}/loans`.  
   
1. run `npm run get-loans`  
[Code](./src/demo/get.loans.ts)
