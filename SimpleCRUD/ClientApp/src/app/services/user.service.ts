import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { State } from '../models/state';
import { Role } from '../models/role';
import { User } from '../models/user';
import { ResponseData, Response } from '../models/response';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = '/api/user/';
  constructor(private http: HttpClient) { }

  getUsers(): Observable<ResponseData<User>>{
    return this.http.get<ResponseData<User>>(this.baseUrl);
  }

  getUserDetail(id: number): Observable<ResponseData<User>>{
    return this.http.get<ResponseData<User>>(this.baseUrl + id);
  }

  addUser(user: User): Observable<Response>{
    return this.http.post<Response>(this.baseUrl, user);
  }

  updateUser(user: User): Observable<Response>{
    return this.http.put<Response>(this.baseUrl, user);
  }

  deleteUser(id: number): Observable<Response>{
    return this.http.delete<Response>(this.baseUrl + id);
  }

  getStates(): Observable<ResponseData<State>>{
    return this.http.get<ResponseData<State>>(this.baseUrl + 'GetStates');
  }

  getRoles(): Observable<ResponseData<Role>>{
    return this.http.get<ResponseData<Role>>(this.baseUrl + 'GetRoles');
  }
}
