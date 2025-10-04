import { Component, EventEmitter, Output } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { ConfirmDialogModule } from 'primeng/confirmdialog';

export interface DialogConfirmConfig{
  id?: any;
  header?: string,
  message?: string;
}

@Component({
  selector: 'app-confirm-dialog',
  standalone: true,
  imports: [ConfirmDialogModule],
  templateUrl: './confirm-dialog.component.html'
})
export class ConfirmDialogComponent {
  @Output() onConfirm = new EventEmitter;
  constructor(
    private readonly confirmationService: ConfirmationService
  ){}

  openDialog(config: DialogConfirmConfig){
    const { id, header = 'Eliminar registro', message = '¿Desea continuar?' } = config ?? {};

    this.confirmationService.confirm({
        header,
        message,
        icon: 'pi pi-info-circle',
        acceptButtonStyleClass:"p-button-outlined",
        rejectButtonStyleClass:"p-button-outlined me-3 p-button-danger",
        acceptIcon: 'pi pi-check me-2',
        rejectIcon: 'pi pi-times me-2',
        acceptLabel: "Si",
        rejectLabel: "No",

        accept: () => {
            this.onConfirm.emit(id);
            this.confirmationService.close();
        }
    });
  }

}
