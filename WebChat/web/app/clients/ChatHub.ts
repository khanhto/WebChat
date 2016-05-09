declare var $: any;

import {BaseHub} from './BaseHub';
import {Injectable} from 'angular2/core';

@Injectable()
export class ChatHub extends BaseHub {
    private $chatHub;

    constructor() {
        super($.connection.chatHub.connection);
        this.$chatHub = $.connection.chatHub;

        //add this temporarily to allow connection from JS
        this.$chatHub.client.addNewMessageToPage = function(){ };
    }
}