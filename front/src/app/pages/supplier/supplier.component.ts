import { Component } from '@angular/core';
import { GenericComponent } from '../generic-component.class';
import { SupplierRequest, SupplierResponse } from '../../interfaces/model.interfaces';
import { PageComponent } from '../../components/page/page.component';
import { ConfirmDialogComponent } from '../../components/confirm-dialog/confirm-dialog.component';
import { ToastComponent } from '../../components/toast/toast.component';
import { ActionButtonConfig } from '../../components/action-buttons/action-buttons.component';
import { SupplierService } from '../../services/supplier.service';
import { SupplierFormComponent } from '../../components/supplier-form/supplier-form.component';

@Component({
  selector: 'app-supplier',
  standalone: true,
  imports: [
    SupplierFormComponent,
    ConfirmDialogComponent,
    PageComponent,
    ToastComponent
  ],
  templateUrl: './supplier.component.html',
  styleUrl: './supplier.component.css'
})
export class SupplierComponent extends GenericComponent<SupplierRequest, SupplierResponse> {
  
  override title = "Proveedor";
  override labelButtonAdd = "Agregar proveedor";

  columns = [
    { header: "Nombre", field: "name", sortable: true },
    { header: "CUIT", field: "cuit", sortable: true },
    { header: "Teléfono", field: "phone", sortable: true },
    { header: "E-mail", field: "email", sortable: true }
  ];

  buttonConfig : ActionButtonConfig[] = [
    { 
      icon: 'pi pi-pencil', 
      tooltip: 'Editar registro', 
      severity: 'success', 
      action: (data: any) => this.openFormEdit(data)
    },
    { 
      icon: 'pi pi-trash', 
      tooltip: 'Borrar registro', 
      severity: 'danger',
      action: (data: any) => this.openConfirmDialog(data)
    }
  ];

  constructor(service: SupplierService) {
    super(service);
  }
}
