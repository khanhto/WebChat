import {Response} from 'angular2/http';

export abstract class BaseHub {
    
    constructor(private $connection) { }

    public Start():Promise<Response> {
        return new Promise((resolve, reject) => {
            this.$connection.start()
                       .done(() => resolve())
                       .fail(() => reject());
        });
    }

    public Stop():Promise<Response> {
        return new Promise((resolve, reject) => {
            this.$connection.stop()
                       .done(() => resolve())
                       .fail(() => reject());
        });
    }
}