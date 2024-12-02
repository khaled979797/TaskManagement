import { Directive, Input, OnInit, TemplateRef, ViewContainerRef } from '@angular/core';
import { IUser } from '../models/userModels/iuser';
import { UserService } from '../services/user.service';
import { take } from 'rxjs';

@Directive({
  selector: '[appHasRole]',
  standalone: true
})
export class HasRoleDirective implements OnInit{
  user!:IUser;
  @Input() appHasRole:string[] = [];

  constructor(private viewContainerRef:ViewContainerRef, private templateRef:TemplateRef<any>, private userService:UserService) {
    this.userService.currentUser$.pipe(take(1)).subscribe(user => this.user = <IUser>user);
  }
  ngOnInit(): void {
    if(!this.user.roles || !this.user){
      this.viewContainerRef.clear;
      return;
    }
    if(this.user.roles.some(r => this.appHasRole.includes(r))){
      this.viewContainerRef.createEmbeddedView(this.templateRef);
    }
    else{
      this.viewContainerRef.clear;
    }
  }
}
