import { Component } from "angular2/core";
import { ChatHub } from "../clients/ChatHub";
import { OnInit, OnDestroy } from 'angular2/core';
import { UsersClient } from "../clients/UsersClient";
import {User} from "../models/User";
import {ChatThread} from "../viewModels/ChatThread";
import {ChatMessage} from "../viewModels/ChatMessage";

@Component({
    selector: 'dashboard',
    templateUrl: 'app/components/dashboard.component.html'
})
export class DashboardComponent implements OnInit, OnDestroy {
    constructor(private chatHub:ChatHub,
                private usersClient:UsersClient) { 
        this.connectionEstablished = false;
        this.chatThreads = {};
    }

    public friends:User[];
    public currentFriend:User;

    public chatThreads: { [friendid: string] : ChatThread; }
    public currentChatThread: ChatThread;

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

    onFriendSelected(friend:User) {
        this.currentFriend = friend;

        if (!this.chatThreads[friend.id]) {
            this.chatThreads[friend.id] = new ChatThread();
        }

        this.currentChatThread = this.chatThreads[friend.id];
    }

    onChatMessageSubmit() {
        this.chatHub.Send(new ChatMessage(this.currentFriend.id,this.currentChatThread.unsentMessage)).then(() => {
            this.currentChatThread.unsentMessage = "";
        });
    }
}