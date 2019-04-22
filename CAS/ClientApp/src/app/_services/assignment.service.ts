import { Injectable } from '@angular/core';
import { Assignment } from '../_models/assignment';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AssignmentService {

  constructor(private http: HttpClient) { }
  private _asMessageSource$ = new Subject<void>();
  get refreshNeeded$(){
    return this._asMessageSource$;
  }
  addAs(assignmentDetail: Assignment): Observable<Assignment> {
    return this.http.post<Assignment>("/api/assignment", assignmentDetail)
    .pipe(
      tap(() => {
        this._asMessageSource$.next();
      })
    )
  }
  getAll(classId) {
    return this.http.get<Assignment[]>("/api/assignment", {
      params: {
        classId: classId
      }
    });
  }
  getDetails(assId) {
    return this.http.get<Assignment>(`/api/assignment/${assId}`);
  }
}
