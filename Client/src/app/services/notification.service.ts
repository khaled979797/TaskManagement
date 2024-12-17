import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IResponse } from '../models/iresponse';
import { environment } from '../../environments/environment.development';
import { IAddNotification } from '../models/notificationModels/add-notification';
import { INotification } from '../models/notificationModels/notification';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  constructor(private http:HttpClient) {}

  addNotification(notification:IAddNotification){
    return this.http.post<IResponse<string>>(environment.apiUrl + 'Notification/AddNotification', notification)
  }

  getNotificationsByUser(userId:number){
    return this.http.get<IResponse<INotification[]>>(environment.apiUrl + `Notification/GetAllNotifications/${userId}`)
  }

  getNotification(id:number){
    return this.http.get<IResponse<INotification>>(environment.apiUrl + `Notification/GetNotificationById/${id}`)
  }

  deleteNotificationsByUser(userId:number){
    return this.http.delete<IResponse<string>>(environment.apiUrl + `Notification/DeleteAllNotifications/${userId}`)
  }

  deleteNotification(id:number){
    return this.http.delete<IResponse<string>>(environment.apiUrl + `Notification/DeleteNotificationById/${id}`)
  }

  markNotificationsRead(userId:number){
    return this.http.put<IResponse<INotification[]>>(environment.apiUrl + `Notification/ReadAllNotifications/${userId}`, {})
  }

  markNotificationRead(id:number){
    return this.http.put<IResponse<INotification>>(environment.apiUrl + `Notification/ReadNotificationById/${id}`, {})
  }

  markNotificationsUnread(userId:number){
    return this.http.put<IResponse<INotification[]>>(environment.apiUrl + `Notification/UnreadAllNotifications/${userId}`, {})
  }

  markNotificationUnread(id:number){
    return this.http.put<IResponse<INotification>>(environment.apiUrl + `Notification/UnreadNotificationById/${id}`, {})
  }
}
