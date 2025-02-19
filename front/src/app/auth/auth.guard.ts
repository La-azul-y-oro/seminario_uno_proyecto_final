import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { map, take } from 'rxjs';
import { AuthService } from './auth.service';
import { hasValidRoles } from '../util/rolesUtil';

const loginPath = '/login';
const homePath = '/inicio';

export const authGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  return authService.currentUserLoginOn.pipe(
    take(1),
    map((loggedIn: boolean) => {
      if (loggedIn) {
        return true;
      } else {
        router.navigate([loginPath]);
        return false;
      }
    })
  );
};

export const conceptGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  return authService.currentUserLoginOn.pipe(
    take(1),
    map((loggedIn: boolean) => {
      if(!loggedIn) router.navigate([loginPath]);
      return hasValidRoles(authService.userData, ["ADMIN", "STAFF"]);
    })
  );
};

export const authGuardNotLogin: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  return authService.currentUserLoginOn.pipe(
    take(1),
    map((loggedIn: boolean) => {
      if (loggedIn) {
        router.navigate([homePath]);
        return false;
      } else {
        return true;
      }
    })
  );
};