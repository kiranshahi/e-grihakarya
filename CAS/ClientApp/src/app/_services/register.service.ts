import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private http: HttpClient) { }

  register(firstname: string, lastname: string, email: string, username: string, password: string, role: string, token: string) {
    return this.http.post<any>('/api/users/register', { firstname, lastname, email, username, password, role, token });
  }
}
