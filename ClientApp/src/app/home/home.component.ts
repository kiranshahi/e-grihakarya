import { Component, OnInit } from '@angular/core';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../_services/authentication.service';
import { ClassView } from '../_models/classView';
import { ClassService } from '../_services/class.service';
import { Router } from '@angular/router';

@Component({
    templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
    public currentUser: User;
    public userFromApi: User;
    public classes: ClassView[] = [];
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
        let role = this.currentUser.role;
        let userId = this.currentUser.id;
        this.classService.getAll(role, userId).subscribe(res => {
            this.classes = res as ClassView[];
        });
    }
    onSelect(class1) {
        this.router.navigate(['/course', class1.id]);
    }
    onDelete(class1) {
        this.classService.deleteClass(class1.id).subscribe();
    }
    onEdit(class1) {
        this.router.navigate(['/edit', class1.id]);
    }
}
