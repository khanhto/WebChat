import {Component} from "@angular/core";
import {LoginModel} from "../viewModels/LoginModel";
import {AuthClient} from "../clients/AuthClient";
import { Router } from '@angular/router';
import { UserContext } from '../services/UserContext';
import {User} from '../models/User';

@Component({
    selector: 'login',
    templateUrl: 'app/components/login.component.html',
    styleUrls: ['app/components/login.component.css']
})
export class LoginComponent {
    loginInfo:LoginModel;

    constructor(private authClient:AuthClient,
                private router: Router,
                private userContext: UserContext
    ) {
        this.loginInfo = new LoginModel();
    }

    onSubmit() {
        this.authClient.login(this.loginInfo)
            .then((user:User) => {
                this.userContext.updateCurrentUser(user.id, user.name);

                let link = ['/dashboard'];
                this.router.navigate(link);
            },(error) => {
                //handle error later
            });
    }
}