import {Injectable} from '@angular/core';
import {Http} from '@angular/http';
import {BaseClient} from './BaseClient';
import {User} from '../models/User';
import 'rxjs/Rx';

@Injectable()
export class UsersClient extends BaseClient {

    //Look for a solution in TS to avoid this boilerplate
    constructor(http: Http) {
        super(http);
    }
    public getFriends(): Promise<User[]> {
        return this.get("/api/users/getfriends")
                        .toPromise()
                        .then(this.extractData);
    }
}