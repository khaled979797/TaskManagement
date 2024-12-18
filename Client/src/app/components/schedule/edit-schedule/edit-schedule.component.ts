import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { DateInputComponent } from '../../../forms/date-input/date-input.component';
import { ScheduleService } from '../../../services/schedule.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { ISchedule } from '../../../models/scheduleModels/schedule';
import { TextInputComponent } from '../../../forms/text-input/text-input.component';

@Component({
  selector: 'app-edit-schedule',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule, TextInputComponent, DateInputComponent],
  templateUrl: './edit-schedule.component.html',
  styleUrl: './edit-schedule.component.css'
})
export class EditScheduleComponent {
  schedule:ISchedule = {} as ISchedule;
  validationErrors:any = [];
  scheduleForm:FormGroup = new FormGroup({});
  constructor(private scheduleService:ScheduleService, private fb:FormBuilder, private router:Router,
    private toastr:ToastrService, private activatedRoute:ActivatedRoute){}

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm(){
    const id = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    this.scheduleService.getSchedule(id).subscribe(response => {
      this.schedule = response.data;
      if(this.schedule){
        this.scheduleForm = this.fb.group({
          id: [this.schedule.id, Validators.required],
          message: [this.schedule.message, Validators.required],
          notifyDate: [new Date(this.schedule.notifyDate), Validators.required]
        })
      }
    });
  }

  editSchedule(){
    this.scheduleService.editSchedule(this.scheduleForm.value).subscribe({
      next: () => {
        this.router.navigateByUrl('/schedules');
        this.toastr.success('Schedule is updated');
      },
      error: (err:any) => {
        this.validationErrors = err;
        this.toastr.error('Failed to update schedule');
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
