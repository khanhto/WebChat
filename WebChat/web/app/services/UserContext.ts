import {Injectable} from '@angular/core';
import {User} from '../models/User';
import {AuthClient} from '../clients/AuthClient';

@Injectable()
export class UserContext {
    private currentUser:User;

    constructor(private authClient:AuthClient
    ) {
    }

    public getCurrentUser(): Promise<User> {
        if (!this.currentUser) {
            return this.authClient
                    .getCurrentUser()
                    .then(user => {
                        this.updateCurrentUser(user.id,user.name);

                        return this.currentUser;
                    });
        }

        return Promise.resolve(this.currentUser);
    }

    public updateCurrentUser(id:number,name:string) {
        if (!this.currentUser) {
            this.currentUser = new User();
        }

        this.currentUser.id = id;
        this.currentUser.name = name;
    }
}