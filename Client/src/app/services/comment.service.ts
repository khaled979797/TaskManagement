import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { IResponse } from '../models/iresponse';
import { IComment } from '../models/commentModels/comment';
import { IAddComment } from '../models/commentModels/add-comment';
import { IEditComment } from '../models/commentModels/edit-comment';

@Injectable({
  providedIn: 'root'
})
export class CommentService {
  constructor(private http:HttpClient) { }

  addComment(comment:IAddComment){
    return this.http.post<IResponse<string>>(environment.apiUrl + 'Comment/AddComment', comment);
  }

  editComment(comment:IEditComment){
    return this.http.put<IResponse<string>>(environment.apiUrl + 'Comment/EditComment', comment);
  }

  getComments(assignmentId:number){
    return this.http.get<IResponse<IComment[]>>(environment.apiUrl + `Comment/GetAllComments/${assignmentId}`);
  }

  getComment(id:number){
    return this.http.get<IResponse<IComment>>(environment.apiUrl + `Comment/GetCommentById/${id}`);
  }

  deleteComment(id:number){
    return this.http.delete<IResponse<string>>(environment.apiUrl + `Comment/DeleteCommentById/${id}`);
  }
}
