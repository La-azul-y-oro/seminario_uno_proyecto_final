import { Routes } from '@angular/router';
import { ConceptComponent } from './pages/concept/concept.component';
import { SupplierComponent } from './pages/supplier/supplier.component';
import { ConsortiumComponent } from './pages/consortium/consortium.component';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { authGuard, authGuardNotLogin } from './auth/auth.guard';

export const routes: Routes = [
    //TODO CUANDO ESTEN DEFINIDOS LOS ROLES PARA VER LAS PAGINAS, AGREGAR GUARDAS
    { path: 'conceptos', component: ConceptComponent, canActivate: [authGuard]},
    { path: 'proveedores', component: SupplierComponent, canActivate: [authGuard]},
    { path: 'consorcios', component: ConsortiumComponent, canActivate: [authGuard]},
    { path: 'login', component: LoginFormComponent, canActivate: [authGuardNotLogin] },
    // TODO agregar esto cuando tengamos el componente de inicio
    // { path: 'inicio', component: HomeComponent},
    { path: '', redirectTo: 'conceptos', pathMatch: 'full' },
    { path: '**', redirectTo: 'conceptos' }
];
