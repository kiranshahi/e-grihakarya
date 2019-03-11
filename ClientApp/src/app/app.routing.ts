import { Route, RouterModule } from "@angular/router";
import { AuthGuard } from "./_guards/auth.guard";
import { LoginComponent } from "./login/login.component";
import { HomeComponent } from "./home/home.component";

const appRoutes: Route = [
  {
    path: '',
    component: HomeComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'login',
    component: LoginComponent
  },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);
