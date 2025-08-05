import { Component } from '@angular/core';
import { GenericComponent } from '../generic-component.class';
import { ConceptResponse, ConsortiumResponse, FunctionalUnitResponse, MovementRequest, MovementResponse, SupplierResponse } from '../../interfaces/model.interfaces';
import { ActionButtonConfig } from '../../components/action-buttons/action-buttons.component';
import { MovementService } from '../../services/movement.service';
import { PageComponent } from '../../components/page/page.component';
import { ToastComponent } from '../../components/toast/toast.component';
import { ConfirmDialogComponent } from '../../components/confirm-dialog/confirm-dialog.component';
import { ConfirmDialogService } from '../../components/confirm-dialog/confirm-dialog-service';
import { ToastService } from '../../components/toast/toast-service';
import { AuthService } from '../../auth/auth.service';
import { MovementFormComponent } from '../../components/movement-form/movement-form.component';
import { ConsortiumService } from '../../services/consortium.service';
import { SupplierService } from '../../services/supplier.service';
import { FunctionalUnitService } from '../../services/functional-unit.service';
import { ConceptService } from '../../services/concept.service';
import { finalize } from 'rxjs';

@Component({
  selector: 'app-movement',
  standalone: true,
  imports: [
    PageComponent,
    ToastComponent,
    ConfirmDialogComponent,
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
  isLoadingFunctionalUnits: boolean = true;
  isLoadingConcepts: boolean = true;

  columns = [
    { header: "Consorcio", field: "consortiumName", sortable: true },
    { header: "Fecha", field: "date", sortable: true },
    { header: "Tipo", field: "movementType", sortable: true },
    { header: "Monto", field: "amount", sortable: true },
    { header: "Concepto", field: "conceptName", sortable: true },
    { header: "Unidad Funcional", field: "functionalUnitName", sortable: true },
    { header: "Proveedor", field: "supplierName", sortable: true },
    { header: "Recibo", field: "receipt", sortable: true },
    { header: "Comentarios", field: "comment", sortable: true }
  ];

  buttonConfig: ActionButtonConfig[] = [
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

  consortiumList: ConsortiumResponse[] = [];
  supplierList: SupplierResponse[] = [];
  functionalUnitList: FunctionalUnitResponse[] = [];
  conceptList: ConceptResponse[] = [];

  override ngOnInit(): void {
    super.ngOnInit();
    this.loadConsortiums();
    this.loadSuppliers();
    this.loadFunctionalUnits();
    this.loadConcepts();
  }

  constructor(
    service: MovementService, 
    private readonly consortiumService: ConsortiumService,
    private readonly supplierService: SupplierService,
    private readonly functionalUnitService: FunctionalUnitService,
    private readonly conceptService: ConceptService,
    confirmService: ConfirmDialogService, 
    toastService: ToastService, 
    authService: AuthService
  ) {
    super(service, confirmService, toastService, authService);
  }

  loadConsortiums(){
    this.consortiumService.getAll().pipe(
      finalize(() => {
        this.isLoadingConsortiums = false;
      })
    ).subscribe({
      next: (response) => {
        this.consortiumList = response.filter(e => (e as any).active);
      },
      error: (error) => {
        this.hasError = true;
        console.error("Error al cargar los datos:", error);
      },
    });
  }

  loadSuppliers(){
    this.supplierService.getAll().pipe(
      finalize(() => {
        this.isLoadingSuppliers = false;
      })
    ).subscribe({
      next: (response) => {
        this.supplierList = response.filter(e => (e as any).active);
      },
      error: (error) => {
        this.hasError = true;
        console.error("Error al cargar los datos:", error);
      },
    });
  }

  loadFunctionalUnits(){
    this.functionalUnitService.getAll().pipe(
      finalize(() => {
        this.isLoadingFunctionalUnits = false;
      })
    ).subscribe({
      next: (response) => {
        this.functionalUnitList = response.filter(e => (e as any).active);
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
        this.conceptList = response.filter(e => (e as any).active);
      },
      error: (error) => {
        this.hasError = true;
        console.error("Error al cargar los datos:", error);
      },
    });
  }

  isLoadingEntities(): boolean{
    return this.isLoadingConcepts || this.isLoadingConsortiums || this.isLoadingFunctionalUnits || this.isLoadingSuppliers;
  }
}
