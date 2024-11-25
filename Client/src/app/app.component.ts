import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavComponent } from "./components/nav/nav.component";
import { IUser } from './models/userModels/iuser';
import { UserService } from './services/user.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [NavComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
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
