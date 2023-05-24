// pages
import Home from "./pages/Home";
import About from "./pages/About";
import Products from "./pages/Products";
import User from "./pages/User";

// other
import {FC} from "react";
import Login from "./pages/Login";
import Resources from "./pages/Resources";
import Resource from "./pages/Resource";
import Registration from "./pages/Registration";
import AuthStore from "./stores/AuthStore";

// interface
interface Route {
    key: string,
    title: string,
    path: string,
    enabled: boolean,
    isPrivate:boolean,
    component: FC<{}>
}

export const routes: Array<Route> = [
    {
        key: 'home-route',
        title: 'Home',
        path: '/',
        enabled: true,
        isPrivate:false,
        component: Home
    },
    {
        key: 'about-route',
        title: 'About',
        path: '/about',
        enabled: true,
        isPrivate:false,
        component: About
    },
    {
        key: 'products-route',
        title: 'Products',
        path: '/products',
        enabled: true,
        isPrivate:false,
        component: Products
    },
    {
        key: 'user-route',
        title: 'User',
        path: '/user/:id',
        enabled: false,
        isPrivate:false,
        component: User
    },    
    {
        key: 'resource-route',
        title: 'Resource',
        path: '/resource/:id',
        enabled: false,
        isPrivate:false,
        component: Resource
    },
    {
        key: 'Resources-route',
        title: 'Resources',
        path: '/resources',
        enabled: true,
        isPrivate:false,
        component: Resources
    },
    
    {
        key: 'login-route',
        title: 'Login',
        path: '/login',
        enabled: true,
        isPrivate:false,
        component: Login
    },
    {
        key: 'registration-route',
        title: 'Registration',
        path: '/registration',
        enabled: true,
        isPrivate:false,
        component: Registration
    },
    {
        key: 'logout-route',
        title: 'Logout',
        path: '/loguot',
        enabled: true,
        isPrivate: true,
        component: Registration
    }
    
    
    
    
]