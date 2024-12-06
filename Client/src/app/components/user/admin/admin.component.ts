import { Component, OnInit } from '@angular/core';
import { IUser } from '../../../models/userModels/iuser';
import { UserService } from '../../../services/user.service';
import { ToastrService } from 'ngx-toastr';
import { HasRoleDirective } from '../../../directives/has-role.directive';
import { take } from 'rxjs';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [HasRoleDirective],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent implements OnInit{
  users: IUser[] = {} as IUser[];
  currentUser: IUser = {} as IUser;
  constructor(private userService: UserService, private toastr: ToastrService) {
    this.userService.currentUser$.pipe(take(1)).subscribe(user => this.currentUser = <IUser>user);
  }

  ngOnInit(): void {
    this.userService.getUsers().subscribe(
      response => this.users = response.data.filter(user => user.id != this.currentUser.id)
    );
  }

  deleteUser(id: number) {
    this.userService.deleteUser(id).subscribe({
      next: () => this.toastr.success('User is deleted'),
      error: () => this.toastr.error('Failed to delete user')
    });
  }
}
