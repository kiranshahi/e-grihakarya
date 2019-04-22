import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AssignmentService } from '../_services/assignment.service';
import { Assignment } from '../_models/assignment';

@Component({
  selector: 'app-assignment',
  templateUrl: './assignment.component.html',
  styleUrls: ['./assignment.component.scss']
})
export class AssignmentComponent implements OnInit {
  public assignId;
  public assignment: Assignment = null;
  constructor(
    private route: ActivatedRoute,
    private assignmentService: AssignmentService,
  ) { }

  ngOnInit() {
    let id = parseInt(this.route.snapshot.paramMap.get('id'));
    this.loadAssignDetails();
  }
  loadAssignDetails() {
    this.assignmentService.getDetails(this.assignId)
      .subscribe(res => {
        this.assignment = res as Assignment;
      });
  }
}
