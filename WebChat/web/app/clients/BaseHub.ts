import {Response} from '@angular/http';

export abstract class BaseHub {
    
    constructor(private $connection) { }

    public Start():Promise<Response> {
        return new Promise((resolve, reject) => {
            this.$connection.start()
                       .done(() => resolve())
                       .fail(() => reject());
        });
    }

    public Stop() {
        this.$connection.stop();
    }
}