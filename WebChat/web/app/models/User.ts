export class User {
    public id:number;
    public name:string;

    public isAuthenticated(): boolean {
        return this.id != 0;
    }
}