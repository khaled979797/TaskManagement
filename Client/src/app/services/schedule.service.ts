import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IAddSchedule } from '../models/scheduleModels/add-schedule';
import { IResponse } from '../models/iresponse';
import { environment } from '../../environments/environment.development';
import { IEditSchedule } from '../models/scheduleModels/edit-schedule';
import { ISchedule } from '../models/scheduleModels/schedule';

@Injectable({
  providedIn: 'root'
})
export class ScheduleService {

  constructor(private http:HttpClient) {}

  addSchedule(schedule:IAddSchedule){
    return this.http.post<IResponse<string>>(environment.apiUrl + 'Schedule/AddSchedule', schedule);
  }

  editSchedule(schedule:IEditSchedule){
    return this.http.put<IResponse<string>>(environment.apiUrl + 'Schedule/EditSchedule', schedule);
  }

  getSchedulesByUser(userId:number){
    return this.http.get<IResponse<ISchedule[]>>(environment.apiUrl + `Schedule/GetAllSchedulesForUser/${userId}`);
  }

  getSchedules(){
    return this.http.get<IResponse<ISchedule[]>>(environment.apiUrl + 'Schedule/GetAllSchedules');
  }

  getSchedule(id:number){
    return this.http.get<IResponse<ISchedule>>(environment.apiUrl + `Schedule/GetScheduleById/${id}`);
  }

  deleteSchedule(id:number){
    return this.http.delete<IResponse<string>>(environment.apiUrl + `Schedule/DeleteScheduleById/${id}`);
  }
}
