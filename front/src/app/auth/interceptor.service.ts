import { HttpInterceptorFn } from "@angular/common/http";
import { inject } from "@angular/core";
import { AuthService } from "./auth.service";
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
    let authService = inject(AuthService);
    let token = authService.userToken;

    if (token) {
        req = req.clone({
            setHeaders: {
                'Content-Type': 'application/json; charset=utf-8',
                'Accept': 'application/json',
                'Authorization': `Bearer ${token}`,
            },
        });
    }

    return next(req).pipe(
        catchError(err => {
            if (err.status === 401 || err.status === 403) {
                authService.logout();
            }
            return throwError(() => err);
        })
    );
};



