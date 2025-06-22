import { Component, EventEmitter, Input, Output } from '@angular/core';
import { DialogModule } from 'primeng/dialog';
import { CalendarModule } from 'primeng/calendar';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { FormsModule } from '@angular/forms';
import { PrimeNGConfig } from 'primeng/api';

@Component({
  selector: 'app-liquidation-dialog',
  standalone: true,
  imports: [
    ButtonModule,
    CalendarModule,
    DialogModule,
    FormsModule,
    InputTextModule
  ],
  templateUrl: './liquidation-dialog.component.html',
  styleUrl: './liquidation-dialog.component.css'
})
export class LiquidationDialogComponent{
  @Input() visible: boolean = false;

  @Output() onConfirm = new EventEmitter
  @Output() onCancel = new EventEmitter;

  date: Date | undefined;
  expirationDate: Date | undefined;
  
  maxDate: Date | undefined;
  minDateExpiration: Date | undefined;

  constructor(private readonly primengConfig: PrimeNGConfig) {}

  ngOnInit() {
    this.setConfigLanguage();
    this.generateMaxDate()
    this.generateMinDateExpiration()
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
    let today = new Date();
    let month = today.getMonth();
    let year = today.getFullYear();
    let nextMonth = (month === 11) ? 0 : month;
    let nextYear = (nextMonth === 0) ? year + 1 : year;
    this.maxDate = new Date();
    this.maxDate.setMonth(nextMonth);
    this.maxDate.setFullYear(nextYear);
  }

  generateMinDateExpiration() {
      let today = new Date();
      let month = today.getMonth();
      let year = today.getFullYear();
      let prevMonth = (month === 0) ? 11 : month;
      let prevYear = (prevMonth === 11) ? year + 1 : year;
      this.minDateExpiration = new Date();
      this.minDateExpiration.setMonth(prevMonth);
      this.minDateExpiration.setFullYear(prevYear);
  }

  onClose(){
    this.date = undefined;
    this.expirationDate = undefined;
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
  }
}
