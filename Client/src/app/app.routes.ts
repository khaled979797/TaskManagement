import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { RegisterComponent } from './components/register/register.component';
import { LearnMoreComponent } from './components/learn-more/learn-more.component';
import { EditUserComponent } from './components/edit-user/edit-user.component';
import { AdminComponent } from './components/admin/admin.component';

export const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'learn-more', component: LearnMoreComponent},
  {path: 'edit-user', component: EditUserComponent},
  {path: 'admin', component: AdminComponent},
];
