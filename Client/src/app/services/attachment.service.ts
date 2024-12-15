import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { IResponse } from '../models/iresponse';
import { IComment } from '../models/commentModels/comment';
import { IAddComment } from '../models/commentModels/add-comment';
import { IEditComment } from '../models/commentModels/edit-comment';
import { IAddAttachment } from '../models/attachmentModels/add-attachment';
import { IAttachment } from '../models/attachmentModels/attachment';

@Injectable({
  providedIn: 'root'
})
export class AttachmentService {
  constructor(private http:HttpClient) { }

  addAttachment(attachment:any){
    return this.http.post<IResponse<string>>(environment.apiUrl + 'Attachment/AddAttachment', attachment);
  }

  getAttachments(assignmentId:number){
    return this.http.get<IResponse<IAttachment[]>>(environment.apiUrl + `Attachment/GetAllAttachments/${assignmentId}`);
  }

  getAttachment(id:number){
    return this.http.get<IResponse<IAttachment>>(environment.apiUrl + `Attachment/GetAttachmentById/${id}`);
  }

  deleteAttachment(id:number){
    return this.http.delete<IResponse<string>>(environment.apiUrl + `Attachment/DeleteAttachmentById/${id}`);
  }
}
