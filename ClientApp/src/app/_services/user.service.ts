import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { User } from "../_models/user";

@Injectable({ providedIn: 'root' })
export class UserService {
  constructor(private http: HttpClient) { }
  getAll() {
    return this.http.get<User[]>("/api/users");
  }
  getById(id: number) {
    return this.http.get<User>(`/api/users/${id}`);
  }
  create(user: User) {
    return this.http.post<User>(`/api/users`, user);
  }
}
