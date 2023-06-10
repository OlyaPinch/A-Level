import apiClient from "../client";
import {IUser} from "../../interfaces/users";

export const getById = (id: string) => apiClient({
  path: `users/${id}`,
  method: 'GET'
})

export const getByPage = (page: number) => apiClient({
  path: `users?page=${page}`,
  method: 'GET'
})
export const updateUser = (id: string, user:any) => apiClient({
      path: `users/${id}`,
  method: 'POST'
})