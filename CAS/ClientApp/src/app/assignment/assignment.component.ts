import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AssignmentService } from '../_services/assignment.service';
import { Assignment } from '../_models/assignment';
import { User } from '../_models/user';
import { AuthenticationService } from '../_services';
import { UserAssignment } from '../_models/UserAssignment';

@Component({
  selector: 'app-assignment',
  templateUrl: './assignment.component.html',
  styleUrls: ['./assignment.component.scss']
})
export class AssignmentComponent implements OnInit {
  public currentUser: User;
  public assignId;
  public assignment: Assignment = null;
  public adminAsList: UserAssignment[] = [];
  public userAsList: UserAssignment[] = [];
  constructor(
    private route: ActivatedRoute,
    private assignmentService: AssignmentService,
    private authenticationService: AuthenticationService
  ) { this.currentUser = this.authenticationService.currentUserValue; }

  ngOnInit() {
    let id = parseInt(this.route.snapshot.paramMap.get('id'));
    this.loadAssignDetails(id);
    this.getUserAssignment(id);
    this.getUserAssignmentByID(this.currentUser.id, id);
  }
  loadAssignDetails(id) {
    this.assignmentService.getDetails(id)
      .subscribe(res => {
        this.assignment = res as Assignment;
        this.assignment.dueDate = new Date(this.assignment.dueDate).toLocaleString("en-Us", { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric', hour: '2-digit', minute: '2-digit', second: '2-digit' });
      });
  }
  getUserAssignment(id) {
    this.assignmentService.getUserAssign(id)
      .subscribe(res => {
        this.adminAsList = res as UserAssignment[];
      });
  }
  getUserAssignmentByID(userid, id) {
    this.assignmentService.getUserAssignById(userid, id)
      .subscribe(res => {
        this.userAsList = res as UserAssignment[];
      });
  }
  clickEvent(elem) {
    console.log(elem);
  }
}
