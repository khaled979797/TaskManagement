import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { IProject } from '../../../models/projectModels/iproject';
import { ProjectService } from '../../../services/project.service';

@Component({
  selector: 'app-project-list',
  standalone: true,
  imports: [RouterLink, CommonModule],
  templateUrl: './project-list.component.html',
  styleUrl: './project-list.component.css'
})
export class ProjectListComponent implements OnInit {
  projects:IProject[] = {} as IProject[];
  constructor(private projectService:ProjectService, private toastr:ToastrService){}

  ngOnInit(): void {
    this.getAllProjects();
  }

  getAllProjects(){
    this.projectService.getProjects().subscribe(response => this.projects = response.data);
  }

  deleteProject(id:number){
    this.projectService.deleteProject(id).subscribe({
      next: () => {
        this.toastr.success('Project is deleted');
        this.getAllProjects();
      },
      error: () => this.toastr.error('Failed to deleted project')
    });
  }
}

