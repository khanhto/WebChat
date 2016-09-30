import {Injectable} from '@angular/core';
import {User} from '../models/User';

@Injectable()
export class UserContext {
    public currentUser:User;

    constructor() {
        this.currentUser = new User();
    }
}