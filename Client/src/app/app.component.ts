import { Component, OnInit } from '@angular/core';
import { UserComponent } from "./components/user/user.component";
import { IUser } from './models/userModels/iuser';
import { UserService } from './services/user.service';
import { NavComponent } from "./components/nav/nav.component";

@Component({
  selector: 'app-root',
  imports: [NavComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  constructor(private userService:UserService){}

  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser() {
    if(typeof(localStorage) !== "undefined"){
      const userString = localStorage.getItem('user');
      if (!userString) return;
      const user: IUser = JSON.parse(userString);
      this.userService.setCurrentUser(user);
    }
  }
}
