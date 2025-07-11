import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { map, take } from 'rxjs';
import { AuthService } from './auth.service';
import { hasValidRoles } from '../util/rolesUtil';

const loginPath = '/login';
const clientPath = '/mis-unidades';
const consortiumPath = '/consorcios';

export const clientGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);
  return authService.currentUserLoginOn.pipe(
    take(1),
    map((loggedIn: boolean) => {
      if(!loggedIn) {
        router.navigate([loginPath]);
        return false;
      }
      if(hasValidRoles(authService.userData, ["CLIENT"])){
        return true;
      } else {
        router.navigate([consortiumPath]);
        return false;
      }
    })
  );
};

export const consortiumGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);
  return authService.currentUserLoginOn.pipe(
    take(1),
    map((loggedIn: boolean) => {
      if(!loggedIn) {
        router.navigate([loginPath]);
        return false;
      }
      if(hasValidRoles(authService.userData, ["ADMIN", "STAFF"])){
        return true;
      } else {
        router.navigate([clientPath]);
        return false;
      }
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
        const path = (hasValidRoles(authService.userData, ["ADMIN", "STAFF"])) ? consortiumPath : clientPath; 
        router.navigate([path]);
        return false;
      } else {
        return true;
      }
    })
  );
};

export const adminGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);
  return authService.currentUserLoginOn.pipe(
    take(1),
    map((loggedIn: boolean) => {
      if(!loggedIn) {
        router.navigate([loginPath]);
        return false;
      }
      if(hasValidRoles(authService.userData, ["ADMIN"])){
        return true;
      } else if(hasValidRoles(authService.userData, ["STAFF"])){
        router.navigate([consortiumPath]);
        return false;
      }
        else {
        router.navigate([clientPath]);
        return false;
      }
    })
  );
};