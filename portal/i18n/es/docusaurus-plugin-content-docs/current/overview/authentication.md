---
sidebar_position: 3
---

# API authentication

Las siguientes instrucciones son para autenticarse en el entorno de pruebas de Kiva, Stage. Este es el primer paso en cualquier integración de la API. Si ya ha completado sus pruebas, y sus pruebas han sido aprobadas por Kiva, siga las instrucciones de la sección "Autenticación en el entorno de producción de Kiva (DESPUÉS de las pruebas)".

Se puede acceder a la nueva API de socios mediante un Oauth2 JWT obtenido del servicio de autenticación de Kiva siguiendo el flujo de credenciales de cliente Oauth2. De forma más sencilla, se trata de un cambio de las credenciales de cliente del socio por un token de duración limitada que puede utilizarse para autenticarse y autorizarse.

### Solicitud de muestra (entorno de prueba)

```json
1 curl --location --request POST 'https://auth-stage.dk1.kiva.org/oauth/token' \
2 --header 'Accept: application/json' \
3 --header 'Content-Type: application/x-www-form-urlencoded' \
4 --data-urlencode 'grant_type=client_credentials' \
5 --data-urlencode 'scope=create:loan_draft read:loans' \
6 --data-urlencode 'audience=https://partner-api-stage.dk1.kiva.org' \
7 --data-urlencode 'client_id=<client ID>' \
8 --data-urlencode 'client_secret=<client secret from Partner Admin>'
```

### Post Data
* **grant_type** - required. Siempre tendrá el valor client_credentials.
* **scope** - representa las acciones que dentro de la API del socio deben ser ejecutadas. Si el socio está autorizado para estas acciones, el JWT devuelto contendrá todas las acciones autorizadas. Los scopes válidos son read:loans, create:loan_draft, create:journal_update, create:repayment.
* **audience** - identifica la audiencia del JWT, que es la API donde se utilizará el JWT.
* **client_id** - es la primera mitad de las credenciales del cliente. Es accesible desde Partner Admin e identifica directamente al socio dentro del sistema de Kiva.
* **client_secret** - esta es la segunda mitad de las credenciales del cliente. Se puede acceder a ella desde Partner Admin y es necesaria para validar una solicitud de credenciales de cliente. client_id y client_secret deben tratarse como secretos sensibles.


### Datos de respuesta (entorno de prueba)
Si la autenticación es exitosa, debería recibir una respuesta como la siguiente:

```json
1 {
2    "access_token": "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjFublhjRFRHIn0.eyJhdWQiOlsiaHR0cHM6Ly9wYXJ0bmVyLWFwaS5rMS5raXZhLm9yZyJdLCJzY29wZSI6WyJjcmVhdGU6bG9hbl9kcmFmdCIsInJlYWQ6bG9hbnMiXSwiaXNzIjoiaHR0cHM6Ly9hdXRoLmsxLmtpdmEub3JnLyIsInBhcnRuZXJJZCI6IjEiLCJleHAiOjE2MDIxNTY2MTgsImp0aSI6IlJVc2l2VVhHZ2hoeC1Zdjl6emEzZ2daaTZhbyIsImNsaWVudF9pZCI6IlFEMmxPRzZMbTN2RWQ5QTZEdVh3eFJWOE1OMEp6cDVreSJ9.U_tCMX5ra7Q0NFwr1FKlgqCBEmlprY-PuWRv6bNzEREtJABh0hBr-zEKXQEhHYTpHjjNquOHK7Q8hnQ30IVVhE6jXUO8_OgRfmczlQ8sDkRzmx5PTc99my0bs6zn8owRfEEwBGJcvNt_oT8iRASnlij99d7dozTFguBnT7_hauXoq2C4DFmRx3rjfnCbI9G7Ue_4Gh3jnF7VYI9HefLvYHBCS0SP3a-QqNuR5w1itRevj8KOIhC5lKuJn22cRXW9PQL3G9XGyK0h8sFZj7blhLETMLFAHbrWFUGzawEBAeLQbQhvvu78dp0RzgY0OvS2XXzTgxpg0TcgsrWuDdjFAA",
3    "token_type": "bearer",
4    "expires_in": 43199,
5    "scope": "create:loan_draft read:loans",
6    "iss": "https://auth.stage.dk1.kiva.org/",
7    "partnerId": "1",
8    "jti": "RUsivUXGghhx-Yv9zza3ggZi6ao"
9 }
```

* **access_token** - this is the bearer token that you will use to access the Partner API.
* **token_type** - this indicates the type of token, this should always be bearer.
* **expires_in** - number of seconds the token will be valid for (also check the exp claim inside the JWT for an expiration timestamp).
* **scope** - this is an intersection between scopes that were requested and scopes that the Partner has been authorized for.
* **iss** - the issuer of the JWT.
* **partnerId** - the Kiva identifier for the partner. You can find your partnerId in PA2 by going to the Account > Profile page.
* **jti** - the unique identifier for the token

### Partner API Authentication
Once you have received an access token, supply it as a Bearer token in the Authorization header as in the below curl example. You will need to customize two components:

Insert your partner ID in the URL where it says "PARTNERID". You can find your partner ID in PA2 by going to the _Account > Profile page_.
Insert the unique bearer token you received.

### Get your account access
Once you have an account created by a Kiva admin you can login into the management [website](https://partners.kiva.org/pa3/partner/145/api).

```
curl --location --request GET 'https://partner-api-stage.dk1.kiva.org/v3/partner/PARTNERID/loans' \
--header 'Authorization: Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjFublhjRFRHIn0.eyJhdWQiOlsiaHR0cHM6Ly9wYXJ0bmVyLWFwaS5rMS5raXZhLm9yZyJdLCJzY29wZSI6WyJjcmVhdGU6bG9hbl9kcmFmdCIsInJlYWQ6bG9hbnMiXSwiaXNzIjoiaHR0cHM6Ly9hdXRoLmsxLmtpdmEub3JnLyIsInBhcnRuZXJJZCI6IjEiLCJleHAiOjE2MDIyMjA0MTYsImp0aSI6IlpldUt0WTZXQU5VU2lWai1EZTVtZE5nRnFGSSIsImNsaWVudF9pZCI6IlFEMmxPRzZMbTN2RWQ5QTZEdVh3eFJWOE1OMEp6cDVreSJ9.mdOHScBFzkKribTjFCfUG_BrzrDELFgznvp7OPwDvE_-dOZ-qbSR0IoItgw9Nzsgv13pY0MOM8euEzHThvaxi8gtr1WV0MY4TCE3ffgApaUo_-uC5cXu1NoMPjToE53kHthRmv4cWOu_ycFYMvPV606U24Jsgs1txNrobu_ZlUsaFpyPN-9Pr1wq8N0VQWOS9qt_lkKB0aJhbMHsNOHysTXTclkGh2jbXKj10H5LnXBQsh-UpLSKCw3UoMlepR4tjRxyXnSYLgZ80jTPSsOU1oKkAYdLRSbUHEM4g30FfZ8__kUI7LNtlmuVWYNV3ZVn0yxLO1wSu4n31TsIZUX_Ag
```