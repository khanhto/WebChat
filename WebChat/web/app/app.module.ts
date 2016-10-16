import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { HttpModule }    from '@angular/http';
import { MaterialModule } from '@angular/material';
import { AppComponent }   from './components/app.component';
import { LoginComponent }   from './components/login.component';
import { DashboardComponent }   from './components/dashboard.component';
import { routing,
         appRoutingProviders }  from './app.routing';

import {UserContext} from './services/UserContext';
import {AuthClient} from './clients/AuthClient';
import {ChatHub} from './clients/ChatHub';
import { UsersClient } from "./clients/UsersClient";

@NgModule({
  imports:      [ BrowserModule, FormsModule, HttpModule, routing, MaterialModule.forRoot() ],
  declarations: [ AppComponent, LoginComponent, DashboardComponent ],
  providers: [
    appRoutingProviders,
    UserContext,
    AuthClient,
    ChatHub,
    UsersClient
  ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
