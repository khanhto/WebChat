export class ChatMessage {
    public userid:number;
    public message:string;

    constructor(userid:number,message:string) {
        this.userid = userid;
        this.message = message;
    }
}