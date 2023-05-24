import {
    action, makeAutoObservable,
    makeObservable,
    observable,
    runInAction,
} from "mobx";
import {IResource} from "../../interfaces/resources";
import * as resourcesApi from "../../api/modules/resources";


class ResourcesStore {
    resources: IResource[] = [];
    totalPages = 0;
    currentPage = 1;
    isLoading = false;

    constructor() {
        // makeObservable(this, {
        //     users: observable,
        //     totalPages: observable,
        //     currentPage: observable,
        //     isLoading: observable,
        //     changePage: action,
        // });
        makeAutoObservable(this);
        runInAction(this.prefetchData);
    }

   async changePage(page: number) {
        this.currentPage = page;
        await this.prefetchData();
    }

    prefetchData = async () => {
        try {
            this.isLoading = true;
            const res = await resourcesApi.getByPage(this.currentPage)
            this.resources = res.data;
            this.totalPages = res.total_pages;
        } catch (e) {
            if (e instanceof Error) {
                console.error(e.message)
            }
        }
        this.isLoading = false;
    };
}

export default ResourcesStore;