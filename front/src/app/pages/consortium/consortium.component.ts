import { Component } from '@angular/core';
import { GenericComponent } from '../generic-component.class';
import { ConsortiumRequest, ConsortiumResponse, LiquidationRequest } from '../../interfaces/model.interfaces';
import { ConsortiumService } from '../../services/consortium.service';
import { PageComponent } from '../../components/page/page.component';
import { ConfirmDialogComponent } from '../../components/confirm-dialog/confirm-dialog.component';
import { ToastComponent } from '../../components/toast/toast.component';
import { ConsortiumFormComponent } from '../../components/consortium-form/consortium-form.component';
import { ActionButtonConfig } from '../../components/action-buttons/action-buttons.component';
import { LiquidationDialogComponent } from "../../components/liquidation-dialog/liquidation-dialog.component";
import { LiquidationService } from '../../services/liquidation.service';

@Component({
  selector: 'app-consortium',
  standalone: true,
  imports: [
    ConsortiumFormComponent,
    ConfirmDialogComponent,
    PageComponent,
    ToastComponent,
    LiquidationDialogComponent
],
  templateUrl: './consortium.component.html',
  styleUrl: './consortium.component.css'
})
export class ConsortiumComponent extends GenericComponent<ConsortiumRequest, ConsortiumResponse> { 
  override title = "Consorcios";
  override labelButtonAdd = "Agregar consorcio";

  showLiquidationDialog : boolean = false;
  consortiumId : number | undefined = undefined;

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
    },
    { 
      icon: 'pi pi-file', 
      tooltip: 'Generar liquidación', 
      severity: 'info',
      action: (data: any) => this.openLiquidationDialog(data)
    }
  ];

  constructor(service: ConsortiumService, private readonly liquidationService : LiquidationService) {
    super(service);
  }

  openLiquidationDialog(data: any){
    this.consortiumId = data.id;
    this.showLiquidationDialog = true;
  }

  generateLiquidation(event: any) {
    const request : LiquidationRequest = {
      ...event,
      consortiumId: this.consortiumId!
    }
    this.showLiquidationDialog = false;
    this.createLiquidation(request);
  }

  createLiquidation(request: LiquidationRequest) {
    this.liquidationService.generateLiquidation(request).subscribe({
      next: response => {
        this.toast.setSuccessMessage('La liquidación se ha generado correctamente.');
        this.handlePostCreate(response);
      },
      error: error => {
        this.toast.setErrorMessage('Ha ocurrido un error al generar la liquidación.');
        console.error(error);
      }
    });
  }
}
