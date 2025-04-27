import { Component } from '@angular/core';
import { GenericComponent } from '../generic-component.class';
import { UserRequest, UserResponse } from '../../interfaces/model.interfaces';
import { ActionButtonConfig } from '../../components/action-buttons/action-buttons.component';
import { UserService } from '../../services/user.service';
import { ConfirmDialogComponent } from '../../components/confirm-dialog/confirm-dialog.component';
import { PageComponent } from '../../components/page/page.component';
import { ToastComponent } from '../../components/toast/toast.component';
import { UserFormComponent } from '../../components/user-form/user-form.component';

@Component({
  selector: 'app-user',
  standalone: true,
    imports: [
      UserFormComponent,
      ConfirmDialogComponent,
      PageComponent,
      ToastComponent
    ],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent extends GenericComponent<UserRequest, UserResponse>{
    
    override title = "Usuarios";
    override labelButtonAdd = "Agregar usuario";
  
    columns = [
      { header: "Nombre", field: "firstName", sortable: true },
      { header: "Apellido", field: "lastName", sortable: true },
      { header: "Documento", field: "documentNumber", sortable: true },
      { header: "E-mail", field: "email", sortable: true },
      { header: "Teléfono", field: "phone", sortable: true },
      { header: "Rol", field: "role", sortable: true }
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
  
    constructor(service: UserService) {
      super(service);
    }
}
