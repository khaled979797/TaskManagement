import { Component, OnInit } from '@angular/core';
import { ScheduleService } from '../../../services/schedule.service';
import { ISchedule } from '../../../models/scheduleModels/schedule';
import { IUser } from '../../../models/userModels/iuser';
import { UserService } from '../../../services/user.service';
import { take } from 'rxjs';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-schedule-list',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './schedule-list.component.html',
  styleUrl: './schedule-list.component.css'
})
export class ScheduleListComponent implements OnInit{
  schedules?:ISchedule[];
  user:IUser = {} as IUser;
  constructor(private scheduleService:ScheduleService, private userService:UserService, private toastr:ToastrService){}
  ngOnInit(): void {
    this.loadSchedules();
  }

  loadSchedules(){
    this.userService.currentUser$.pipe(take(1)).subscribe(user =>{
      this.user = <IUser>user;
      this.scheduleService.getSchedulesByUser(this.user.id).subscribe(response => this.schedules = response.data);
    })
  }

  deleteSchedule(id:number){
    this.scheduleService.deleteSchedule(id).subscribe({
      next: () => {
        this.toastr.success('Schedule is deleted');
        this.loadSchedules();
      },
      error: () => this.toastr.error('Failed to deleted schedule')
    });
  }
}
