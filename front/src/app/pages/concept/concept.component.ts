import { Component } from '@angular/core';
import { GenericComponent } from '../generic-component.class';
import { ConceptRequest, ConceptResponse } from '../../interfaces/model.interfaces';
import { ConceptService } from '../../services/concept.service';
import { PageComponent } from '../../components/page/page.component';
import { ConfirmDialogComponent } from '../../components/confirm-dialog/confirm-dialog.component';
import { ToastComponent } from '../../components/toast/toast.component';
import { ConceptFormComponent } from '../../components/concept-form/concept-form.component';
import { ActionButtonConfig } from '../../components/action-buttons/action-buttons.component';

@Component({
  selector: 'app-concept',
  standalone: true,
  imports: [
    ConceptFormComponent,
    ConfirmDialogComponent,
    PageComponent,
    ToastComponent
  ],
  templateUrl: './concept.component.html',
  styleUrl: './concept.component.css'
})
export class ConceptComponent extends GenericComponent<ConceptRequest, ConceptResponse> {
  
  override title = "Conceptos";
  override labelButtonAdd = "Agregar concepto";

  columns = [
    { header: "Nombre", field: "name", sortable: true }
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

  constructor(service: ConceptService) {
    super(service);
  }
}
