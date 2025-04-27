import { Injectable } from '@angular/core';
import { GenericService } from './generic-service.class';
import { HttpClient } from '@angular/common/http';
import { UserRequest, UserResponse } from '../interfaces/model.interfaces';
import { Observable } from 'rxjs';
import { environment } from "../../enviroments/enviroments";

@Injectable({
  providedIn: 'root'
})
export class UserService extends GenericService<UserRequest, UserResponse>{
  constructor(httpClient: HttpClient) {
    super(httpClient, "user");
  }

  override create(request: UserRequest): Observable<UserResponse> {
    const customUrl = `${environment.apiUrl}/auth/register`;
    return this.httpClient.post<UserResponse>(customUrl, request);
  }
}
