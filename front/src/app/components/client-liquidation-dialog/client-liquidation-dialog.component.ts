import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { TooltipModule } from 'primeng/tooltip';
import { TableModule } from 'primeng/table';
import { ReportService } from '../../services/report.service';
import { ToastService } from '../toast/toast-service';
import { LiquidationForClient } from '../../interfaces/model.interfaces';
import { finalize } from 'rxjs';

@Component({
  selector: 'app-client-liquidation-dialog',
  standalone: true,
  imports: [
    ButtonModule,
    CommonModule,
    DialogModule,
    TooltipModule,
    TableModule
  ],
  templateUrl: './client-liquidation-dialog.component.html',
  styleUrl: './client-liquidation-dialog.component.css'
})
export class ClientLiquidationDialogComponent {
  @Input() visible: boolean = false;
  @Input() liquidations: any[] = [];

  downloadingIds: Set<number> = new Set();

  @Output() onCancel = new EventEmitter;
  @Output() onExpenses = new EventEmitter;

  isDownloading: boolean = false;

  actionButtonStyle = {
    height: '30px',
    width: '30px', 
    padding: '0px',
    marginLeft: '5px',
    marginRight: '5px'
  };

  constructor(
    private readonly reportService: ReportService,
    private readonly toastService: ToastService
  ) { }

  ngOnChanges() {
    if (this.liquidations?.length > 0) {
      this.liquidations = this.liquidations.map(e => {
        return {
          ...e,
          expirationDate: new Date(e.expirationDate).toLocaleDateString('es-ES', {
            day: '2-digit',
            month: '2-digit',
            year: 'numeric'
          })
        }
      }).sort((a, b) => b.id - a.id);
    }
  }

  downloadLiquidation(liquidation: LiquidationForClient) {
    if(this.isDownloadingLiquidation(liquidation.id)) return;

    this.downloadingIds.add(liquidation.id);

    const periodSplit = liquidation.period.split("-");
    const year = periodSplit[0];
    const month = periodSplit[1];

    this.reportService.getExpenseReportById(liquidation.id).pipe(
      finalize(() => {
        this.downloadingIds.delete(liquidation.id);
      })
    )
      .subscribe({
        next: (blob) => {
          const filename = `liquidacion_expensas_${month}_${year}.pdf`;

          const url = window.URL.createObjectURL(blob);
          const link = document.createElement('a');
          link.href = url;
          link.download = filename;
          link.click();
          window.URL.revokeObjectURL(url);

          this.toastService.setSuccessMessage('Las expensas se han descargado correctamente.');
        },
        error: (error) => {
          this.toastService.setErrorMessage('Ha ocurrido un error al obtener las expensas');
          console.error(error);
        }
      });
  }

  isDownloadingLiquidation(liquidationId: number): boolean {
    return this.downloadingIds.has(liquidationId);
  }

  onClose(){
    this.onCancel.emit();
  }
}
