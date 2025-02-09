import { Routes } from '@angular/router';
import { ConceptComponent } from './pages/concept/concept.component';
import { SupplierComponent } from './pages/supplier/supplier.component';
import { ConsortiumComponent } from './pages/consortium/consortium.component';

export const routes: Routes = [

    { path: 'conceptos', component: ConceptComponent},
    { path: 'proveedores', component: SupplierComponent},
    { path: 'consorcios', component: ConsortiumComponent},
    // { path: 'login', component: LoginFormComponent},
    // TODO agregar esto cuando tengamos el componente de inicio
    // { path: 'inicio', component: HomeComponent},
    // { path: '', redirectTo: 'inicio', pathMatch: 'full' },
    // { path: '**', redirectTo: 'inicio' }
];
