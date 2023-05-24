import { makeAutoObservable} from "mobx";
import * as authApi from "../api/modules/auth";

class AuthStore {
    token = "";

        IsLoginet():boolean{
        return this.token!=='';
    }
    constructor() {
        makeAutoObservable(this);
    }
    logout() {
        this.token = '';
    }

    async login(email: string, password: string) {
        const result = await authApi.login({email, password});
        this.token = result.token;
    }
}

export default AuthStore;