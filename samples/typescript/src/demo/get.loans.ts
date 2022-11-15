import * as dotenv from 'dotenv';

const log = (text: string, data?: any) => {
    console.log(text, data || '');
};

var partnerId: string = '';
var authToken: string = '';

const gethAuthToken = async () => {
    dotenv.config();
    log(`getting autho token using client_id '${process.env.client_id}'`);
    log(`\twith secret '${process.env.client_secret}'`);

    const uri: string = 'https://auth-stage.dk1.kiva.org/oauth/token';
    const details = {
        grant_type: 'client_credentials',
        scope: 'create:loan_draft read:loans',
        audience: 'https://partner-api-stage.dk1.kiva.org',
        client_id: process.env.client_id,
        client_secret: process.env.client_secret,
    };

    const headers =  {
            Accept: 'application/json',
            'Content-Type': 'application/x-www-form-urlencoded',
        };

    var formBody = [];
    for (var property in details) {
        var encodedKey = encodeURIComponent(property);
        // @ts-ignore
        var encodedValue = encodeURIComponent(details[property]);
        formBody.push(encodedKey + "=" + encodedValue);
    }
    const body = formBody.join("&");
    const response = await fetch(uri, {
        method: 'POST',
        headers,
        body
    });

    const data = await response.json();
    partnerId = data.partnerId;
    authToken = data.access_token;

};

const getLoans = async () => {
    log(`\r\n\r\nGET LOANS EXAMPLE\r\n\r\n`);
    await gethAuthToken();
    const uri: string = `https://partner-api-stage.dk1.kiva.org/v3/partner/${partnerId}/loans`;
    log(`calling ${uri}`);
    const headers =  {
        Accept: 'application/json',
        Authorization: `Bearer ${authToken}`
    };
    const response = await fetch(uri, {
        method: 'GET',
        headers
    });
    const data = await response.json();
    log(`v3/loans received`, data);
};


getLoans().then();

