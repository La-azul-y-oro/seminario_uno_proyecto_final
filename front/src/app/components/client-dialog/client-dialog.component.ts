import { ChangeDetectorRef, Component, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { FunctionalUnitService } from '../../services/functional-unit.service';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { TableModule } from 'primeng/table';
import { CommonModule } from '@angular/common';
import { TooltipModule } from 'primeng/tooltip';
import { MultiSelect, MultiSelectChangeEvent, MultiSelectModule } from 'primeng/multiselect';
import { AssignClientsRequest, Client, UnitFunctionalConsortium } from '../../interfaces/model.interfaces';
import { ConfirmDialogService } from '../confirm-dialog/confirm-dialog-service';
import { ToastService } from '../toast/toast-service';

@Component({
  selector: 'app-client-dialog',
  standalone: true,
  imports: [
    ButtonModule,
    DialogModule,
    TableModule,
    CommonModule,
    TooltipModule,
    MultiSelectModule
  ],
  templateUrl: './client-dialog.component.html',
  styleUrl: './client-dialog.component.css'
})
export class ClientDialogComponent {
  @ViewChild('multiSelectRef') multiSelectRef!: MultiSelect;

  @Input() visible: boolean = false;
  @Input() functionalUnit!: UnitFunctionalConsortium;
  @Input() clients!: Client[];
  bindClients: Client[] = [];

  @Output() onCancel = new EventEmitter;
  @Output() onSave = new EventEmitter;

  addClientModalVisible: boolean = false;
  availableClients: any[] = []; // Lista completa de clientes
  idClientsToAdd: any[] = [];

tooltipEnabled = true;

  constructor(
    private readonly functionalUnitService: FunctionalUnitService,
    private readonly confirmService: ConfirmDialogService,
    private readonly toastService: ToastService
  ) { }

  ngOnChanges(): void {
    if (this.clients.length > 0) {
      this.clients = this.clients.map(c => ({
        ...c,
        fullName: `${c.firstName} ${c.lastName}`
      })
      );
    }
    if (this.functionalUnit.clients && this.functionalUnit.clients.length > 0) {
      this.bindClients = this.functionalUnit.clients.map(c => ({
        ...c,
        fullName: `${c.firstName} ${c.lastName}`
      })
      );
    }
  }

  closeDialog() {
    this.cancelAddClient();
    if (!this.addClientModalVisible) {
      this.onCancel.emit(this.functionalUnit);
    }
  }

  removeClient(client: any) {

    this.confirmService.open(client, `Desvincular cliente ${client.fullName}` )
      .subscribe((data) => {
        this.idClientsToAdd = this.bindClients.filter(c => c.id !== data.id).map(c => c.id);

        this.confirmRemoveClients();
    });
  }

  openAddClientModal() {
    this.availableClients = this.clients.filter(
      c => !this.bindClients.some(existing => existing.id === c.id)
    );
    this.idClientsToAdd = [];
    this.addClientModalVisible = true;
  }

  confirmAddClients() {
    const body: AssignClientsRequest = {
      functionalId: this.functionalUnit.id,
      clientsIds: this.idClientsToAdd
    }

    this.functionalUnitService.updateClients(body).subscribe({
      next: () => {
        this.toastService.setSuccessMessage("Los clientes se han añadido con éxito.")
        this.postConfirm();
      },
      error: (error) => {
        this.toastService.setErrorMessage("Ha ocurrido un error al añadir los clientes.")
        console.error("Error al cargar los datos:", error);
      }
    });
  }

  confirmRemoveClients() {
    const body: AssignClientsRequest = {
      functionalId: this.functionalUnit.id,
      clientsIds: this.idClientsToAdd
    }

    this.functionalUnitService.updateClients(body).subscribe({
      next: () => {
        this.toastService.setSuccessMessage("El cliente se ha desvinculado con éxito.")
        this.postConfirmRemove();
      },
      error: (error) => {
        this.toastService.setErrorMessage("Ha ocurrido un error al desvincular el cliente")
        console.error("Error al cargar los datos:", error);
      }
    });
  }

  
  postConfirm() {
    const newClients = this.availableClients.filter(obj => this.idClientsToAdd.includes(obj.id));

    this.bindClients = [...this.bindClients, ...newClients];
    this.multiSelectRef.updateModel([]);
    this.addClientModalVisible = false;
  }

  postConfirmRemove() {
    this.bindClients = this.clients.filter(obj => this.idClientsToAdd.includes(obj.id));
    this.multiSelectRef.updateModel([]);
    this.addClientModalVisible = false;
  }

  cancelAddClient() {
    this.addClientModalVisible = false;
    this.functionalUnit = {
      ...this.functionalUnit,
      clients: this.bindClients
    }
    this.idClientsToAdd = []
  }

  addClient($event: MultiSelectChangeEvent) {
    this.idClientsToAdd = $event.value;
  }

  getHeader(): string | undefined {
    return `Clientes asociados - Unidad ${this.functionalUnit?.name}`
  }
}
