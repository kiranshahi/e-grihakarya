import { Component, OnInit } from '@angular/core';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../_services/authentication.service';
import { CASClass } from '../_models/casclass';
import { ClassService } from '../_services/class.service';
import { Router } from '@angular/router';

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
    private classService: ClassService,
    private router: Router
  ) {
    this.currentUser = this.authenticationService.currentUserValue;
  }
  ngOnInit() {
    this.userService.getById(this.currentUser.id).pipe(first()).subscribe(user => {
      this.userFromApi = user;
    });
    
    this.classService.refreshNeeded$
    .subscribe(
      message => {
        this.getAllClass();
      });
      this.getAllClass();
  }
  getAllClass() {
    this.classService.getAll().subscribe(res => {
      this.classes = res as CASClass[];
    });
  }
  onSelect(class1){
    this.router.navigate(['/course', class1.id]);
  }
}
