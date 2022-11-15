import * as dotenv from 'dotenv';

const log = (text: string, data?: any) => {
    console.log(text, data || '');
};

let partnerId: string = '';
let authToken: string = '';

// this method is the same as in the auth example
// please see that example for more comments
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

    // get the auth token since that will be needed for the next call
    await gethAuthToken();

    const uri: string = `https://partner-api-stage.dk1.kiva.org/v3/partner/${partnerId}/loans`;
    log(`calling ${uri}`);

    // creating the headers.  authToken value is retrieved from the function
    // gethAuthToken above.  authToken ensures you have permissions and rights to make
    // the api call below
    const headers =  {
        Accept: 'application/json',
        Authorization: `Bearer ${authToken}`
    };

    // now make the get loans call sending only required fields and leaving all optional
    // fields blank.
    // this is documented here:
    // https://kivapartnerhelpcenter.zendesk.com/hc/en-us/articles/360051230151-Using-the-API-loans-fetch-endpoint
    const response = await fetch(uri, {
        method: 'GET',
        headers
    });


    const data = await response.json();

    // print out the results of the call.  if no loans are posted
    // the output will be minimal
    log(`v3/loans received`, data);
};


getLoans().then(() => {
    log(`GET loans api call completed successfully`);
}).catch((e: unknown) =>{
    if (e instanceof Error) {
        log(`error: ${e.message}`);
    } else {
        log(`error, but not understood`, e);
    }
});

