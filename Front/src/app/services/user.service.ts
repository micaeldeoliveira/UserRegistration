import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { UserModel } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private urlBase: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  public getAll() {
    return this.http.get(`${this.urlBase}/v1/users`);
  }

  public getById(id) {
    return this.http.get(`${this.urlBase}/v1/users/${id}`);
  }

  public add(user) {
    return this.http.post(`${this.urlBase}/v1/users`, user);
  }

  public edit(user) {
    return this.http.put(`${this.urlBase}/v1/users`, user);
  }

  public delete(id) {
    return this.http.delete(`${this.urlBase}/v1/users/${id}`);
  }
}
