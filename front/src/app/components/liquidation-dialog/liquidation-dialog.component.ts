import { Component, EventEmitter, Input, Output } from '@angular/core';
import { DialogModule } from 'primeng/dialog';
import { CalendarModule } from 'primeng/calendar';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { FormsModule } from '@angular/forms';
import { PrimeNGConfig } from 'primeng/api';
import { LiquidationService } from '../../services/liquidation.service';
import { CommonModule } from '@angular/common';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { DividerModule } from 'primeng/divider';

@Component({
  selector: 'app-liquidation-dialog',
  standalone: true,
  imports: [
    ButtonModule,
    CalendarModule,
    DialogModule,
    FormsModule,
    InputTextModule,
    CommonModule, 
    ProgressSpinnerModule,
    DividerModule
  ],
  templateUrl: './liquidation-dialog.component.html',
  styleUrl: './liquidation-dialog.component.css'
})
export class LiquidationDialogComponent{
  @Input() visible: boolean = false;
  @Input() consortiumId!: number;

  @Output() onConfirm = new EventEmitter
  @Output() onCancel = new EventEmitter;

  date: Date | undefined;
  expirationDate: Date | undefined;
  
  maxDate: Date | undefined;
  minDateExpiration: Date | undefined;

  expensasList: any = [];
  isLoadingExpensas : boolean = false;
  hasErrorExpensas : boolean = false;

  constructor(
    private readonly primengConfig: PrimeNGConfig,
    private readonly liquidationService: LiquidationService
  ) {}

  ngOnInit() {
    this.setConfigLanguage();
    this.generateMaxDate()
    this.generateMinDateExpiration()
  }

  ngOnChanges() {
    if (this.consortiumId !== undefined && this.visible) {
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

  generateMaxDate() {
    this.maxDate = new Date();
  }

  generateMinDateExpiration() {
    this.minDateExpiration = new Date();
  }

  getLiquidations() {
    this.isLoadingExpensas = true;
    this.hasErrorExpensas = false;

    this.liquidationService.getAllByConsortiumId(this.consortiumId).subscribe({
      next: response => {
        response.forEach(liquidation => {
          this.expensasList.unshift(
            { id: liquidation.id, period: liquidation.period }
          )
        });
        this.isLoadingExpensas = false;
      },
      error: error => {
        console.error(error);
        this.isLoadingExpensas = false;
        this.hasErrorExpensas = true;
      }
    });
  }


  onClose(){
    this.date = undefined;
    this.expirationDate = undefined;
    this.expensasList = [];
    this.onCancel.emit(false);
  }

  onSave(){
    this.onConfirm.emit({
      month: this.date!.getMonth()+1,
      year: this.date!.getFullYear(),
      expirationDate: this.expirationDate!
    });

    this.date = undefined;
    this.expirationDate = undefined;
    this.expensasList = [];
  }

  isValidPeriod(): any {
    if(this.date){
      const month = (this.date.getMonth() + 1).toString().padStart(2, '0');
      const year = this.date.getFullYear();
      const periodSelect = `${year}-${month}`
       
      return !this.expensasList.some((e: any) => e.period === periodSelect);
    }
    return true;
  }

  canSend(){
    return this.isValidPeriod() && this.expirationDate;
  }
}
