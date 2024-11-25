import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { IUser } from '../../models/userModels/iuser';

@Component({
  selector: 'app-user',
  imports: [],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent implements OnInit{
  users:IUser[] = {} as IUser[];
  constructor(private userService:UserService){}

  ngOnInit(): void {
    this.userService.getUsers().subscribe(response => this.users = response.data)
  }
}
