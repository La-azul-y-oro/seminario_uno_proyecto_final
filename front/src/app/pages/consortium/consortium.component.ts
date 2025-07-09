import { Component } from '@angular/core';
import { GenericComponent } from '../generic-component.class';
import { Client, ConsortiumRequest, ConsortiumResponse, ExpensesRequest, FinancialRequest, LiquidationRequest, UnitFunctionalConsortium } from '../../interfaces/model.interfaces';
import { ConsortiumService } from '../../services/consortium.service';
import { PageComponent } from '../../components/page/page.component';
import { ConsortiumFormComponent } from '../../components/consortium-form/consortium-form.component';
import { ActionButtonConfig } from '../../components/action-buttons/action-buttons.component';
import { LiquidationDialogComponent } from "../../components/liquidation-dialog/liquidation-dialog.component";
import { LiquidationService } from '../../services/liquidation.service';
import { ReportDialogComponent } from '../../components/report-dialog/report-dialog.component';
import { ReportService } from '../../services/report.service';
import { FunctionalUnitDialogComponent } from '../../components/functional-unit-dialog/functional-unit-dialog.component';
import { FunctionalUnitService } from '../../services/functional-unit.service';
import { concat, Observable } from 'rxjs';
import { ColumnExpandData } from '../../interfaces/components.interface';
import { ClientDialogComponent } from "../../components/client-dialog/client-dialog.component";
import { UserService } from '../../services/user.service';
import { ConfirmDialogService } from '../../components/confirm-dialog/confirm-dialog-service';
import { ToastService } from '../../components/toast/toast-service';

@Component({
  selector: 'app-consortium',
  standalone: true,
  imports: [
    ConsortiumFormComponent,
    PageComponent,
    LiquidationDialogComponent,
    ReportDialogComponent,
    FunctionalUnitDialogComponent,
    ClientDialogComponent
  ],
  templateUrl: './consortium.component.html',
  styleUrl: './consortium.component.css'
})
export class ConsortiumComponent extends GenericComponent<ConsortiumRequest, ConsortiumResponse> {
  override title = "Consorcios";
  override labelButtonAdd = "Agregar consorcio";

  showLiquidationDialog: boolean = false;
  showReportDialog: boolean = false;
  showFunctionalUnitDialog: boolean = false;
  showBindUsersDialog: boolean = false;

  consortiumId: number | undefined = undefined;
  functionalUnit: UnitFunctionalConsortium | undefined = undefined;

  clients: Client[] = [];

  columns = [
    { header: "Nombre", field: "name", sortable: true },
    { header: "Dirección", field: "address", sortable: true }
  ];

