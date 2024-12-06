import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { TextInputComponent } from '../../../forms/text-input/text-input.component';
import { DateInputComponent } from '../../../forms/date-input/date-input.component';
import { ProjectService } from '../../../services/project.service';
import { IProject } from '../../../models/projectModels/iproject';

@Component({
  selector: 'app-edit-project',
  standalone: true,
  imports: [FormsModule, CommonModule, TextInputComponent, ReactiveFormsModule, DateInputComponent],
  templateUrl: './edit-project.component.html',
  styleUrl: './edit-project.component.css'
})
export class EditProjectComponent implements OnInit{
  maxDate:Date = new Date();
  project:IProject | null = null;
  validationErrors:any = [];
  projectForm:FormGroup = new FormGroup({});
  constructor(private projectService:ProjectService, private fb:FormBuilder, private router:Router,
    private toastr:ToastrService, private activatedRoute:ActivatedRoute){}

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm(){
    const id = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    this.projectService.getProject(id).subscribe(response => {
      this.project = response.data;
      if(this.project){
        this.projectForm = this.fb.group({
          id: [this.project.id, Validators.required],
          name: [this.project.name, Validators.required],
          description: [this.project.description, Validators.required],
          startDate: [new Date(this.project.startDate), Validators.required],
          endDate: [new Date(this.project.endDate), Validators.required]
        })
      }
    });
  }

  editProject(){
    this.projectService.editProject(this.projectForm.value).subscribe({
      next: () => {
        this.router.navigateByUrl('/projects');
        this.toastr.success('Project is updated');
      },
      error: (err:any) => {
        this.validationErrors = err;
        this.toastr.error('Failed to update project');
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
