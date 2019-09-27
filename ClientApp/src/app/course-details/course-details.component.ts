import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ClassService } from '../_services/class.service';
import { CASClass } from '../_models/casclass';
import { User } from '../_models/user';
import { AuthenticationService } from '../_services';
import { Assignment } from '../_models/assignment';
import { AssignmentService } from '../_services/assignment.service';
import { ModalDirective } from 'angular-bootstrap-md';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
    selector: 'app-course-details',
    templateUrl: './course-details.component.html',
    styleUrls: ['./course-details.component.scss']
})
export class CourseDetailsComponent implements OnInit {
    public currentUser: User;
    public classId;
    public casClass: CASClass = null;
    public response: { dbPath: '' };
    public filename: string;
    public asList: Assignment[] = [];
    @ViewChild('assignmentModal', { static: true }) createModal: ModalDirective;

    title = new FormControl('');
    instruction = new FormControl('');
    dueDate = new FormControl('');
    constructor(
        private route: ActivatedRoute,
        private classService: ClassService,
        private authenticationService: AuthenticationService,
        private assignmentService: AssignmentService,
        private router: Router
    ) {
        this.currentUser = this.authenticationService.currentUserValue;
    }

    ngOnInit() {
        let id = parseInt(this.route.snapshot.paramMap.get('id'));
        this.classId = id;
        this.loadClassDetails();
        this.assignmentService.refreshNeeded$
            .subscribe(
                message => {
                    this.getAll();
                });
        this.getAll();
    }

    loadClassDetails() {
        this.classService.getById(this.classId)
            .subscribe(res => {
                this.casClass = res as CASClass;
            });
    }
    public uploadFinished = (event) => {
        let fileElem = document.getElementById("fileName");
        this.response = event;
        this.filename = this.response.dbPath.split('\\')[2];
        fileElem.innerHTML = this.filename;
        fileElem.dataset.file = this.response.dbPath;
    }

    onCreate() {
        let newAs: Assignment = {
            ID: 0,
            Title: this.title.value,
            Instructions: this.instruction.value,
            Attachment: document.getElementById('fileName').dataset.file,
            dueDate: this.dueDate.value,
            ClassID: this.classId
        } as Assignment;
        this.assignmentService.addAs(newAs)
            .subscribe();
        this.createModal.hide();
    }

    getAll() {
        this.assignmentService.getAll(this.classId)
            .subscribe(res => {
                this.asList = res as Assignment[];
            });
    }

    onSelect(as) {
        this.router.navigate(['/assignment', as.id]);
    }
}
