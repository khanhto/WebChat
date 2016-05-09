import { Component } from "angular2/core";
import { ChatHub } from "../clients/ChatHub";
import { OnInit, OnDestroy } from 'angular2/core';

@Component({
    selector: 'dashboard',
    templateUrl: 'app/components/dashboard.component.html'
})
export class DashboardComponent implements OnInit, OnDestroy {
    constructor(private chatHub:ChatHub){ }

    ngOnInit() { 
        this.chatHub.Start();
    }

    ngOnDestroy() { 
        this.chatHub.Stop();
    }
}