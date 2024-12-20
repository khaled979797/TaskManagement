import { Component } from '@angular/core';
import { RegisterComponent } from "../../user/register/register.component";
import { RouterLink } from '@angular/router';
import { IsUserDirective } from '../../../directives/is-user.directive';
import { TasksComponent } from "../tasks/tasks.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RegisterComponent, RouterLink, IsUserDirective, TasksComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  registerMode: boolean = false;

  registerToggle(){
    this.registerMode = !this.registerMode;
  }

  cancelRegisterMode(event:boolean){
    this.registerMode = event;
  }
}
