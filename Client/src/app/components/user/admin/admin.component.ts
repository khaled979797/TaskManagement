import { Component, OnInit, TemplateRef } from '@angular/core';
import { IUser } from '../../../models/userModels/iuser';
import { UserService } from '../../../services/user.service';
import { ToastrService } from 'ngx-toastr';
import { HasRoleDirective } from '../../../directives/has-role.directive';
import { take } from 'rxjs';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { NotificationService } from '../../../services/notification.service';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [HasRoleDirective, ReactiveFormsModule],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent implements OnInit{
  users: IUser[] = {} as IUser[];
  currentUser: IUser = {} as IUser;
  modalRef?: BsModalRef;
  notifyForm:FormGroup = new FormGroup({});

  constructor(private userService: UserService, private toastr: ToastrService,
    private modalService: BsModalService, private fb:FormBuilder, private notificationService:NotificationService) {
    this.userService.currentUser$.pipe(take(1)).subscribe(user => this.currentUser = <IUser>user);
  }

  ngOnInit(): void {
    this.userService.getUsers().subscribe(
      response => this.users = response.data.filter(user => user.id != this.currentUser.id)
    );
    this.notifyForm = this.fb.group({
      message: ['', Validators.required],
      userId: [0, Validators.required],
    });
  }

  deleteUser(id: number) {
    this.userService.deleteUser(id).subscribe({
      next: () => this.toastr.success('User is deleted'),
      error: () => this.toastr.error('Failed to delete user')
    });
  }

  notifyUser(id: number){
    this.notifyForm.get('userId')?.setValue(id);
    this.notificationService.addNotification(this.notifyForm.value).subscribe({
      next: () => {
        this.toastr.success('Notification is send');
        this.notifyForm.reset();
        this.modalRef?.hide();
      },
      error: (err) => this.toastr.error('Failed to send notification')
    })
  }

  openModal(template: TemplateRef<void>) {
    this.modalRef = this.modalService.show(template);
  }

  get message(){
    return this.notifyForm.get('message') as FormControl;
  }
}
