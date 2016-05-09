import {Component} from "angular2/core";
import { RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS } from 'angular2/router';
import {LoginComponent} from './login.component';
import {DashboardComponent} from './dashboard.component';
import {UserContext} from '../services/UserContext';
import {AuthClient} from '../clients/AuthClient';
import {ChatHub} from '../clients/ChatHub';

@Component({
    selector: 'app',
    template: '<router-outlet></router-outlet>',
    directives: [ROUTER_DIRECTIVES],
    providers: [
        ROUTER_PROVIDERS,
        UserContext,
        AuthClient,
        ChatHub
    ]
})
@RouteConfig([
    {
        path: '/login',
        name: 'Login',
        component: LoginComponent,
        useAsDefault: true
    },
    {
        path: '/dashboard',
        name: 'Dashboard',
        component: DashboardComponent
    }
])
export class AppComponent { }