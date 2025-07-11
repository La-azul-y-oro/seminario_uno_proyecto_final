import { Component } from '@angular/core';
import { GenericComponent } from '../generic-component.class';
import { ConceptResponse, SupplierRequest, SupplierResponse } from '../../interfaces/model.interfaces';
import { PageComponent } from '../../components/page/page.component';
import { ActionButtonConfig } from '../../components/action-buttons/action-buttons.component';
import { SupplierService } from '../../services/supplier.service';
import { SupplierFormComponent } from '../../components/supplier-form/supplier-form.component';
import { ConceptService } from '../../services/concept.service';
import { finalize } from 'rxjs';
import { ConfirmDialogService } from '../../components/confirm-dialog/confirm-dialog-service';
import { ToastService } from '../../components/toast/toast-service';
import { AuthService } from '../../auth/auth.service';
import { hasValidRoles } from '../../util/rolesUtil';

@Component({
  selector: 'app-supplier',
  standalone: true,
  imports: [
    SupplierFormComponent,
    PageComponent
  ],
  templateUrl: './supplier.component.html',
  styleUrl: './supplier.component.css'
})
export class SupplierComponent extends GenericComponent<SupplierRequest, SupplierResponse> {
  override title = "Proveedor";
  override labelButtonAdd = "Agregar proveedor";
  isLoadingConcepts: boolean = true;

  canCreate: boolean = hasValidRoles(this.authService.userData, ["ADMIN", "STAFF"]);
  canEdit: boolean = hasValidRoles(this.authService.userData, ["ADMIN", "STAFF"]);
  canRemove: boolean = hasValidRoles(this.authService.userData, ["ADMIN", "STAFF"]);

  columns = [
    { header: "Nombre", field: "name", sortable: true },
    { header: "CUIT", field: "cuit", sortable: true },
    { header: "Teléfono", field: "phone", sortable: true },
    { header: "E-mail", field: "email", sortable: true },
    { header: "Categorias", field: "categories" }
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

  conceptList: ConceptResponse[] = [];

  override ngOnInit() {
    super.ngOnInit();
    this.loadConcepts();
  }

  constructor(
    service: SupplierService,
    private readonly conceptService: ConceptService,
    confirmService: ConfirmDialogService,
    toastService: ToastService,
    authService: AuthService
  ) {
    super(service, confirmService, toastService, authService);
  }

  override transformResponseData(data: SupplierResponse[]): any[] {
    const transformedData = data.map(supplier => ({
      ...supplier,
      categories: supplier.concepts?.map((concept: ConceptResponse) => concept.name).join(', ')
    }));
    return transformedData;
  }

  loadConcepts() {
    this.conceptService.getAll().pipe(
      finalize(() => {
        this.isLoadingConcepts = false;
      })
    ).subscribe({
      next: (response) => {
        this.conceptList = response.filter(e => (e as any).active);
      },
      error: (error) => {
        this.hasError = true;
        console.error("Error al cargar los datos:", error);
      },
    });
  }

}
