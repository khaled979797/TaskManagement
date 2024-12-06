import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { TextInputComponent } from '../../../forms/text-input/text-input.component';
import { DateInputComponent } from '../../../forms/date-input/date-input.component';
import { ITask } from '../../../models/taskModels/itask';
import { TaskService } from '../../../services/task.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { IUser } from '../../../models/userModels/iuser';
import { IProject } from '../../../models/projectModels/iproject';
import { UserService } from '../../../services/user.service';
import { ProjectService } from '../../../services/project.service';
import { take } from 'rxjs';
import { Priority } from '../../../models/enums/priority';
import { Status } from '../../../models/enums/status';
import { IAddTask } from '../../../models/taskModels/iadd-task';

@Component({
  selector: 'app-add-task',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule, TextInputComponent, DateInputComponent],
  templateUrl: './add-task.component.html',
  styleUrl: './add-task.component.css'
})
export class AddTaskComponent implements OnInit{
  priorities = Object.keys(Priority).filter(key => isNaN(Number(key))).map(key => ({ key, value: Priority[key as keyof typeof Priority] }));
  statuses = Object.keys(Status).filter(key => isNaN(Number(key))).map(key => ({ key, value: Status[key as keyof typeof Status] }));
  user:IUser = {} as IUser;
  projects:IProject[] = {} as IProject[];
  validationErrors:any = [];
  taskForm:FormGroup = new FormGroup({});
  constructor(private taskService:TaskService, private fb:FormBuilder, private router:Router,
    private toastr:ToastrService, private userService:UserService){}

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm(){
    this.userService.currentUser$.pipe(take(1)).subscribe(user => this.user = <IUser>user);
    this.taskForm = this.fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      dueDate: ['', Validators.required],
      priority: [this.priorities[0].value, Validators.required],
      status: [this.statuses[0].value, Validators.required],
      userId: [this.user.id, Validators.required],
    });
  }

  addTask(){
    this.taskService.addTask(this.taskForm.value).subscribe({
      next: () => {
        this.router.navigateByUrl('/tasks');
        this.toastr.success('Task is added');
      },
      error: (err:any) => {
        this.validationErrors = err;
        this.toastr.error('Failed to add task');
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
