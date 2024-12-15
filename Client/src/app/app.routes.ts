import { Routes } from '@angular/router';
import { HomeComponent } from './components/shared/home/home.component';
import { RegisterComponent } from './components/user/register/register.component';
import { LearnMoreComponent } from './components/shared/learn-more/learn-more.component';
import { EditUserComponent } from './components/user/edit-user/edit-user.component';
import { AdminComponent } from './components/user/admin/admin.component';
import { AddProjectComponent } from './components/project/add-project/add-project.component';
import { TaskListComponent } from './components/task/task-list/task-list.component';
import { EditProjectComponent } from './components/project/edit-project/edit-project.component';
import { ProjectListComponent } from './components/project/project-list/project-list.component';
import { EditTaskComponent } from './components/task/edit-task/edit-task.component';
import { AddTaskComponent } from './components/task/add-task/add-task.component';
import { TaskDetailsComponent } from './components/task/task-details/task-details.component';
import { CommentsComponent } from './components/shared/comments/comments.component';
import { AttachmentsComponent } from './components/shared/attachments/attachments.component';

export const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'learn-more', component: LearnMoreComponent},
  {path: 'edit-user', component: EditUserComponent},
  {path: 'admin', component: AdminComponent},
  {path: 'projects', component: ProjectListComponent},
  {path: 'edit-project/:id', component: EditProjectComponent},
  {path: 'add-project', component: AddProjectComponent},
  {path: 'tasks', component: TaskListComponent},
  {path: 'edit-task/:id', component: EditTaskComponent},
  {path: 'add-task', component: AddTaskComponent},
  {path: 'task-details/:id', component: TaskDetailsComponent},
  {path: 'comments/:id', component: CommentsComponent},
  {path: 'attachments/:id', component: AttachmentsComponent}
];
