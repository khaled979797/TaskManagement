import { Component } from '@angular/core';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { UserService } from '../../services/user.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ILoginUser } from '../../models/userModels/ilogin-user';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-nav',
  imports: [CommonModule, FormsModule, RouterLink, BsDropdownModule],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  loginModel:ILoginUser = {} as ILoginUser;
  constructor(public userService:UserService){}

  login(){
    this.userService.login(this.loginModel).subscribe();
  }

  logout(){
    this.userService.logout();
  }
}
