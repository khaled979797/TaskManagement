import { Component, OnInit } from '@angular/core';
import { TaskService } from '../../../services/task.service';
import { ActivatedRoute } from '@angular/router';
import { ITask } from '../../../models/taskModels/itask';
import { CommonModule, NgClass, NgIf } from '@angular/common';

@Component({
  selector: 'app-task-details',
  standalone: true,
  imports: [NgClass, NgIf, CommonModule],
  templateUrl: './task-details.component.html',
  styleUrl: './task-details.component.css'
})
export class TaskDetailsComponent implements OnInit{
  task:ITask = {} as ITask;
  constructor(private taskService:TaskService, private activatedRoute:ActivatedRoute){}

  ngOnInit(): void {
    const id = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    this.taskService.getTask(id).subscribe(response => {
      this.task = response.data;
      console.log(this.task);
    })
  }
}
