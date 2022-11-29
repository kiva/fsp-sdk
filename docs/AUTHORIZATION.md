# Authorization

Kiva Protocol uses OAuth for site access and role security.

### Samples

We have provided some sample code which demonstrates getting and using the OAuth token.

[Typescript](../samples/typescript/README.md) | [PostMan](../samples/postman/README.md)

## Errors

Anytime you make an API call and get a `Unauthorized 404` error, the first thing to suspect is the token (if the API requires the token), 
or the credentials used when attempting to get a token.

You can use this table to help diagnosis `Unauthorized 404` errors.

| API | Header Fields to Check   | Documentation                                                                                                               |
| ------ |--------------------------|-----------------------------------------------------------------------------------------------------------------------------|
| Get Token | client_id, client_secret | [link](https://kivapartnerhelpcenter.zendesk.com/hc/en-us/articles/360051231131-API-authentication-client-credential-flow-) | 
| Get Loans | Authorization            | [link](https://kivapartnerhelpcenter.zendesk.com/hc/en-us/articles/360051230151-Using-the-API-loans-fetch-endpoint)         |
| All other API | Authorization | [link](https://kivapartnerhelpcenter.zendesk.com/hc/en-us/articles/360051228911-Overview-of-Kiva-s-API)                     |



## Resources
[oAuth Documentation](https://oauth.net/2/)  