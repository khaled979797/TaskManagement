import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { RegisterComponent } from './components/register/register.component';
import { LearnMoreComponent } from './components/learn-more/learn-more.component';
import { EditUserComponent } from './components/edit-user/edit-user.component';
import { AdminComponent } from './components/admin/admin.component';
import { EditProjectComponent } from './components/edit-project/edit-project.component';
import { AddProjectComponent } from './components/add-project/add-project.component';
import { ProjectListComponent } from './components/project-list/project-list.component';

export const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'learn-more', component: LearnMoreComponent},
  {path: 'edit-user', component: EditUserComponent},
  {path: 'admin', component: AdminComponent},
  {path: 'projects', component: ProjectListComponent},
  {path: 'edit-project/:id', component: EditProjectComponent},
  {path: 'add-project', component: AddProjectComponent},
];
