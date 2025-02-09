import { Component } from '@angular/core';
import { GenericComponent } from '../generic-component.class';
import { ConsortiumRequest, ConsortiumResponse } from '../../interfaces/model.interfaces';
import { ConsortiumService } from '../../services/consortium.service';
import { PageComponent } from '../../components/page/page.component';
import { ConfirmDialogComponent } from '../../components/confirm-dialog/confirm-dialog.component';
import { ToastComponent } from '../../components/toast/toast.component';
import { ConsortiumFormComponent } from '../../components/consortium-form/consortium-form.component';
import { ActionButtonConfig } from '../../components/action-buttons/action-buttons.component';

@Component({
  selector: 'app-consortium',
  standalone: true,
  imports: [
    ConsortiumFormComponent,
    ConfirmDialogComponent,
    PageComponent,
    ToastComponent
  ],
  templateUrl: './consortium.component.html',
  styleUrl: './consortium.component.css'
})
export class ConsortiumComponent extends GenericComponent<ConsortiumRequest, ConsortiumResponse> {
  
  override title = "Consorcios";
  override labelButtonAdd = "Agregar consorcio";

  columns = [
    { header: "Nombre", field: "name", sortable: true },
    { header: "Dirección", field: "address", sortable: true }
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

  constructor(service: ConsortiumService) {
    super(service);
  }
}

