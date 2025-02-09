import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { MenuModule } from 'primeng/menu';
import { SidebarModule } from 'primeng/sidebar';
import { TooltipModule } from 'primeng/tooltip';
import { CommonModule } from '@angular/common';

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
    label: 'Inicio',
    icon: 'pi pi-home',
    path: 'inicio'
  },
  {
    label: 'Consorcios',
    icon: 'pi pi-building',
    path: 'consorcios'
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
  }];

  constructor (
  ){}

  sidebarStyle = {
    border: 'none',
  };

  hideEmit(){
    this.hide.emit();
  }
}
