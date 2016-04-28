import {Component} from "angular2/core";
import { RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS } from 'angular2/router';
import {LoginComponent} from './login.component';
import {DashboardComponent} from './dashboard.component';
import {UserContext} from '../services/UserContext';

@Component({
    selector: 'app',
    template: '<router-outlet></router-outlet>',
    directives: [ROUTER_DIRECTIVES],
    providers: [
        ROUTER_PROVIDERS,
        UserContext
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