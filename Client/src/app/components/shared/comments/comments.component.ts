import { Component,ElementRef,OnInit, ViewChild } from '@angular/core';
import { IComment } from '../../../models/commentModels/comment';
import { CommentService } from '../../../services/comment.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';
import { TaskService } from '../../../services/task.service';
import { ITask } from '../../../models/taskModels/itask';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { IUser } from '../../../models/userModels/iuser';
import { UserService } from '../../../services/user.service';
import { take } from 'rxjs';
import { IAddComment } from '../../../models/commentModels/add-comment';

@Component({
  selector: 'app-comments',
  standalone: true,
  imports: [CommonModule, FormsModule , ReactiveFormsModule],
  templateUrl: './comments.component.html',
  styleUrl: './comments.component.css'
})
export class CommentsComponent implements OnInit{
  user:IUser = {} as IUser;
  comments?:IComment[];
  task:ITask = {} as ITask;
  commentForm:FormGroup = new FormGroup({});
  commentContent:string = '';
  editingCommentId:number = 0;
  @ViewChild('commentTextarea') commentTextarea!: ElementRef;
  constructor(private commentService:CommentService, private toastr:ToastrService,
    private activatedRoute:ActivatedRoute, private taskService:TaskService, private fb:FormBuilder,
    private userService:UserService
  ){}

  ngOnInit(): void {
    this.loadTask();
  }

  updateComment(event: Event): void {
    this.commentContent = (event.target as HTMLTextAreaElement).value;
  }

  loadTask(){
    const taskId = this.activatedRoute.snapshot.paramMap.get('id');
    if(taskId){
      this.taskService.getTask(Number(taskId)).subscribe(response =>{
        this.task = response.data;
        this.commentService.getComments(this.task.id).subscribe(response => this.comments = response.data);
        this.userService.currentUser$.pipe(take(1)).subscribe(user =>{
          this.user = <IUser>user;
          this.commentForm = this.fb.group({
            content: ['', Validators.required],
            assignmentId: [this.task.id, Validators.required],
            userId: [this.user.id, Validators.required]
          });
        })
      })
    }
  }

  deleteComment(id:number){
    this.commentService.deleteComment(id).subscribe({
      next: () => {
        this.toastr.success('Comment is deleted'),
        this.loadTask();
      },
      error: () => this.toastr.error('Failed to delete comment')
    })
  }

  addComment(){
    const comment : IAddComment = {
      content: this.commentContent,
      assignmentId: this.task.id,
      userId: this.user.id
    }
    this.commentService.addComment(comment).subscribe({
      next: () => {
        this.toastr.success('Comment is added');
        this.commentTextarea.nativeElement.value = '';
        this.loadTask();
      },
      error: (err:any) => {
        this.toastr.error('Failed to add comment');
      }
    });
  }

  cancel(){
    this.commentTextarea.nativeElement.value = '';
  }

  resetForm(){
    this.commentForm.reset();
    this.editingCommentId = 0;
  }

  editComment(id: number) {
    this.editingCommentId = id;
    const content = this.comments?.find(x => x.id == id)?.content;
    this.commentForm = this.fb.group({
      id: [id, Validators.required],
      content: [content, Validators.required],
      assignmentId: [this.task.id, Validators.required],
      userId: [this.user.id, Validators.required]
    });
  }

  saveComment(){
    this.commentService.editComment(this.commentForm.value).subscribe({
      next: () => {
        this.toastr.success('Comment is updated');
        this.editingCommentId = 0;
        this.loadTask();
      },
      error: (err:any) => {
        this.toastr.error('Failed to update comment');
      }
    });
  }

  get content(){
    return this.commentForm.get('content') as FormControl;
  }
}
