import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { HttpModule } from '@angular/http'; //NEW

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { JwtInterceptor } from './_helpers/jwt.interceptor';
import { ErrorInterceptor } from './_helpers/error.interceptor';
import { routing } from './app.routing';
import { MenuComponent } from './menu/menu.component';
import { AdminComponent } from './admin/admin.component';
import { JoinClassComponent } from './join-class/join-class.component';
import { RegisterComponent } from './register/register.component';
import { AssignmentComponent } from './assignment/assignment.component';
import { CourseDetailsComponent } from './course-details/course-details.component';
import { FileUploaderComponent } from './file-uploader/file-uploader.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatDatepickerModule } from '@angular/material/datepicker'; 
import { MatNativeDateModule } from '@angular/material/core';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { OwlDateTimeModule, OwlNativeDateTimeModule } from 'ng-pick-datetime';

@NgModule({
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    HttpModule,
    routing,
    BrowserAnimationsModule,
    MatDatepickerModule, 
    MatNativeDateModule,
    NgbModule,
    OwlDateTimeModule,
    OwlNativeDateTimeModule,
    MDBBootstrapModule.forRoot()
  ],
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    MenuComponent,
    AdminComponent,
    JoinClassComponent,
    RegisterComponent,
    AssignmentComponent,
    CourseDetailsComponent,
    FileUploaderComponent
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
