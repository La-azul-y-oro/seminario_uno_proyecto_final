import { Component } from '@angular/core';
import { GenericComponent } from '../generic-component.class';
import { MovementRequest, MovementResponse } from '../../interfaces/model.interfaces';
import { ActionButtonConfig } from '../../components/action-buttons/action-buttons.component';
import { MovementService } from '../../services/movement.service';
import { PageComponent } from '../../components/page/page.component';
import { ToastComponent } from '../../components/toast/toast.component';
import { ConfirmDialogComponent } from '../../components/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-movement',
  standalone: true,
  imports: [
    PageComponent,
    ToastComponent,
    ConfirmDialogComponent
  ],
  templateUrl: './movement.component.html',
  styleUrl: './movement.component.css'
})
export class MovementComponent extends GenericComponent<MovementRequest, MovementResponse> {

  override title = "Movimientos";
  override labelButtonAdd: string = "Agregar movimiento";

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

  constructor(service: MovementService) {
    super(service);
  }
}
