import {Injectable} from '@angular/core';
import {Http, Response} from '@angular/http';
import {BaseClient} from './BaseClient';
import {LoginModel} from '../viewModels/LoginModel';
import {User} from '../models/User';
import 'rxjs/Rx';

@Injectable()
export class AuthClient extends BaseClient {

    //Look for a solution in TS to avoid this boilerplate
    constructor(http: Http) {
        super(http);
    }
    public login(login:LoginModel): Promise<User> {
        let body = JSON.stringify(login);
        return this.post("/api/auth/login", body)
                        .toPromise()
                        .then(this.extractData);
    }

    public getCurrentUser(): Promise<User> {
        return this.get("/api/auth/GetCurrentUserInfo")
                        .toPromise()
                        .then(this.extractData);
    }
}