  override expandData: ColumnExpandData = {
    key: "functionalUnits",
    column: [
      { header: "Unidad", field: "name", sortable: true },
      { header: "Factor (%)", field: "factor", sortable: true },
      { header: "Balance ($)", field: "balance", sortable: true }
    ],
    actionButtons: [{
      icon: 'pi pi-user-plus',
      tooltip: 'Clientes vinculados',
      severity: 'success',
      action: (data: any) => this.openBindUsersForm(data)
    }]
  }

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
    },
    {
      icon: 'pi pi-file',
      tooltip: 'Generar liquidación',
      severity: 'info',
      action: (data: any) => this.openLiquidationDialog(data)
    },
    {
      icon: 'pi pi-chart-bar',
      tooltip: 'Descargar reportes',
      severity: 'warning',
      action: (data: any) => this.openReportDialog(data)
    },
    {
      icon: 'pi pi-home',
      tooltip: 'Unidades funcionales',
      severity: 'secondary',
      action: (data: any) => this.openFunctionalUnitDialog(data)
    }
  ];

  constructor(
    service: ConsortiumService,
    private readonly liquidationService: LiquidationService,
    private readonly reportService: ReportService,
    private readonly functionalUnitService: FunctionalUnitService,
    private readonly userService: UserService,
    confirmService: ConfirmDialogService,
    toastService: ToastService
  ) {
    super(service, confirmService, toastService);
  }

  override ngOnInit() {
    super.ngOnInit();
    this.getClients();
  }

  openLiquidationDialog(data: any) {
    this.consortiumId = data.id;
    this.showLiquidationDialog = true;
  }

  openReportDialog(data: any) {
    this.consortiumId = data.id;
    this.showReportDialog = true;
  }

  openFunctionalUnitDialog(data: any) {
    this.consortiumId = data.id;
    this.showFunctionalUnitDialog = true;
  }

  openBindUsersForm(data: any) {
    this.functionalUnit = data.row;
    this.consortiumId = data.parent;
    this.showBindUsersDialog = true;
  }

  generateLiquidation(event: any) {
    const request: LiquidationRequest = {
      ...event,
      consortiumId: this.consortiumId!
    }
    this.showLiquidationDialog = false;
    this.createLiquidation(request);
  }

  createLiquidation(request: LiquidationRequest) {
    this.liquidationService.generateLiquidation(request).subscribe({
      next: () => {
        this.toastService.setSuccessMessage('La liquidación se ha generado correctamente.');
      },
      error: error => {
        this.toastService.setErrorMessage('Ha ocurrido un error al generar la liquidación.');
        console.error(error);
      }
    });
  }

  getExpensesReport(request: ExpensesRequest) {
    this.reportService.getExpenseReport(request).subscribe({
      next: (blob) => {
        const filename = `liquidacion_expensas_${request.month}_${request.year}.pdf`;

        const url = window.URL.createObjectURL(blob);
        const link = document.createElement('a');
        link.href = url;
        link.download = filename;
        link.click();
        window.URL.revokeObjectURL(url);

        this.showLiquidationDialog = false;
        this.toastService.setSuccessMessage('Las expensas se han descargado correctamente.');
      },
      error: (error) => {
        this.toastService.setErrorMessage('Ha ocurrido un error al obtener las expensas');
        console.error(error);
      }
    });
  }

  getFinancialReport(request: FinancialRequest) {
    this.reportService.getFinancialReport(request).subscribe({
      next: (blob) => {
        let filename = 'reporte_financiero_';
        if (request.month) filename = filename.concat(`${request.month}_`)
        filename = filename.concat(`${request.year}${request.format.toLowerCase() === 'pdf' ? '.pdf' : '.xlsx'}`)

        const url = window.URL.createObjectURL(blob);
        const link = document.createElement('a');
        link.href = url;
        link.download = filename;
        link.click();
        window.URL.revokeObjectURL(url);

        this.showLiquidationDialog = false;
        this.toastService.setSuccessMessage('El reporte financiero se ha descargado correctamente.');
      },
      error: (error) => {
        this.toastService.setErrorMessage('Ha ocurrido un error al obtener el reporte financiero');
        console.error(error);
      }
    });
  }

  resetUnitFunctionalData() {
    this.consortiumId = undefined;
    this.showFunctionalUnitDialog = false;
  }

  resetClientsData(functionalUnit: any) {
    this.updateConsortiumData(functionalUnit);
    this.consortiumId = undefined;
    this.functionalUnit = undefined;
    this.showBindUsersDialog = false;
  }

  saveFunctionalUnits(event: any) {
    const toCreate = event.create ?? [];
    const toUpdate = event.update ?? [];
    const toDelete = event.delete ?? [];

    const createRequests: Observable<any>[] = toCreate.map((e: any) =>
      this.functionalUnitService.create(e)
    );

    const updateRequests: Observable<any>[] = toUpdate.map((e: any) =>
      this.functionalUnitService.update(e.id, e)
    );

    const deleteRequests: Observable<any>[] = toDelete.map((id: any) =>
      this.functionalUnitService.deleteById(id)
    );

    const allRequests: Observable<any>[] = [
      ...deleteRequests,
      ...updateRequests,
      ...createRequests
    ];

    if (allRequests.length > 0) {
      concat(...allRequests).subscribe({
        next: () => {
        },
        complete: () => {
          this.showFunctionalUnitDialog = false;
          this.consortiumId = undefined;

          this.toastService.setSuccessMessage('Se han actualizado las unidades funcionales.');
        },
        error: (err) => {
          console.error("Error al guardar unidades funcionales", err);
          this.toastService.setErrorMessage("Ha ocurrido un error al guardar los cambios");
        }
      });
    } else {
      this.showFunctionalUnitDialog = false;
      this.consortiumId = undefined;
    }
  }

  getClients() {
    this.userService.getAllClients().subscribe({
      next: (response) => {
        this.clients = response;
      },
      error: (error) => {
        console.error(error);
      }
    })
  }

  updateConsortiumData(functionalUnit: any) {
    const consortium = this.dataList.find(c => c.id == this.consortiumId);

    if (consortium && consortium.functionalUnits) {
      let index = consortium.functionalUnits.findIndex(fu => fu.id === functionalUnit.id);

      if (index !== -1) {
        consortium.functionalUnits[index] = functionalUnit;
      }
    }
  }
}
