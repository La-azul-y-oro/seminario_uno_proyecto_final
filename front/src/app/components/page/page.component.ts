import { Component, EventEmitter, Input, Output, TemplateRef, ViewChild } from '@angular/core';
import { Table, TableModule, TableRowCollapseEvent, TableRowExpandEvent } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { TooltipModule } from 'primeng/tooltip';
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';
import { InputTextModule } from 'primeng/inputtext';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { CommonModule } from '@angular/common';
import { Column, ColumnExpandData } from '../../interfaces/components.interface';
import { ActionButtonsComponent, ActionButtonConfig } from '../action-buttons/action-buttons.component';
import { Role } from '../../interfaces/model.interfaces';

@Component({
  selector: 'app-page',
  standalone: true,
  imports: [
    ActionButtonsComponent,
    CommonModule,
    ButtonModule,
    IconFieldModule,
    InputTextModule,
    InputIconModule,
    ProgressSpinnerModule,
    TableModule,
    TooltipModule],
  templateUrl: './page.component.html',
  styleUrl: './page.component.css'
})
export class PageComponent {
  @ViewChild('table') dt!: Table;

  @Input() title?: string = "";
  @Input() labelButtonAdd?: string = "";
  @Input() data: any[] = [];
  @Input() cols!: Column[];
  @Input() buttonConfig!: ActionButtonConfig[];
  @Input() canCreate: boolean = true; //TODO ajustar cuando se avance con la seguridad (iniciar en false)
  @Input() isLoading: boolean = false;
  @Input() hasError: boolean = false;
  @Input() isEmpty: boolean = false;
  @Input() hideCreateButton: boolean = false;

  @Output() onCreate = new EventEmitter;

  @Input() expandable: boolean = false;
  @Input() expandData?: ColumnExpandData;

  expandedRows: { [key: string]: boolean } = {};

  buttonStyle = {
    fontSize: '0.8rem'
  };

  iconFieldStyle = {
    fontSize: '0.8rem',
    paddingTop: '0.5rem',
    paddingBottom: '0.5rem',
  };

  create() {
    if (!this.canCreate) return;
    this.onCreate.emit();
  }

  filter(event: any) {
    this.dt.filterGlobal(event.target.value, 'contains');
  }


  getDisplayValue(rowData: any, field: string): any {
    const value = this.getNestedProperty(rowData, field);

    if (field === 'role' && value in Role) {
      return Role[value as keyof typeof Role]; // Traducir la key al valor
    }

    return value;
  }

  getNestedProperty(obj: any, path: string): any {
    return path.split('.').reduce((o, p) => o && o[p], obj);
  }

  showColumnActionButtons(): boolean {
    return this.buttonConfig.length > 0;
  }

  onRowExpand(event: any) {
    const id = event.data?.id;
    if (id != null) {
      this.expandedRows[id] = true;
    }
  }

  onRowCollapse(event: any) {
    const id = event.data?.id;
    if (id != null) {
      delete this.expandedRows[id];
    }
  }

  getData(data: any): any[] {
    const key = this.expandData?.key;
    return key ? data[key] : [];
  }

  getTotalColumns(): number {
    return this.cols.length + (this.expandable ? 1 : 0) + (this.showColumnActionButtons() ? 1 : 0);
  }

}
