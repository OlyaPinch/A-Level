import {
    action, makeAutoObservable,
    makeObservable,
    observable,
    runInAction,
} from "mobx";
import {IResource} from "../../interfaces/resources";
import * as resourceApi from "../../api/modules/resources";
import AuthStore from "../../stores/AuthStore";


class ResourceStore {

    private authStore: AuthStore;

    name = '';
    year: number = 0;
    pantone_value = " ";
    color = "";

    error = '';
    isLoading = false;

    constructor(authStore: AuthStore) {
        this.authStore = authStore;
        makeAutoObservable(this);
    }

    changeName(name: string) {
        this.name = name;
        if (!!this.error) {
            this.error = '';
        }
    }

    changeYear(year: number) {
        this.year = year;
        if (!!this.error) {
            this.error = '';
        }
    }

    changeColor(color: string): void {
        this.color = color;
        if (!!this.error) {
            this.error = '';

        }
    }

    async update(id: string) {
        try {
            this.isLoading = true;
            const resourse = {
                name: this.name,
                year: this.year,
                pantone_value: this.pantone_value,

            }
            await resourceApi.update(resourse as IResource);
            alert(" your changes sucsesfull")
        } catch (e) {
            if (e instanceof Error) {
                this.error = e.message;
            }
        }
        this.isLoading = false;
    }
}

export default ResourceStore;