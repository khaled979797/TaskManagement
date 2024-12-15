import { CommonModule } from '@angular/common';
import { Component, ElementRef, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { IUser } from '../../../models/userModels/iuser';
import { IAttachment } from '../../../models/attachmentModels/attachment';
import { ITask } from '../../../models/taskModels/itask';
import { AttachmentService } from '../../../services/attachment.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';
import { TaskService } from '../../../services/task.service';
import { UserService } from '../../../services/user.service';
import { take } from 'rxjs';
import { IAddAttachment } from '../../../models/attachmentModels/add-attachment';

@Component({
  selector: 'app-attachments',
  standalone: true,
  imports: [CommonModule, FormsModule , ReactiveFormsModule],
  templateUrl: './attachments.component.html',
  styleUrl: './attachments.component.css'
})
export class AttachmentsComponent {
  user:IUser = {} as IUser;
  attachments?:IAttachment[];
  task:ITask = {} as ITask;
  attachmentForm:FormGroup = new FormGroup({});
  constructor(private attachmentService:AttachmentService, private toastr:ToastrService,
    private activatedRoute:ActivatedRoute, private taskService:TaskService, private fb:FormBuilder,
    private userService:UserService
  ){}

  ngOnInit(): void {
    this.loadTask();
  }



  loadTask(){
    const taskId = this.activatedRoute.snapshot.paramMap.get('id');
    if(taskId){
      this.taskService.getTask(Number(taskId)).subscribe(response =>{
        this.task = response.data;
        this.attachmentService.getAttachments(this.task.id).subscribe(response => this.attachments = response.data);
        this.userService.currentUser$.pipe(take(1)).subscribe(user =>{
          this.user = <IUser>user;
          this.attachmentForm = this.fb.group({
            file: ['', Validators.required],
            assignmentId: [this.task.id, Validators.required],
            userId: [this.user.id, Validators.required]
          });
        })
      })
    }
  }

  deleteAttachment(id:number){
    this.attachmentService.deleteAttachment(id).subscribe({
      next: () => {
        this.toastr.success('Attachment is deleted'),
        this.loadTask();
      },
      error: () => this.toastr.error('Failed to delete attachment')
    })
  }

  addAttachment(){
    const formData = new FormData();
    formData.append('file', this.file.value);
    formData.append('assignmentId', this.task.id.toString());
    formData.append('userId', this.user.id.toString());
    this.attachmentService.addAttachment(formData).subscribe({
      next: () => {
        this.toastr.success('Attachment is added');
        this.loadTask();
      },
      error: (err:any) => {
        this.toastr.error('Failed to add attachment');
      }
    });
  }

  onFileSelected(event: any): void {
    const file = event.target.files[0];
    if (file) {
      this.attachmentForm.patchValue({ file: file });
    }
  }

  get file(){
    return this.attachmentForm.get('file') as FormControl;
  }
}
