import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, catchError, map, tap, throwError } from 'rxjs';
import { Router } from '@angular/router';
import { environment } from '../../enviroments/enviroments';
import { ChangePasswordRequest, ForgotPasswordRequest, ResetPasswordRequest, UserLogin } from '../interfaces/model.interfaces';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  url: string = `${environment.apiUrl}/auth`;

  currentUserLoginOn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  currentUserData: BehaviorSubject<string | null> = new BehaviorSubject<string | null>(null);

  constructor(private readonly httpClient: HttpClient, private readonly router : Router) { 
    this.currentUserLoginOn = new BehaviorSubject<boolean>(sessionStorage.getItem("token") != null);
    const token = sessionStorage.getItem("token");
    if (token) {
      this.currentUserData.next(token);
    }
  }

  login(credentials: UserLogin): Observable<any> {
    return this.httpClient.post<any>(this.url + "/login", credentials).pipe(
      tap((userData) => {
        sessionStorage.setItem("token", userData.token);
        this.currentUserData.next(userData.token);
        this.currentUserLoginOn.next(true);
      }),
      map((userData) => userData.token),
      catchError(this.handleError)
    );
  }

  
  resetPassword(request: ResetPasswordRequest): Observable<any> {
    return this.httpClient.post<any>(this.url + "/reset-password", request).pipe(
      catchError(this.handleError)
    );
  }

  forgotPassword(request: ForgotPasswordRequest): Observable<any> {
    return this.httpClient.post<any>(this.url + "/forgot-password", request).pipe(
      catchError(this.handleError)
    );
  }
  
  changePassword(request: ChangePasswordRequest): Observable<any> {
    return this.httpClient.post<any>(this.url + "/change-password", request).pipe(
      catchError(this.handleError)
    );
  }  

  logout() {
    sessionStorage.removeItem("token");
    this.currentUserLoginOn.next(false);
    this.currentUserData.next("");
    this.router.navigate(['/login']);
  }

  private handleError(error: HttpErrorResponse): Observable<never> {
    let errorMessage: string;
    if (error.error instanceof ErrorEvent) {
      // Error del lado del cliente o de red
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Error del lado del servidor
      errorMessage = `Error Status: ${error.status}\nMessage: ${error.message}`;
    }
    // Aquí podemos también devolver el objeto de error original para su manejo más detallado
    console.error(errorMessage);
    return throwError(() => new Error(errorMessage));
  }

  private decodeToken(token: string) {
    try {
      return jwtDecode<string>(token);
    } catch (Error) {
      console.error('Error decodificando token', Error);
      return null;
    }
  }

  get userToken() {
    return this.currentUserData.value;
  }

  get userData() {
    if(this.currentUserData.value){
      return jwtDecode(this.currentUserData.value);
    } else{
      return null;
    }
  }
}