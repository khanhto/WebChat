import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { HttpModule }    from '@angular/http';
import { AppComponent }   from './components/app.component';
import { LoginComponent }   from './components/login.component';
import { DashboardComponent }   from './components/dashboard.component';
import { routing,
         appRoutingProviders }  from './app.routing';

@NgModule({
  imports:      [ BrowserModule, FormsModule, HttpModule, routing ],
  declarations: [ AppComponent, LoginComponent, DashboardComponent ],
  providers: [
    appRoutingProviders
  ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
