import { Routes, RouterModule } from "@angular/router";

import { HomeComponent } from "./home/home.component";
import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";
import { AuthGuard } from "./_guards/auth.guard";
import { Role } from './_models/role';
import { CourseDetailsComponent } from './course-details/course-details.component';
import { AssignmentComponent } from './assignment/assignment.component';
import { EditComponent } from './edit/edit.component';

const appRoutes: Routes = [
    {
        path: '',
        component: HomeComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: 'register',
        component: RegisterComponent,
        canActivate: [AuthGuard],
        data: { roles: [Role.Admin] }
    },
    {
        path: 'edit/:id',
        component: EditComponent,
        canActivate: [AuthGuard],
        data: { roles: [Role.Teacher] }
    },
    {
        path: 'course/:id',
        component: CourseDetailsComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'assignment/:id',
        component: AssignmentComponent,
        canActivate: [AuthGuard]
    },
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);
