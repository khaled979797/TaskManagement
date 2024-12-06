import { Component } from '@angular/core';
import { RegisterComponent } from "../../user/register/register.component";
import { RouterLink } from '@angular/router';
import { IsUserDirective } from '../../../directives/is-user.directive';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RegisterComponent, RouterLink, IsUserDirective],
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
