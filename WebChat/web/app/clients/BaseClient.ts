import {Response, Headers, Http} from '@angular/http';

export abstract class BaseClient {
    constructor(private http: Http) {}
    protected extractData(res: Response) {
        if (res.status < 200 || res.status >= 300) {
            throw new Error('Bad response status: ' + res.status);
        }
        let body = res.json() || {};
        return body || body.data || { };
    }

    public get(url) {
        return this.http.get(url);
    }

    public post(url, data, headers?:Headers) {
        let headersWithDefaultValues = new Headers(headers);
        if (! headersWithDefaultValues.has("Content-Type")) {
             headersWithDefaultValues.append('Content-Type', 'application/json');
        }

        return this.http.post(url, data, {
            headers:  headersWithDefaultValues
        });
    }
}