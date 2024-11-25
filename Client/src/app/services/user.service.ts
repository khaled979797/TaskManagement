import { Injectable } from '@angular/core';
import { IResponse } from '../models/iresponse';
import { environment } from '../../environments/environment.development';
import { IUser } from '../models/userModels/iuser';
import { IEditUser } from '../models/userModels/iedit-user';
import { IRegisterUser } from '../models/userModels/iregister-user';
import { BehaviorSubject, map } from 'rxjs';
import { ILoginUser } from '../models/userModels/ilogin-user';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private currentUserSource = new BehaviorSubject<IUser | null>(null);
  currentUser$ = this.currentUserSource.asObservable();
  constructor(private http:HttpClient) {}

  setCurrentUser(user:IUser){
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  login(loginModel:ILoginUser){
    return this.http.post<IResponse<IUser>>(environment.apiUrl + 'User/Login', loginModel).pipe(
      map((response: IResponse<IUser>) =>{
        if(response.data) this.setCurrentUser(response.data);
      })
    );
  }

  register(registerModel:IRegisterUser){
    return this.http.post<IResponse<IUser>>(environment.apiUrl + 'User/Register', registerModel).pipe(
      map((response:IResponse<IUser>) =>{
        if(response.data) this.setCurrentUser(response.data);
      })
    );
  }

  logout(){
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }

  getUsers(){
    return this.http.get<IResponse<IUser[]>>(environment.apiUrl + 'User/GetAllUsers');
  }

  getUser(id:number){
    return this.http.get<IResponse<IUser>>(environment.apiUrl + `User/GetUserById/${id}`);
  }

  editUser(editModel:IEditUser){
    return this.http.put<IResponse<string>>(environment.apiUrl + 'User/EditUser', editModel);
  }

  deleteUser(id:number){
    return this.http.delete<IResponse<string>>(environment.apiUrl + `User/DeleteUserById/${id}`);
  }
}
