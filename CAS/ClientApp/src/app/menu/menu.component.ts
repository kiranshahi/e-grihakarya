import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { AuthenticationService } from '../_services/authentication.service';
import { ClassService } from '../_services/class.service';
import { Router } from '@angular/router';
import { FormControl } from '@angular/forms';
import { CASClass } from '../_models/casclass';
import { User } from '../_models/user';
import { formatDate } from '@angular/common';
import { ModalDirective } from 'angular-bootstrap-md';
import { Join } from '../_models/join';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  currentUser: User;
  classCode = new FormControl('');

  className = new FormControl('');
  section = new FormControl('');
  subject = new FormControl('');
  room = new FormControl('');
  @ViewChild('createModal') createModal: ModalDirective;
  @ViewChild('joinModal') joinModal: ModalDirective;

  constructor(
    private router: Router,
    private authenticationService: AuthenticationService,
    private classService: ClassService
  ) {
    this.currentUser = this.authenticationService.currentUserValue;
  }

  ngOnInit() {
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
  }

  onJoin() {
    let jClass: Join = {
      Id: 0,
      ClassID: this.classCode.value,
      UserID: this.currentUser.id
    } as Join;
    this.classService.joinClass(jClass)
      .subscribe();
    this.joinModal.hide();
  }

  onCreate() {
    let newClass: CASClass = {
        Id: 0,
        ClassName: this.className.value,
        Section: this.section.value,
        Subject: this.subject.value,
        Room: this.room.value,
        AddedOn: formatDate(new Date(), 'MM/dd/yyyy', 'en'),
        AddedBy: this.currentUser.id
    } as unknown as CASClass;
    this.classService.addClass(newClass)
      .subscribe();
      this.createModal.hide();
  }
}
