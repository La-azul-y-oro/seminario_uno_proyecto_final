import { Component } from '@angular/core';
import { GenericComponent } from '../generic-component.class';
import { UserRequest, UserResponse } from '../../interfaces/model.interfaces';
import { ActionButtonConfig } from '../../components/action-buttons/action-buttons.component';
import { UserService } from '../../services/user.service';
import { PageComponent } from '../../components/page/page.component';
import { UserFormComponent } from '../../components/user-form/user-form.component';
import { ConfirmDialogService } from '../../components/confirm-dialog/confirm-dialog-service';
import { ToastService } from '../../components/toast/toast-service';
import { AuthService } from '../../auth/auth.service';
import { hasValidRoles } from '../../util/rolesUtil';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [
    UserFormComponent,
    PageComponent
  ],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent extends GenericComponent<UserRequest, UserResponse> {

  override title = "Usuarios";
  override labelButtonAdd = "Agregar usuario";

  canCreate: boolean = hasValidRoles(this.authService.userData, ["ADMIN"]);
  canEdit: boolean = hasValidRoles(this.authService.userData, ["ADMIN"]);
  canRemove: boolean = hasValidRoles(this.authService.userData, ["ADMIN"]);

  columns = [
    { header: "Nombre", field: "firstName", sortable: true },
    { header: "Apellido", field: "lastName", sortable: true },
    { header: "Documento", field: "documentNumber", sortable: true },
    { header: "E-mail", field: "email", sortable: true },
    { header: "Teléfono", field: "phone", sortable: true },
    { header: "Rol", field: "role", sortable: true }
  ];

  buttonConfig: ActionButtonConfig[] = [
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
    service: UserService,
    confirmService: ConfirmDialogService,
    toastService: ToastService,
    authService: AuthService
  ) {
    super(service, confirmService, toastService, authService);
  }
}
