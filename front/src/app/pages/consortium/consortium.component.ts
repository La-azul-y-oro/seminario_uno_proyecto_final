import { Component } from '@angular/core';
import { GenericComponent } from '../generic-component.class';
import { ConsortiumRequest, ConsortiumResponse, ExpensesRequest, FinancialRequest, LiquidationRequest } from '../../interfaces/model.interfaces';
import { ConsortiumService } from '../../services/consortium.service';
import { PageComponent } from '../../components/page/page.component';
import { ConfirmDialogComponent } from '../../components/confirm-dialog/confirm-dialog.component';
import { ToastComponent } from '../../components/toast/toast.component';
import { ConsortiumFormComponent } from '../../components/consortium-form/consortium-form.component';
import { ActionButtonConfig } from '../../components/action-buttons/action-buttons.component';
import { LiquidationDialogComponent } from "../../components/liquidation-dialog/liquidation-dialog.component";
import { LiquidationService } from '../../services/liquidation.service';
import { ReportDialogComponent } from '../../components/report-dialog/report-dialog.component';
import { ReportService } from '../../services/report.service';

@Component({
  selector: 'app-consortium',
  standalone: true,
  imports: [
    ConsortiumFormComponent,
    ConfirmDialogComponent,
    PageComponent,
    ToastComponent,
    LiquidationDialogComponent,
    ReportDialogComponent
  ],
  templateUrl: './consortium.component.html',
  styleUrl: './consortium.component.css'
})
export class ConsortiumComponent extends GenericComponent<ConsortiumRequest, ConsortiumResponse> {
  override title = "Consorcios";
  override labelButtonAdd = "Agregar consorcio";

  showLiquidationDialog: boolean = false;
  showReportDialog: boolean = false;
  consortiumId: number | undefined = undefined;

  columns = [
    { header: "Nombre", field: "name", sortable: true },
    { header: "Dirección", field: "address", sortable: true }
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
    }
  ];

  constructor(
    service: ConsortiumService,
    private readonly liquidationService: LiquidationService,
    private readonly reportService: ReportService
  ) {
    super(service);
  }

  openLiquidationDialog(data: any) {
    this.consortiumId = data.id;
    this.showLiquidationDialog = true;
  }

  openReportDialog(data: any) {
    this.consortiumId = data.id;
    this.showReportDialog = true;
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
        this.toast.setSuccessMessage('La liquidación se ha generado correctamente.');
      },
      error: error => {
        this.toast.setErrorMessage('Ha ocurrido un error al generar la liquidación.');
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

        this.toast.setSuccessMessage('Las expensas se han descargado correctamente.');
      },
      error: (error) => {
        this.toast.setErrorMessage('Ha ocurrido un error al obtener las expensas');
        console.error(error);
      }
    });
  }

  getFinancialReport(request: FinancialRequest){
      this.reportService.getFinancialReport(request).subscribe({
      next: (blob) => {
        let filename = 'reporte_financiero_';
        if(request.month) filename = filename.concat(`${request.month}_`)
        filename = filename.concat(`${request.year}${request.format.toLowerCase() ==='pdf' ? '.pdf': '.xlsx'}`)

        const url = window.URL.createObjectURL(blob);
        const link = document.createElement('a');
        link.href = url;
        link.download = filename;
        link.click();
        window.URL.revokeObjectURL(url);

        this.toast.setSuccessMessage('El reporte financiero se ha descargado correctamente.');
      },
      error: (error) => {
        this.toast.setErrorMessage('Ha ocurrido un error al obtener el reporte financiero');
        console.error(error);
      }
    });
  }

}
