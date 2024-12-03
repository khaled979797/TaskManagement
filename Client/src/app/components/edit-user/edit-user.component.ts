import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, ValidatorFn, Validators } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { TextInputComponent } from '../../forms/text-input/text-input.component';
import { IUser } from '../../models/userModels/iuser';
import { take } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-edit-user',
  standalone: true,
  imports: [FormsModule, CommonModule, TextInputComponent, ReactiveFormsModule],
  templateUrl: './edit-user.component.html',
  styleUrl: './edit-user.component.css'
})
export class EditUserComponent {
  user:IUser = {} as IUser;
  validationErrors:any = [];
  editForm:FormGroup = new FormGroup({});
  constructor(private userService:UserService, private fb:FormBuilder, private router:Router, private toastr:ToastrService){
    userService.currentUser$.pipe(take(1)).subscribe(user => this.user = <IUser>user);
  }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm(){
    this.editForm = this.fb.group({
      id: [this.user.id, Validators.required],
      name: ['', Validators.required],
      userName: ['', Validators.required],
      email: ['', Validators.required]
    })
  }

  editUser(){
    this.userService.editUser(this.editForm.value).subscribe({
      next: () => {
        this.user.userName = this.userName.value;
        this.userService.setCurrentUser(this.user);
        this.router.navigateByUrl('/');
        this.toastr.success('User is updated');
      },
      error: (err:any) => {
        this.validationErrors = err;
        this.toastr.error('Failed to update user');
      }
    });
  }

  get name(){
    return this.editForm.get('name') as FormControl;
  }
  get userName(){
    return this.editForm.get('userName') as FormControl;
  }
  get email(){
    return this.editForm.get('email') as FormControl;
  }
}
