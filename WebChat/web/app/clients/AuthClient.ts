import {Injectable} from 'angular2/core';
import {Http, Response} from 'angular2/http';
import {Promise} from 'es6-shim';

@Injectable()
export class AuthClient {
    constructor(private http: Http) {}
    login(username:string, password:string): Promise<Response> {
        return Promise.resolve(null);
    //    return this.http.get("/api/auth/login").toPromise();
    }
}