import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CASClass } from '../_models/casclass';
import { User } from '../_models/user';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClassService {

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<CASClass[]>("/api/class", {
      params: {
        Role: 'Admin',
        UserId: '1'
      }
    });
  }
  getById(id: number) {
    return this.http.get<User>(`/api/class/${id}`);
  }
  addClass(casClass: CASClass): Observable<CASClass> {
    return this.http.post<CASClass>("/api/class", casClass);
  }
}
