import { Routes } from '@angular/router';
import { ConceptComponent } from './pages/concept/concept.component';
import { SupplierComponent } from './pages/supplier/supplier.component';
import { ConsortiumComponent } from './pages/consortium/consortium.component';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { adminGuard, authGuardNotLogin, clientGuard, consortiumGuard } from './auth/auth.guard';
import { UserComponent } from './pages/user/user.component';
import { UnitFunctionalComponent } from './pages/unit-functional/unit-functional.component';
import { ClientPageComponent } from './pages/client-page/client-page.component';
import { MovementComponent } from './pages/movement/movement.component';

export const routes: Routes = [
    { path: 'conceptos', component: ConceptComponent, canActivate: [consortiumGuard] },
    { path: 'proveedores', component: SupplierComponent, canActivate: [consortiumGuard] },
    { path: 'consorcios', component: ConsortiumComponent, canActivate: [consortiumGuard] },
    { path: 'login', component: LoginFormComponent, canActivate: [authGuardNotLogin] },
    { path: 'usuarios', component: UserComponent, canActivate: [adminGuard] },
    { path: 'unidades-funcionales', component: UnitFunctionalComponent, canActivate: [consortiumGuard] },
    { path: 'mis-unidades', component: ClientPageComponent, canActivate: [clientGuard] },
    { path: 'movimientos', component: MovementComponent, canActivate: [consortiumGuard] },
    { path: '', redirectTo: 'consorcios', pathMatch: 'full' },
    { path: '**', redirectTo: 'consorcios' }
];
