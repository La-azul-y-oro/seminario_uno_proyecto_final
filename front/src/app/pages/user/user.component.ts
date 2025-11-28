import { Component } from '@angular/core';
import { GenericComponent } from '../generic-component.class';
import { Client, ConsortiumResponse, FunctionalUnitResponse, Role, UserRequest, UserResponse } from '../../interfaces/model.interfaces';
import { ActionButtonConfig } from '../../components/action-buttons/action-buttons.component';
import { UserService } from '../../services/user.service';
import { PageComponent } from '../../components/page/page.component';
import { UserFormComponent } from '../../components/user-form/user-form.component';
import { ConfirmDialogService } from '../../components/confirm-dialog/confirm-dialog-service';
import { ToastService } from '../../components/toast/toast-service';
import { AuthService } from '../../auth/auth.service';
import { hasValidRoles } from '../../util/rolesUtil';
import { FunctionalUnitService } from '../../services/functional-unit.service';
import { UserFunctionalunitFormComponent } from '../../components/user-functionalunit-form/user-functionalunit-form.component';
import { ConsortiumService } from '../../services/consortium.service';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [
    UserFormComponent,
    UserFunctionalunitFormComponent,
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

  clients: Client[] = [];
  selectedClient!: UserResponse;
  functionalUnits: FunctionalUnitResponse[] = [];
  consortiums: ConsortiumResponse[] = [];

  openUserFunctionalUnitForm: boolean = false;

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
      action: (data: any) => this.canRemove ? this.handleRemoveUser(data) : null
    },
    {
      icon: 'pi pi-home',
      tooltip: 'Asignar unidades funcionales',
      severity: 'info',
      hidden: (row: UserResponse) => (row.role.toString() !== 'CLIENT'),
      action: (row: any) => this.handleOpenUserFunctionalUnitForm(row)
    }
  ];

  constructor(
    private readonly userService: UserService,
    private readonly functionalUnitService: FunctionalUnitService,
    private readonly consortiumService: ConsortiumService,
    confirmService: ConfirmDialogService,
    toastService: ToastService,
    authService: AuthService
  ) {
    super(userService, confirmService, toastService, authService);
  }

  override ngOnInit(): void {
    super.ngOnInit();
    this.getClients();
    this.getFunctionalUnits();
    this.getConsortiums();
  }

  handleRemoveUser(data: any) {
    const userEmail = this.authService.userData?.sub;
    if(userEmail === data.email){
      this.toastService.setErrorMessage('El usuario que intenta eliminar es el mismo con el que se encuentra logueado.');
    } else{
      this.openConfirmDialog(data)
    }
  }

  getClients(){
    this.userService.getAllClients().subscribe({
      next: (response) => {
        this.clients = response;
      },      
      error: (error) => {
        console.error(error);
      }
    })
  }

  getFunctionalUnits(){
    this.functionalUnitService.getAll().subscribe({
      next: (response) => {
        this.functionalUnits = response;
      },
      error: (error) => {
        console.error(error);
      }
    })
  }

  getConsortiums(){
    this.consortiumService.getAll().subscribe({
      next: (response) => {
        this.consortiums = response;
      },
      error: (error) => {
        console.error(error);
      }
    })
  }

  handleOpenUserFunctionalUnitForm(user: UserResponse){
    this.selectedClient = user;
    this.openUserFunctionalUnitForm = true;
  }

  handleCloseUserFunctionalUnitForm(){
    this.openUserFunctionalUnitForm = false;
  }

}