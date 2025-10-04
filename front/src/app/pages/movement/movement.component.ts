import { Component } from '@angular/core';
import { GenericComponent } from '../generic-component.class';
import { ConceptResponse, ConsortiumResponse, MovementRequest, MovementResponse, SupplierResponse } from '../../interfaces/model.interfaces';
import { ActionButtonConfig } from '../../components/action-buttons/action-buttons.component';
import { MovementService } from '../../services/movement.service';
import { PageComponent } from '../../components/page/page.component';
import { ConfirmDialogService } from '../../components/confirm-dialog/confirm-dialog-service';
import { ToastService } from '../../components/toast/toast-service';
import { AuthService } from '../../auth/auth.service';
import { MovementFormComponent } from '../../components/movement-form/movement-form.component';
import { ConsortiumService } from '../../services/consortium.service';
import { SupplierService } from '../../services/supplier.service';
import { ConceptService } from '../../services/concept.service';
import { finalize } from 'rxjs';
import { hasValidRoles } from '../../util/rolesUtil';

@Component({
  selector: 'app-movement',
  standalone: true,
  imports: [
    PageComponent,
    MovementFormComponent
  ],
  templateUrl: './movement.component.html',
  styleUrl: './movement.component.css'
})
export class MovementComponent extends GenericComponent<MovementRequest, MovementResponse> {

  override title = "Movimientos";
  override labelButtonAdd: string = "Agregar movimiento";

  isLoadingConsortiums: boolean = true;
  isLoadingSuppliers: boolean = true;
  isLoadingConcepts: boolean = true;

  formVisible: boolean = false;

  canCreate: boolean = hasValidRoles(this.authService.userData, ["ADMIN", "STAFF"]);
  canRemove: boolean = hasValidRoles(this.authService.userData, ["ADMIN"]);

  columns = [
    { header: "Consorcio", field: "consortiumName", sortable: true },
    { header: "Fecha", field: "date", sortable: true },
    { header: "Tipo", field: "type", sortable: true },
    { header: "Monto ($)", field: "amount", sortable: true },
    { header: "Concepto", field: "conceptName", sortable: true },
    { header: "Unidad Funcional", field: "functionalUnitName", sortable: true },
    { header: "Proveedor", field: "supplierName", sortable: true },
    { header: "Recibo", field: "receipt", sortable: true },
    { header: "Comentarios", field: "comment", sortable: true }
  ];

  buttonConfig: ActionButtonConfig[] = [];

  consortiumList: ConsortiumResponse[] = [];
  supplierList: SupplierResponse[] = [];
  conceptList: ConceptResponse[] = [];

  override ngOnInit(): void {
    super.ngOnInit();
    this.loadConsortiums();
    this.loadSuppliers();
    this.loadConcepts();
    this.initButtonConfig();
  }

  constructor(
    service: MovementService,
    private readonly consortiumService: ConsortiumService,
    private readonly supplierService: SupplierService,
    private readonly conceptService: ConceptService,
    confirmService: ConfirmDialogService,
    toastService: ToastService,
    authService: AuthService
  ) {
    super(service, confirmService, toastService, authService);
  }

  loadConsortiums() {
    this.consortiumService.getAll().pipe(
      finalize(() => {
        this.isLoadingConsortiums = false;
      })
    ).subscribe({
      next: (response) => {
        this.consortiumList = this.filterData(response);
      },
      error: (error) => {
        this.hasError = true;
        console.error("Error al cargar los datos:", error);
      },
    });
  }

  loadSuppliers() {
    this.supplierService.getAll().pipe(
      finalize(() => {
        this.isLoadingSuppliers = false;
      })
    ).subscribe({
      next: (response) => {
        this.supplierList = this.filterData(response);
      },
      error: (error) => {
        this.hasError = true;
        console.error("Error al cargar los datos:", error);
      },
    });
  }

  loadConcepts() {
    this.conceptService.getAll().pipe(
      finalize(() => {
        this.isLoadingConcepts = false;
      })
    ).subscribe({
      next: (response) => {
        this.conceptList = this.filterData(response);
      },
      error: (error) => {
        this.hasError = true;
        console.error("Error al cargar los datos:", error);
      },
    });
  }

  private initButtonConfig() {
    if (this.canRemove) {
      this.buttonConfig = [
        {
          icon: 'pi pi-trash',
          tooltip: 'Borrar registro',
          severity: 'danger',
          hidden: !this.canRemove,
          action: (data: any) => this.canRemove ? this.openConfirmDialog(data) : null
        }
      ]
    }
  }

  isLoadingEntities(): boolean {
    return this.isLoadingConcepts || this.isLoadingConsortiums || this.isLoadingSuppliers;
  }

  hasErrorEntities(): boolean {
    const concepts = !this.isLoadingConcepts && this.conceptList.length <= 0;
    const consortium = !this.isLoadingConsortiums && this.consortiumList.length <= 0;
    const suppliers = !this.isLoadingSuppliers && this.supplierList.length <= 0;

    return concepts || consortium || suppliers;
  }

  filterData(response: any[]) {
    return response.filter(e => !(e as any).hasOwnProperty('active') || (e as any).active);
  }

  override transformResponseData(data: MovementResponse[]): MovementResponse[] {
    return data.sort((a, b) => b.id - a.id);
  }

  override openForm(): void {
    this.formVisible = true;
  }

  override handlePostCreate(response: any) {
    this.isEmpty = false;
    const processNewData = this.transformResponseData([response]);
    this.dataList = [processNewData[0], ...this.dataList];
  }

  override handlePostUpdate(response: any) {
    if (response === null) {
      this.updateDataListWithId(this.idToUpdate!);
    }
    this.idToUpdate = undefined;
    this.dataObject = undefined;
    this.formVisible = false;
  }

  override handleDeleteError(error: any) {
    const msg = (error?.status === 409)
      ? "No se permiten procesar movimientos para un periodo ya liquidado."
      : "Ha ocurrido un error al guardar el movimiento."
    this.toastService.setErrorMessage(msg)
    console.error("Error al guardar movimiento:", error);
  }
}
