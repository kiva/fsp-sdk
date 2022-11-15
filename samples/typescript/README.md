# Typescript Sample


# Getting started
1. download the code from github
2. navigate to `samples\typescript directory` and run `npm install`
3. copy dummy.env to .env
4. update .env client_id and client_secret to the values given to you by your coordinator

## Getting an authorization token example
This example shows how to retrieve an auth token with the credentials provided.  
[Code](./src/demo/auth.ts)  
1. run `npm run auth`

## Using the authorization token example
This example shows how to use the auth token to make another API call, in this case getting a list of loans.
[Code](./src/demo/get.loans.ts)  
1. run `npm run get-loans`
