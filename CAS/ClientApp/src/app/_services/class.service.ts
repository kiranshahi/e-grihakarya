import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CASClass } from '../_models/casclass';
import { ClassView } from '../_models/classView';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Join } from '../_models/join';

@Injectable({
  providedIn: 'root'
})
export class ClassService {

  constructor(private http: HttpClient) { }
  private _classMessageSource$ = new Subject<void>();
  get refreshNeeded$() {
    return this._classMessageSource$;
  }
  getAll(role, userId) {
    return this.http.get<ClassView[]>("/api/class", {
      params: {
        Role: role,
        UserId: userId
      }
    });
  }
  getById(id: number) {
    return this.http.get<CASClass>(`/api/class/${id}`);
  }
  addClass(casClass: CASClass): Observable<CASClass> {
    return this.http.post<CASClass>("/api/class", casClass)
      .pipe(
        tap(() => {
          this._classMessageSource$.next();
        })
      )
  }
  joinClass(join: Join) {
    return this.http.post<Join>("/api/Join", join)
      .pipe(
        tap(() => {
          this._classMessageSource$.next();
        })
      )
  }
}
