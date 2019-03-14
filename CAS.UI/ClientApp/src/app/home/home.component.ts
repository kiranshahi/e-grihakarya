import { Component } from '@angular/core';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../_services/authentication.service';

@Component({
  templateUrl: './home.component.html'
})
export class HomeComponent {
  currentUser: User;
  userFromApi: User;
  constructor(
    private userService: UserService,
    private authenticationService: AuthenticationService
  ) {
    this.currentUser = this.authenticationService.currentUserValue;
  }
  ngOnInit() {
    this.userService.getById(this.currentUser.id).pipe(first()).subscribe(user => {
      this.userFromApi = user;
    });
  }
}
