import { Component, OnInit } from '@angular/core';
import { ITask } from '../../../models/taskModels/itask';
import { TaskService } from '../../../services/task.service';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { RouterLink } from '@angular/router';
import { Priority } from '../../../models/enums/priority';
import { Status } from '../../../models/enums/status';
import { UserService } from '../../../services/user.service';
import { IUser } from '../../../models/userModels/iuser';
import { take } from 'rxjs';

@Component({
  selector: 'app-task-list',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './task-list.component.html',
  styleUrl: './task-list.component.css'
})
export class TaskListComponent implements OnInit{
  tasks:ITask[] = {} as ITask[];
  user:IUser = {} as IUser;
  constructor(private taskService:TaskService, private toastr:ToastrService, private userService:UserService){}

  ngOnInit(): void {
    this.getTasks();
  }

  getTasks(){
    this.userService.currentUser$.pipe(take(1)).subscribe(user =>{
      this.user = <IUser>user;
      this.taskService.getTasksByUser(this.user.id).subscribe(response => this.tasks = response.data);
    })
  }

  deleteTask(id:number){
    this.taskService.deleteTask(id).subscribe({
      next: () => {
        this.toastr.success('Task is deleted'),
        this.getTasks();
      },
      error: () => this.toastr.error('Failed to delete task')
    })
  }

  markTaskCompleted(id:number){
    this.taskService.markTaskCompleted(id).subscribe({
      next: () => {
        this.toastr.success('Task is completed'),
        this.getTasks();
      },
      error: () => this.toastr.error('Failed to update task')
    })
  }

  markTaskUncompleted(id:number){
    this.taskService.markTaskUncompleted(id).subscribe({
      next: () => {
        this.toastr.success('Task is running'),
        this.getTasks();
      },
      error: () => this.toastr.error('Failed to update task')
    })
  }
}
