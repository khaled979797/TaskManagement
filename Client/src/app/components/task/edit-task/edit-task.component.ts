import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { TextInputComponent } from '../../../forms/text-input/text-input.component';
import { DateInputComponent } from '../../../forms/date-input/date-input.component';
import { IProject } from '../../../models/projectModels/iproject';
import { ActivatedRoute, Router } from '@angular/router';
import { TaskService } from '../../../services/task.service';
import { take } from 'rxjs';
import { ProjectService } from '../../../services/project.service';
import { IUser } from '../../../models/userModels/iuser';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../../../services/user.service';
import { Priority } from '../../../models/enums/priority';
import { Status } from '../../../models/enums/status';
import { ITask } from '../../../models/taskModels/itask';
import { response } from 'express';

@Component({
  selector: 'app-edit-task',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule, TextInputComponent, DateInputComponent],
  templateUrl: './edit-task.component.html',
  styleUrl: './edit-task.component.css'
})
export class EditTaskComponent implements OnInit{
  priorities = Object.keys(Priority).filter(key => isNaN(Number(key))).map(key => ({ key, value: Priority[key as keyof typeof Priority] }));
  statuses = Object.keys(Status).filter(key => isNaN(Number(key))).map(key => ({ key, value: Status[key as keyof typeof Status] }));
  user:IUser = {} as IUser;
  projects:IProject[] = {} as IProject[];
  task:ITask = {} as ITask;
  validationErrors:any = [];
  taskForm:FormGroup = new FormGroup({});
  constructor(private taskService:TaskService, private fb:FormBuilder, private router:Router,
    private toastr:ToastrService, private userService:UserService, private activatedRoute:ActivatedRoute){}

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm(){
    this.userService.currentUser$.pipe(take(1)).subscribe(user => this.user = <IUser>user);
    const id = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    this.taskService.getTask(id).subscribe(response => {
      this.task = response.data;
      if(this.task){
        var priorityIndex = -1;
        switch(this.task.priority){
          case 'Low': priorityIndex = 0; break;
          case 'Medium': priorityIndex = 1; break;
          case 'High': priorityIndex = 2; break;
        }
        var statusIndex = -1;
        switch(this.task.status){
          case 'Running': statusIndex = 0; break;
          case 'Completed': statusIndex = 1; break;
        }
        this.taskForm = this.fb.group({
          id: [this.task.id, Validators.required],
          title: [this.task.title, Validators.required],
          description: [this.task.description, Validators.required],
          dueDate: [new Date(this.task.dueDate), Validators.required],
          priority: [this.priorities[priorityIndex].value, Validators.required],
          status: [this.statuses[statusIndex].value, Validators.required],
          userId: [this.user.id, Validators.required]
        });
      }
    })
  }

  editTask(){
    this.taskService.editTask(this.taskForm.value).subscribe({
      next: () => {
        this.router.navigateByUrl('/tasks');
        this.toastr.success('Task is updated');
      },
      error: (err:any) => {
        this.validationErrors = err;
        this.toastr.error('Failed to update task');
      }
    });
  }

  get title(){
    return this.taskForm.get('title') as FormControl;
  }
  get description(){
    return this.taskForm.get('description') as FormControl;
  }
  get dueDate(){
    return this.taskForm.get('dueDate') as FormControl;
  }
  get priority(){
    return this.taskForm.get('priority') as FormControl;
  }
  get status(){
    return this.taskForm.get('status') as FormControl;
  }
}
