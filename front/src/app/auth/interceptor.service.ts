import { HttpInterceptorFn } from "@angular/common/http";
import { inject, Injector } from "@angular/core";
import { AuthService } from "./auth.service";
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { ToastService } from "../components/toast/toast-service";
import { Router } from '@angular/router';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
    let authService = inject(AuthService);
    let toastService = inject(ToastService);
    let router = inject(Router);
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
            const currentUrl = router.url;
            const isLoginPage = currentUrl.includes('/login');

            if (err.status === 401 && !isLoginPage){
                toastService.setErrorMessage("Se ha cerrado su sesión, por favor vuelva a ingresar.")
                authService.logout();
            }
            if(err.status === 403 && !isLoginPage) {
                toastService.setErrorMessage("No posee permisos para realizar la acción solicitada.")
            }
            return throwError(() => err);
        })
    );
};



