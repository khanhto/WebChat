declare var $: any;

import {BaseHub} from './BaseHub';
import {Injectable} from '@angular/core';
import {Response} from '@angular/http';
import {Observable} from 'rxjs/Observable';
import {ChatMessage} from "../viewModels/ChatMessage";

@Injectable()
export class ChatHub extends BaseHub {
    private $chatHub;

    public incomingMessages: Observable<ChatMessage>;

    constructor() {
        super($.connection.chatHub.connection);
        this.$chatHub = $.connection.chatHub;

        this.incomingMessages = new Observable<ChatMessage>(observer => {
            this.$chatHub.client.onMessageReceived = (message:ChatMessage) => {
                observer.next(message);
            };
        });
    }

    public Send(message:ChatMessage):Promise<Response> {
        return new Promise((resolve, reject) => {
            this.$chatHub.server.send(message).done(() => resolve())
                                                        .fail(() => reject());
        });
    } 
}