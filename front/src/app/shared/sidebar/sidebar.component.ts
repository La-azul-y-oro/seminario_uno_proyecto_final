import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { MenuModule } from 'primeng/menu';
import { SidebarModule } from 'primeng/sidebar';
import { TooltipModule } from 'primeng/tooltip';
import { CommonModule } from '@angular/common';
import { hasValidRoles } from '../../util/rolesUtil';
import { AuthService } from '../../auth/auth.service';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [
    CommonModule,
    MenuModule,
    SidebarModule,
    TooltipModule
  ],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css'
})
export class SidebarComponent {
  @Input() visible : boolean = false;
  @Output() hide = new EventEmitter;

  textTooltip : string = "Función no disponible";

  year : number = new Date().getFullYear();

  menubarStyle = {
    width: '100%',
  };

  items: MenuItem[] = [
  {
    label: 'Consorcios',
    icon: 'pi pi-building',
    path: 'consorcios'
  },
  {
    label: 'Unidades Funcionales',
    icon: 'pi pi-home',
    path: 'unidades-funcionales'
  },
  {
    label: 'Movimientos',
    icon: 'pi pi-arrow-right-arrow-left',
    path: 'movimientos'
  },
  {
    label: 'Conceptos',
    icon: 'pi pi-book',
    path: 'conceptos'
  },
  {
    label: 'Proveedores',
    icon: 'pi pi-warehouse',
    path: 'proveedores'
  },
  {
    label: 'Usuarios',
    icon: 'pi pi-users',
    path: 'usuarios',
    visible: hasValidRoles(this.authService.currentUserData, ["ADMIN"])
  }];

  constructor (
    private readonly authService: AuthService
  ){}

  sidebarStyle = {
    border: 'none',
  };

  hideEmit(){
    this.hide.emit();
  }
}
