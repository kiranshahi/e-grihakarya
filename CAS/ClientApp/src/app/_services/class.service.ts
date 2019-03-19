import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CASClass } from '../_models/casclass';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class ClassService {

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<CASClass[]>("/api/class");
  }
  getById(id: number) {
    return this.http.get<User>(`/api/class/${id}`);
  }
  create(casClass: CASClass) {
    return this.http.post<CASClass>(`/api/class`, { casClass });
  }
}
