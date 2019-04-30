import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AssignmentService } from '../_services/assignment.service';
import { Assignment } from '../_models/assignment';
import { User } from '../_models/user';
import { AuthenticationService } from '../_services';
import { UserAssignment } from '../_models/UserAssignment';
import { UserAssignmentAdmin } from '../_models/UserAssignmentAdmin';

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
  public response: { dbPath: '' };
  public filename: string;
  constructor(
    private route: ActivatedRoute,
    private assignmentService: AssignmentService,
    private authenticationService: AuthenticationService
  ) { this.currentUser = this.authenticationService.currentUserValue; }

  ngOnInit() {
    let id = parseInt(this.route.snapshot.paramMap.get('id'));
    this.assignId = id;
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
  public uploadFinished = (event) => {
    let fileElem = document.getElementById("fileName");
    this.response = event;
    this.filename = this.response.dbPath.split('\\')[2];
    fileElem.innerHTML = this.filename;
    fileElem.dataset.file = this.response.dbPath;
  }
  onSubmitAssign() {
    let userAssign: UserAssignmentAdmin = {
      UserID: this.currentUser.id,
      AssignmentID: this.assignId,
      Assignment: document.getElementById('fileName').dataset.file,
    } as UserAssignmentAdmin;
    this.assignmentService.addUserAssign(userAssign).subscribe();
  }
}
