import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AssignmentService } from '../_services/assignment.service';
import { Assignment } from '../_models/assignment';
import { User } from '../_models/user';
import { AuthenticationService } from '../_services';
import { UserAssignment } from '../_models/UserAssignment';
import { UserAssignmentAdmin } from '../_models/UserAssignmentAdmin';
import { CommentService } from '../_services/comment.service';
import { FormControl } from '@angular/forms';
import { Comment } from '@angular/compiler';
import { Comments } from '../_models/Comments';
import { CommentView } from '../_models/CommentView';
import { ModalDirective } from 'angular-bootstrap-md';

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
  public commentList: CommentView[] = [];
  public response: { dbPath: '' };
  public filename: string;
  public pdfSrc: string;
  @ViewChild('pdfModal') pdfModal: ModalDirective;
  @ViewChild('comment') comment: ElementRef;
  constructor(
    private route: ActivatedRoute,
    private assignmentService: AssignmentService,
    private authenticationService: AuthenticationService,
    private commentService: CommentService
  ) { this.currentUser = this.authenticationService.currentUserValue; }

  ngOnInit() {
    let id = parseInt(this.route.snapshot.paramMap.get('id'));
    this.assignId = id;
    this.loadAssignDetails(id);
    this.getUserAssignment(id);
    this.getUserAssignmentByID(this.currentUser.id, id);
    this.commentService.refreshNeeded$
      .subscribe(
        message => {
          this.getComments(id);
        });
    this.getComments(id);
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
    this.filename = this.response.dbPath.split('\\')[4];
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
  getComments(id) {
    this.commentService.getComment(id)
      .subscribe(res => {
        this.commentList = res as CommentView[];
      });
  }
  addComment() {
    let cmt: Comments = {
      UserId: this.currentUser.id,
      AssignmentID: this.assignId,
      Comment: this.comment.nativeElement.value
    } as Comments;
    this.commentService.addComment(cmt)
      .subscribe();
  }
  pdfViwer(el) {
    this.pdfSrc = location.origin + '/' + el.getAttribute('data-file');
    console.log(this.pdfSrc);
    this.pdfSrc = "../../assets/1536744413.pdf";
    this.pdfModal.show();
  }
}
