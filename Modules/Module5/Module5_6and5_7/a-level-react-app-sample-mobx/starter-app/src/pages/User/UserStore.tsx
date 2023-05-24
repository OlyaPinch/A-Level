import {
    action, makeAutoObservable,
    makeObservable,
    observable,
    runInAction,
} from "mobx";
import {IUser} from "../../interfaces/users";

import * as userApi from "../../api/modules/users";
import AuthStore from "../../stores/AuthStore";
import {updateUser} from "../../api/modules/users";



class UserStore {

   // private userApi: AuthStore;

     email = '';
     firstName:string='';
     lastName:string='';
    
    error = '';
    isLoading = false;
  //  public user: IUser | null = null;
        

    
    

    constructor(authStore: AuthStore) {
     //   this.authStore = authStore;
        makeAutoObservable(this);
       
    }
    
    getEmail():string{
        return this.email;
    }
  setUser(user:IUser) {
        this.email = user.email;
  }
  
  
 async getUser(id:string){
      const res = await userApi.getById(id)
     var user = res.data;
      this.email = user.email;

  }
  
  

 

    async update(id:string) {
        try {
            this.isLoading = true;
            const user  ={
                email:this.email,
                last_name:this.lastName,
                first_name:this.firstName,
               
            }
            await userApi.updateUser(id,user);
        
        }
        catch (e) {
            if (e instanceof Error) {
                this.error = e.message;
            }
        }
        this.isLoading = false;
    }
}

export default UserStore;