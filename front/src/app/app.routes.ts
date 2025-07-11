import { Routes } from '@angular/router';
import { ConceptComponent } from './pages/concept/concept.component';
import { SupplierComponent } from './pages/supplier/supplier.component';
import { ConsortiumComponent } from './pages/consortium/consortium.component';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { authGuardNotLogin, clientGuard, consortiumGuard } from './auth/auth.guard';
import { UserComponent } from './pages/user/user.component';
import { UnitFunctionalComponent } from './pages/unit-functional/unit-functional.component';
import { ClientPageComponent } from './pages/client-page/client-page.component';

export const routes: Routes = [
    //TODO CUANDO ESTEN DEFINIDOS LOS ROLES PARA VER LAS PAGINAS, AGREGAR GUARDAS
    { path: 'conceptos', component: ConceptComponent, canActivate: [consortiumGuard] },
    { path: 'proveedores', component: SupplierComponent, canActivate: [consortiumGuard] },
    { path: 'consorcios', component: ConsortiumComponent, canActivate: [consortiumGuard] },
    { path: 'login', component: LoginFormComponent, canActivate: [authGuardNotLogin] },
    { path: 'usuarios', component: UserComponent, canActivate: [consortiumGuard] },
    { path: 'unidades-funcionales', component: UnitFunctionalComponent, canActivate: [consortiumGuard] },
    { path: 'mis-unidades', component: ClientPageComponent, canActivate: [clientGuard] },
    // TODO agregar esto cuando tengamos el componente de inicio
    // { path: 'inicio', component: HomeComponent},
    { path: '', redirectTo: 'conceptos', pathMatch: 'full' },
    { path: '**', redirectTo: 'conceptos' }
];
