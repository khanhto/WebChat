import {Component} from "@angular/core";
import {UserContext} from '../services/UserContext';
import {AuthClient} from '../clients/AuthClient';
import {ChatHub} from '../clients/ChatHub';
import { UsersClient } from "../clients/UsersClient";

@Component({
    selector: 'app',
    template: '<router-outlet></router-outlet>',
    providers: [
        UserContext,
        AuthClient,
        ChatHub,
        UsersClient
    ]
})

export class AppComponent { }