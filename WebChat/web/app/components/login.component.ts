import {Component} from "angular2/core";
import {LoginModel} from "../viewModels/LoginModel";
import {AuthClient} from "../clients/AuthClient";
import { Router } from 'angular2/router';

@Component({
    selector: 'login',
    templateUrl: 'app/components/login.component.html'
})
export class LoginComponent {
    loginInfo:LoginModel;

    constructor(private authClient:AuthClient,
                private router: Router
    ) {
        this.loginInfo = new LoginModel();
        this.authClient = authClient;
    }

    onSubmit() {
        this.authClient.login(this.loginInfo)
            .then((response) => {
                let link = ['Dashboard'];
                this.router.navigate(link);
            },(error) => {
                //handle error later
            });
    }
}