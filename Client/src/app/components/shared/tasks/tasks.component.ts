import { Component, OnInit } from '@angular/core';
import { TaskService } from '../../../services/task.service';
import { ToastrService } from 'ngx-toastr';
import { ITask } from '../../../models/taskModels/itask';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-tasks',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './tasks.component.html',
  styleUrl: './tasks.component.css'
})
export class TasksComponent implements OnInit{
  tasks:ITask[] = {} as ITask[];
  constructor(private taskService:TaskService, private toastr:ToastrService){}

  ngOnInit(): void {
    this.getTasks();
  }

  getTasks(){
    this.taskService.getTasks().subscribe(response => this.tasks = response.data);
  }

  addComment(id:number){

  }

  addAttachment(id:number){

  }
}
