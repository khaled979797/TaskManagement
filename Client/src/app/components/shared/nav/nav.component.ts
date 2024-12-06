import { Component } from '@angular/core';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { UserService } from '../../../services/user.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ILoginUser } from '../../../models/userModels/ilogin-user';
import { Router, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HasRoleDirective } from '../../../directives/has-role.directive';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink, BsDropdownModule, HasRoleDirective],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css',
  providers: []
})
export class NavComponent {
  loginModel:ILoginUser = {} as ILoginUser;
  constructor(public userService:UserService, private router:Router, private toastr:ToastrService){}

  login(){
    this.userService.login(this.loginModel).subscribe({
      next: () => this.router.navigateByUrl('/'),
      error: (err:any) => this.toastr.error('Username or password are wrong')
    });
  }

  logout(){
    this.userService.logout();
  }
}
