import {Component} from "angular2/core";
import {LoginModel} from "../viewModels/LoginModel";
import {AuthClient} from "../clients/AuthClient";
import { Router } from 'angular2/router';
import { UserContext } from '../services/UserContext';
import {User} from '../models/User';

@Component({
    selector: 'login',
    templateUrl: 'app/components/login.component.html'
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
                this.userContext.currentUser = user;

                let link = ['Dashboard'];
                this.router.navigate(link);
            },(error) => {
                //handle error later
            });
    }
}