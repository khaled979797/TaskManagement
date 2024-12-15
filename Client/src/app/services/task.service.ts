import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { IResponse } from '../models/iresponse';
import { ITask } from '../models/taskModels/itask';
import { IAddTask } from '../models/taskModels/iadd-task';
import { IEditTask } from '../models/taskModels/iedit-task';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  constructor(private http:HttpClient) { }

  addTask(task:IAddTask){
    return this.http.post<IResponse<string>>(environment.apiUrl + 'Assignment/AddAssignment', task)
  }

  editTask(task:IEditTask){
    return this.http.put<IResponse<string>>(environment.apiUrl + 'Assignment/EditAssignment', task)
  }

  getTasks(){
    return this.http.get<IResponse<ITask[]>>(environment.apiUrl + 'Assignment/GetAllAssignments')
  }

  getTasksByUser(id:number){
    return this.http.get<IResponse<ITask[]>>(environment.apiUrl + `Assignment/GetAllAssignmentsByUser/${id}`)
  }

  getTask(id:number){
    return this.http.get<IResponse<ITask>>(environment.apiUrl + `Assignment/GetAssignmentById/${id}`)
  }

  deleteTask(id:number){
    return this.http.delete<IResponse<string>>(environment.apiUrl + `Assignment/DeleteAssignmentById/${id}`)
  }

  markTaskCompleted(id:number){
    return this.http.patch<IResponse<ITask>>(environment.apiUrl + `Assignment/MarkAssignmentCompleted/${id}`, {})
  }

  markTaskUncompleted(id:number){
    return this.http.patch<IResponse<ITask>>(environment.apiUrl + `Assignment/MarkAssignmentUncompleted/${id}`, {})
  }
}

