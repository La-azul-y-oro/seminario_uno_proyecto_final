import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnChanges, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { RadioButtonModule } from 'primeng/radiobutton';
import { CheckboxModule } from 'primeng/checkbox';
import { PrimeNGConfig } from 'primeng/api';
import { LiquidationService } from '../../services/liquidation.service';
import { ExpensesRequest, FinancialRequest } from '../../interfaces/model.interfaces';

@Component({
  selector: 'app-report-dialog',
  standalone: true,
  imports: [
    ButtonModule,
    CalendarModule,
    CheckboxModule,
    CommonModule,
    DialogModule,
    DropdownModule,
    FormsModule,
    RadioButtonModule
  ],
  templateUrl: './report-dialog.component.html',
  styleUrl: './report-dialog.component.css'
})
export class ReportDialogComponent implements OnChanges {
  @Input() visible: boolean = false;
  @Input() consortiumId!: number;

  @Output() onCancel = new EventEmitter;
  @Output() onExpenses = new EventEmitter;
  @Output() onFinancialReport = new EventEmitter;

  step = 1;

  reportTypes = [
    { label: 'Financiero', value: 'financiero' },
    { label: 'Expensas', value: 'expensas' }
  ];

  selectedReportType: any = null;

  // Financiero
  financialFormat: string = 'PDF';
  onlyYear = false;
  financialDate: Date | null = null;

  // Expensas
  expensasList: any = [];
  selectedExpensa: any = null;

  constructor(
    private readonly primengConfig: PrimeNGConfig,
    private readonly liquidationService: LiquidationService
  ) { }

  ngOnInit() {
    this.setConfigLanguage();
  }

  ngOnChanges() {
    if (this.consortiumId !== undefined) {
      this.getLiquidations();
    }
  }

  setConfigLanguage() {
    this.primengConfig.setTranslation({
      dayNames: ["Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"],
      dayNamesShort: ["Dom", "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb"],
      dayNamesMin: ["Dom", "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb"],
      monthNames: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio",
        "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
      monthNamesShort: ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago",
        "Sep", "Oct", "Nov", "Dic"],
      today: 'Hoy',
      clear: 'Limpiar',
      dateFormat: 'dd/mm/yy',
      firstDayOfWeek: 1
    });
  }

  getLiquidations() {
    this.liquidationService.getAllByConsortiumId(this.consortiumId).subscribe({
      next: response => {
        response.forEach(liquidation => {
          this.expensasList.push(
            { id: liquidation.id, label: liquidation.period }
          )
        })
      },
      error: error => {
        console.error(error);
      }
    });
  }

  onClose() {
    this.resetDialog();
    this.onCancel.emit(false);
  }

  goToStep2() {
    this.step = 2;
  }

  onDownload() {
    if (this.selectedReportType.value === 'financiero') {   
      const request : FinancialRequest = {
        consortiumId: this.consortiumId,
        format: this.financialFormat,
        month: this.onlyYear ? undefined : this.financialDate!.getMonth()+1,
        year: this.financialDate!.getFullYear(),
      }

      this.onFinancialReport.emit(request);
    } else {
      const periodSplit = this.selectedExpensa.label.split("-");
      const year = periodSplit[0];
      const month = periodSplit[1];

      const request : ExpensesRequest = {
        consortiumId: this.consortiumId,
        year,
        month
      }

      this.onExpenses.emit(request);
    }

    this.onClose();
  }

  canDownload(): boolean {
    if (this.selectedReportType?.value === 'financiero') {
      return this.financialDate !== null;
    } else {
      return this.selectedExpensa !== null;
    }
  }

  resetDialog() {
    this.step = 1;
    this.selectedReportType = null;
    this.financialFormat = 'PDF';
    this.onlyYear = false;
    this.financialDate = null;
    this.selectedExpensa = null;
    this.expensasList = [];
  }
}
