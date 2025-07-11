import { HttpInterceptorFn } from "@angular/common/http";
import { inject } from "@angular/core";
import { AuthService } from "./auth.service";
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { ToastService } from "../components/toast/toast-service";

export const authInterceptor: HttpInterceptorFn = (req, next) => {
    let authService = inject(AuthService);
    let toastService = inject(ToastService);
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
            if (err.status === 401){
                toastService.setErrorMessage("Se ha cerrado su sesión, por favor vuelva a ingresar.")
                authService.logout();
            }
            if(err.status === 403) {
                toastService.setErrorMessage("No posee permisos para realizar la acción solicitada.")
            }
            return throwError(() => err);
        })
    );
};



