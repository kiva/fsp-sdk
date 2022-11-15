import axios from 'axios';
import * as dotenv from 'dotenv';
const querystring = require('querystring');

class AuthorizationResponse {
    public access_token: string = '';
    public token_type: string = '';
    public expires_in: number = 0;
    public scope: string = '';
    public iss: string = '';
    public partnerId: string = '';
    public jti: string = '';
}

const log = (text: string, data?: any) => {
    console.log(text, data || '');
};

// https://stackoverflow.com/questions/31756756/axios-http-client-how-to-construct-http-post-url-with-form-params
const gethAuthToken = async () => {
    dotenv.config();
    log(`getting autho token using client_id '${process.env.client_id}'`);
    log(`\twith secret '${process.env.client_secret}'`);


    const inputData = querystring.stringify({
        grant_type: 'client_credentials',
        scope: 'create:loan_draft read:loans',
        audience: 'https://partner-api-stage.dk1.kiva.org',
        client_id: process.env.client_id,
        client_secret: process.env.client_secret,
    });

    const config = {
        headers:  {
            Accept: 'application/json',
            'Content-Type': 'application/x-www-form-urlencoded',
        }
    };

    try {
        const { data, status } = await axios.post<AuthorizationResponse>('https://auth-stage.dk1.kiva.org/oauth/token', {
            inputData,
            config,
        });
    } catch (e) {
        if (e instanceof Error) {
            log(`error: ${e.message}`);
        } else {
            log(`error, but not understood`, e);
        }
    }
};

gethAuthToken().then();
