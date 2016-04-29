import {Component} from "angular2/core";
import {LoginModel} from "../viewModels/LoginModel";

@Component({
    selector: 'login',
    templateUrl: 'app/components/login.component.html'
})
export class LoginComponent {
    loginInfo:LoginModel;

    constructor() {
        this.loginInfo = new LoginModel();
    }
}