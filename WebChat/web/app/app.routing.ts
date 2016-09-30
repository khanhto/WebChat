import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import {LoginComponent} from './components/login.component';
import {DashboardComponent} from './components/dashboard.component';
import {AuthGuard} from "./services/AuthGuard";

const appRoutes: Routes = [
    {
      path: '',
      redirectTo: '/login',
      pathMatch: 'full'
    },
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: 'dashboard',
        component: DashboardComponent
    }
];

export const appRoutingProviders: any[] = [

];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);
