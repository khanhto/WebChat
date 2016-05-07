import {Injectable} from 'angular2/core';
import {Http, Response} from 'angular2/http';
import {Promise} from 'es6-shim';
import {BaseClient} from './BaseClient';
import {LoginModel} from '../viewModels/LoginModel';
import 'rxjs/Rx';

@Injectable()
export class AuthClient extends BaseClient {

    //Look for a solution in TS to avoid this boilerplate
    constructor(http: Http) {
        super(http);
    }
    public login(login:LoginModel): Promise<Response> {
        let body = JSON.stringify(login);
        return this.post("/api/auth/login", body)
                        .toPromise()
                        .then(this.extractData);
    }
}