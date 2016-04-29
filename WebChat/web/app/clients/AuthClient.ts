import {Injectable} from 'angular2/core';
import {Http, Response} from 'angular2/http';
import {Promise} from 'es6-shim';
import {BaseClient} from './BaseClient';

@Injectable()
export class AuthClient extends BaseClient {
    constructor(private http: Http) {
        super();
    }
    public login(username:string, password:string): Promise<Response> {
        let body = JSON.stringify({ username:username , password:password });
        return this.http.post("/api/auth/login", body)
                        .toPromise()
                        .then(this.extractData);
    }
}