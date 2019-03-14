import { Component, OnInit } from '@angular/core';
import { User } from '../_models/user';
import { UserService } from '../_services';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {
  users: User[] = [];

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getAll().pipe(first()).subscribe(users => {
      this.users = users;
    });
  }

}
