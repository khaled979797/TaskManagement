import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { IAddProject } from '../models/projectModels/iadd-project';
import { IProject } from '../models/projectModels/iproject';
import { IResponse } from '../models/iresponse';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  constructor(private http:HttpClient) {}

  addProject(project:IAddProject){
    return this.http.post<IResponse<string>>(environment.apiUrl + 'Project/AddProject', project);
  }

  editProject(project:IProject){
    return this.http.put<IResponse<string>>(environment.apiUrl + 'Project/EditProject', project);
  }

  getProjects(){
    return this.http.get<IResponse<IProject[]>>(environment.apiUrl + 'Project/GetAllProjects');
  }

  getProject(id:number){
    return this.http.get<IResponse<IProject>>(environment.apiUrl + `Project/GetProjectById/${id}`);
  }

  deleteProject(id:number){
    return this.http.delete<IResponse<string>>(environment.apiUrl + `Project/DeleteProjectById/${id}`);
  }
}
