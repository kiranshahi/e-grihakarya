import { Component, OnInit } from '@angular/core';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../_services/authentication.service';
import { CASClass } from '../_models/casclass';
import { ClassService } from '../_services/class.service';

@Component({
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  public currentUser: User;
  public userFromApi: User;
  public classes: CASClass[] = [];
  constructor(
    private userService: UserService,
    private authenticationService: AuthenticationService,
    private classService: ClassService
  ) {
    this.currentUser = this.authenticationService.currentUserValue;
  }
  ngOnInit() {
    this.userService.getById(this.currentUser.id).pipe(first()).subscribe(user => {
      this.userFromApi = user;
    });
    this.bindData();
  }
  bindData() {
    this.classService.getAll().subscribe(res => {
      this.classes = res as CASClass[];
    });
  }
}
