import {Injectable} from 'angular2/core';
import {User} from '../models/User';

@Injectable()
export class UserContext {
    public currentUser:User;

    constructor() {
        this.currentUser = new User();
    }
}