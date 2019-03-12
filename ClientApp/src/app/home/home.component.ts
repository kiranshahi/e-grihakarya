import { Component } from '@angular/core';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { first } from 'rxjs/operators';

@Component({
  templateUrl: './home.component.html'
})
export class HomeComponent {
  users: User[] = [];
  constructor(private userService: UserService) { }
  ngOnInit() {
    this.userService.getAll().pipe(first()).subscribe(users => {
      this.users = users;
    });
  }
}
