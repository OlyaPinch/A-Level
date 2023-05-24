import apiClient from "../client";
import {IResource} from "../../interfaces/resources";

export const getById = (id: string) => apiClient({
  path: `unknown/${id}`,
  method: 'GET'
})

export const getByPage = (page: number) => apiClient({
  path: `unknown?page=${page}`,
  method: 'GET'
})
export const update = (res:IResource) => apiClient({
  path:`unknown/${res.id}`,
  method: 'POST'
})
