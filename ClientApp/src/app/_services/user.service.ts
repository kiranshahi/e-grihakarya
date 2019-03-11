import { Injectable } from "@angular/core";
import { HttpClient } from "selenium-webdriver/http";
import { User } from "../_models/user";

@Injectable({ providedIn: 'root' })
export class UserService {
  constructor(private http: HttpClient) { }
  getAll() {
    return this.http.get<User[]>(`${config.apiUrl}/users`);
  }
}
