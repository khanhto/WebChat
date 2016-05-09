export abstract class BaseHub {
    
    constructor(private $connection) { }

    public Start() {
        return new Promise((resolve, reject) => {
            this.$connection.start()
                       .done(() => resolve())
                       .fail(() => reject());
        });
    }

    public Stop() {
        return new Promise((resolve, reject) => {
            this.$connection.stop()
                       .done(() => resolve())
                       .fail(() => reject());
        });
    }
}