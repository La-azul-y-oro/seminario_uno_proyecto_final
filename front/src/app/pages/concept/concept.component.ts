import { Component } from '@angular/core';
import { GenericComponent } from '../generic-component.class';
import { ConceptRequest, ConceptResponse } from '../../interfaces/model.interfaces';
import { ConceptService } from '../../services/concept.service';
import { PageComponent } from '../../components/page/page.component';
import { ConceptFormComponent } from '../../components/concept-form/concept-form.component';
import { ActionButtonConfig } from '../../components/action-buttons/action-buttons.component';
import { ConfirmDialogService } from '../../components/confirm-dialog/confirm-dialog-service';
import { ToastService } from '../../components/toast/toast-service';
import { hasValidRoles } from '../../util/rolesUtil';
import { AuthService } from '../../auth/auth.service';

@Component({
  selector: 'app-concept',
  standalone: true,
  imports: [
    ConceptFormComponent,
    PageComponent
  ],
  templateUrl: './concept.component.html',
  styleUrl: './concept.component.css'
})
export class ConceptComponent extends GenericComponent<ConceptRequest, ConceptResponse> {
  
  override title = "Conceptos";
  override labelButtonAdd = "Agregar concepto";

  canCreate : boolean = hasValidRoles(this.authService.userData, ["ADMIN", "STAFF"]);
  canEdit : boolean = hasValidRoles(this.authService.userData, ["ADMIN", "STAFF"]);
  canRemove : boolean = hasValidRoles(this.authService.userData, ["ADMIN", "STAFF"]);

  columns = [
    { header: "Nombre", field: "name", sortable: true },
    { header: "Tipo", field: "type", sortable: true }
  ];

  buttonConfig : ActionButtonConfig[] = [
    { 
      icon: 'pi pi-pencil', 
      tooltip: 'Editar registro', 
      severity: 'success', 
      hidden: !this.canEdit,
      action: (data: any) => this.canEdit ? this.openFormEdit(data) : null
    },
    { 
      icon: 'pi pi-trash', 
      tooltip: 'Borrar registro', 
      severity: 'danger',
      hidden: !this.canRemove,
      action: (data: any) => this.canRemove ? this.openConfirmDialog(data) : null
    }
  ];

  constructor(
    service: ConceptService,
    confirmService: ConfirmDialogService,
    toastService: ToastService,
    authService: AuthService  
  ) {
    super(service, confirmService, toastService, authService);
  }
}
