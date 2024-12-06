import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, ValidatorFn, Validators } from '@angular/forms';
import { UserService } from '../../../services/user.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { TextInputComponent } from '../../../forms/text-input/text-input.component';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, CommonModule, TextInputComponent, ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit{
  @Output() CancelRegister = new EventEmitter<boolean>();
  validationErrors:any = [];
  registerForm:FormGroup = new FormGroup({});
  constructor(private userService:UserService, private fb:FormBuilder, private router:Router){}

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm(){
    this.registerForm = this.fb.group({
      name: ['', Validators.required],
      userName: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
      confirmPassword: ['', [Validators.required, this.matchValue('password')]]
    })
  }

  register(){
    this.userService.register(this.registerForm.value).subscribe({
      next: () => this.router.navigateByUrl('/'),
      error: (err:any) => this.validationErrors = err
    });
  }

  cancel(){
    this.CancelRegister.emit(false);
  }

  matchValue(matchTo:string) : ValidatorFn{
    return (control:AbstractControl) =>{
      return control.value === control.parent?.get(matchTo)?.value? null : {isMatching: true}
    }
  }

  changePasswordValue(){
    this.registerForm.controls['password'].valueChanges.subscribe(() =>{
      this.registerForm.controls['confirmPassword'].updateValueAndValidity
    });
  }

  get name(){
    return this.registerForm.get('name') as FormControl;
  }
  get userName(){
    return this.registerForm.get('userName') as FormControl;
  }
  get email(){
    return this.registerForm.get('email') as FormControl;
  }
  get password(){
    return this.registerForm.get('password') as FormControl;
  }
  get confirmPassword(){
    return this.registerForm.get('confirmPassword') as FormControl;
  }
}
