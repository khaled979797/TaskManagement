import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { TextInputComponent } from '../../../forms/text-input/text-input.component';
import { DateInputComponent } from '../../../forms/date-input/date-input.component';
import { IUser } from '../../../models/userModels/iuser';
import { ScheduleService } from '../../../services/schedule.service';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../../../services/user.service';
import { take } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-schedule',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule, TextInputComponent, DateInputComponent],
  templateUrl: './add-schedule.component.html',
  styleUrl: './add-schedule.component.css'
})
export class AddScheduleComponent {
  user:IUser = {} as IUser;
  validationErrors:any = [];
  scheduleForm:FormGroup = new FormGroup({});
  constructor(private scheduleService:ScheduleService, private fb:FormBuilder, private router:Router,
    private toastr:ToastrService, private userService:UserService){}

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm(){
    this.userService.currentUser$.pipe(take(1)).subscribe(user =>{
      this.user = <IUser>user;
      this.scheduleForm = this.fb.group({
        message: ['', Validators.required],
        notifyDate: ['', Validators.required],
        userId: [this.user.id, Validators.required]
      })
    })
  }

  addSchedule(){
    this.scheduleService.addSchedule(this.scheduleForm.value).subscribe({
      next: () => {
        this.router.navigateByUrl('/schedules');
        this.toastr.success('Schedule is added');
      },
      error: (err:any) => {
        this.validationErrors = err;
        this.toastr.error('Failed to add schedule');
      }
    });
  }

  get message(){
    return this.scheduleForm.get('message') as FormControl;
  }
  get notifyDate(){
    return this.scheduleForm.get('notifyDate') as FormControl;
  }
}
