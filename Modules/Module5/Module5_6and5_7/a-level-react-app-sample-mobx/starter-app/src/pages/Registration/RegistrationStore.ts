import {
    action, makeAutoObservable,
    makeObservable,
    observable,
    runInAction,
} from "mobx";
import {IUser} from "../../interfaces/users";
import * as userApi from "../../api/modules/users";
import AuthStore from "../../stores/AuthStore";
import {IRegisterUser} from "../../interfaces/RegisterUser";


class RegistrationStore {

    private authStore: AuthStore;

    email = '';
    password = '';
    confirmPassword = '';
    error = '';
    isLoading = false;

    constructor(authStore: AuthStore) {
        this.authStore = authStore;
        makeAutoObservable(this);
    }

    get passwordMatch() {
        return this.password === this.confirmPassword;
    }

   setPassword(password:string) {
        this.password = password;
    }

     setConfirmPassword(confirmPassword:string) {
        this.confirmPassword = confirmPassword;
    }
    handleSubmit() {
        if (this.passwordMatch) {
            this.isLoading=true;
        } else {
            throw "passwords is different"
        }
    }
    changeEmail(email: string) {
        this.email = email;
        if (!!this.error) {
            this.error = '';
        }
    }

    changePassword(password: string) {
        this.password = password;
        if (!!this.error) {
            this.error = '';
        }
    }

    async Registration(user:IRegisterUser) {
        try {
           if(this.isLoading ){
            
           await this.authStore.login(this.email, this.password);}
        }
        catch (e) {
            if (e instanceof Error) {
                this.error = e.message;
            }
        }
        this.isLoading = false;
    }
    
}

export default RegistrationStore;