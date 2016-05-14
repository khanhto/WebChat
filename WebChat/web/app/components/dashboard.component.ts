import { Component } from "angular2/core";
import { ChatHub } from "../clients/ChatHub";
import { OnInit, OnDestroy } from 'angular2/core';
import { UsersClient } from "../clients/UsersClient";
import {User} from "../models/User";

@Component({
    selector: 'dashboard',
    templateUrl: 'app/components/dashboard.component.html'
})
export class DashboardComponent implements OnInit, OnDestroy {
    constructor(private chatHub:ChatHub,
                private usersClient:UsersClient) { 
        this.connectionEstablished = false;
    }

    public friends:User[];
    private connectionEstablished:boolean;

    ngOnInit() { 
        this.chatHub.Start()
           .then(() => {
               this.connectionEstablished = true;
               return this.usersClient.getFriends();
           })
           .then((friends:User[]) => {
                this.friends = friends;
           });
    }

    ngOnDestroy() { 
        this.chatHub.Stop();
    }
}