import { Component, OnInit } from '@angular/core';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { UserService } from '../../../services/user.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ILoginUser } from '../../../models/userModels/ilogin-user';
import { Router, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HasRoleDirective } from '../../../directives/has-role.directive';
import { INotification } from '../../../models/notificationModels/notification';
import { NotificationService } from '../../../services/notification.service';
import { IUser } from '../../../models/userModels/iuser';
import { take } from 'rxjs';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink, BsDropdownModule, HasRoleDirective],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css',
  providers: []
})
export class NavComponent implements OnInit{
  loginModel:ILoginUser = {} as ILoginUser;
  notifications?:INotification[];
  user:IUser= {} as IUser;
  constructor(public userService:UserService, private router:Router, private toastr:ToastrService,
    public notificationService:NotificationService
  ){}

  ngOnInit(): void {
    this.loadNotifications();
  }

  login(){
    this.userService.login(this.loginModel).subscribe({
      next: () => this.router.navigateByUrl('/'),
      error: (err:any) => this.toastr.error('Username or password are wrong')
    });
  }

  logout(){
    this.userService.logout();
  }

  loadNotifications(){
    this.userService.currentUser$.pipe(take(1)).subscribe(user =>{
      this.user = <IUser>user;
      this.notificationService.getNotificationsByUser(this.user.id).subscribe(response =>{
        this.notifications = response.data;
      });
    })
  }

  deleteNotification(id:number){
    this.notificationService.deleteNotification(id).subscribe({
      next: () => {
        this.toastr.success('Notification is deleted'),
        this.loadNotifications();
      },
      error: () => this.toastr.error('Failed to delete notification')
    })
  }

  deleteAllNotifications(){
    this.notificationService.deleteNotificationsByUser(this.user.id).subscribe({
      next: () => {
        this.toastr.success('Notifications is deleted'),
        this.loadNotifications();
      },
      error: () => this.toastr.error('Failed to delete notifications')
    })
  }

  readNotification(id:number){
    this.notificationService.markNotificationRead(id).subscribe({
      next: () => {
        this.toastr.success('Notification is read'),
        this.loadNotifications();
      },
      error: () => this.toastr.error('Failed to read notification')
    })
  }

  readAllNotifications(){
    this.notificationService.markNotificationsRead(this.user.id).subscribe({
      next: () => {
        this.toastr.success('Notifications is read'),
        this.loadNotifications();
      },
      error: () => this.toastr.error('Failed to read notifications')
    })
  }

  unreadNotification(id:number){
    this.notificationService.markNotificationUnread(id).subscribe({
      next: () => {
        this.toastr.success('Notification is unread'),
        this.loadNotifications();
      },
      error: () => this.toastr.error('Failed to unread notification')
    })
  }

  unreadAllNotifications(){
    this.notificationService.markNotificationsUnread(this.user.id).subscribe({
      next: () => {
        this.toastr.success('Notifications is unread'),
        this.loadNotifications();
      },
      error: () => this.toastr.error('Failed to unread notifications')
    })
  }
}
