import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ProjectService } from '../../services/project.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { IProject } from '../../models/projectModels/iproject';
import { CommonModule } from '@angular/common';
import { TextInputComponent } from '../../forms/text-input/text-input.component';
import { DateInputComponent } from '../../forms/date-input/date-input.component';

@Component({
  selector: 'app-add-project',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule, TextInputComponent, DateInputComponent],
  templateUrl: './add-project.component.html',
  styleUrl: './add-project.component.css'
})
export class AddProjectComponent {
  maxDate:Date = new Date();
  user:IProject = {} as IProject;
  validationErrors:any = [];
  projectForm:FormGroup = new FormGroup({});
  constructor(private projectService:ProjectService, private fb:FormBuilder, private router:Router, private toastr:ToastrService){}

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm(){
    this.projectForm = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required]
    })
  }

  addProject(){
    this.projectService.addProject(this.projectForm.value).subscribe({
      next: () => {
        this.router.navigateByUrl('/projects');
        this.toastr.success('Project is added');
      },
      error: (err:any) => {
        this.validationErrors = err;
        this.toastr.error('Failed to add project');
      }
    });
  }

  get name(){
    return this.projectForm.get('name') as FormControl;
  }
  get description(){
    return this.projectForm.get('description') as FormControl;
  }
  get startDate(){
    return this.projectForm.get('startDate') as FormControl;
  }

  get endDate(){
    return this.projectForm.get('endDate') as FormControl;
  }
}
