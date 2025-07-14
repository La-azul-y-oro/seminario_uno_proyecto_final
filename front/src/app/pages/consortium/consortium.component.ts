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
import { AuthService } from '../../auth/auth.service';
import { hasValidRoles } from '../../util/rolesUtil';

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
  functionalUnitList: any[] = [];

  clients: Client[] = [];

  columns = [
    { header: "Nombre", field: "name", sortable: true },
    { header: "Dirección", field: "address", sortable: true }
  ];

  canCreate : boolean = hasValidRoles(this.authService.userData, ["ADMIN", "STAFF"]);
  canEdit : boolean = hasValidRoles(this.authService.userData, ["ADMIN", "STAFF"]);
  canRemove : boolean = hasValidRoles(this.authService.userData, ["ADMIN"]);
  canGenerateLiquidation: boolean = hasValidRoles(this.authService.userData, ["ADMIN", "STAFF"]);
  canGetReport: boolean = hasValidRoles(this.authService.userData, ["ADMIN", "STAFF"]);
  canManageFunctionalUnit: boolean = hasValidRoles(this.authService.userData, ["ADMIN", "STAFF"]);
  canManageClients: boolean = hasValidRoles(this.authService.userData, ["ADMIN", "STAFF"]);

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
      isDisabled: !this.canManageClients,
      action: (data: any) => this.canManageClients ? this.openBindUsersForm(data) : null
    }]
  }

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
    },
    {
      icon: 'pi pi-file',
      tooltip: 'Generar liquidación',
      severity: 'info',
      hidden: !this.canGenerateLiquidation,
      action: (data: any) => !this.canGenerateLiquidation ? this.openLiquidationDialog(data) : null
    },
    {
      icon: 'pi pi-chart-bar',
      tooltip: 'Descargar reportes',
      severity: 'warning',
      hidden: !this.canGetReport,
      action: (data: any) => this.canGetReport ? this.openReportDialog(data) : null
    },
    {
      icon: 'pi pi-home',
      tooltip: 'Unidades funcionales',
      severity: 'secondary',
      hidden: !this.canManageFunctionalUnit,
      action: (data: any) => this.canManageFunctionalUnit ? this.openFunctionalUnitDialog(data) : null
    }
  ];

  constructor(
    service: ConsortiumService,
    private readonly liquidationService: LiquidationService,
    private readonly reportService: ReportService,
    private readonly functionalUnitService: FunctionalUnitService,
    private readonly userService: UserService,
    confirmService: ConfirmDialogService,
    toastService: ToastService,
    authService: AuthService  
  ) {
    super(service, confirmService, toastService, authService);
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
    this.functionalUnitList = data.functionalUnits;
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
    this.consortiumId = undefined;
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

  resetUnitFunctionalData(data: UnitFunctionalConsortium[]) {
    if(data.length > 0){
      const index = this.dataList.findIndex(c => c.id === this.consortiumId);
      if(index !== -1){
        this.dataList[index] = {
          ...this.dataList[index],
          functionalUnits: data
        };
      }
    }
    
    this.consortiumId = undefined;
    this.functionalUnitList =  [];
    this.showFunctionalUnitDialog = false;
  }

  resetClientsData(functionalUnit: any) {
    this.updateConsortiumData(functionalUnit);
    this.consortiumId = undefined;
    this.functionalUnit = undefined;
    this.showBindUsersDialog = false;
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
