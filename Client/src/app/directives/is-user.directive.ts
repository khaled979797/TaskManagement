import { Directive, OnInit, TemplateRef, ViewContainerRef } from '@angular/core';
import { IUser } from '../models/userModels/iuser';
import { UserService } from '../services/user.service';
import { take } from 'rxjs';

@Directive({
  selector: '[appIsUser]',
  standalone: true
})
export class IsUserDirective implements OnInit{
  appIsUser:IUser | null = null;

  constructor(private viewContainerRef: ViewContainerRef, private templateRef:TemplateRef<any>,
    private userService:UserService)
  {
    this.userService.currentUser$.pipe(take(1)).subscribe(user => this.appIsUser = user);
  }

  ngOnInit(): void {
    if(this.appIsUser) this.viewContainerRef.clear;
    else this.viewContainerRef.createEmbeddedView(this.templateRef);
  }
}
