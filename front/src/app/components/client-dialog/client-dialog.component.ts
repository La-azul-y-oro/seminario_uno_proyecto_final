import { Component, EventEmitter, Input, OnChanges, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { FunctionalUnitService } from '../../services/functional-unit.service';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { TableModule } from 'primeng/table';
import { CommonModule } from '@angular/common';
import { TooltipModule } from 'primeng/tooltip';
import { MultiSelectModule } from 'primeng/multiselect';
import { AssignClientsRequest, Client, ClientFunctionalUnitDto, OccupantType, UnitFunctionalConsortium } from '../../interfaces/model.interfaces';
import { ToastService } from '../toast/toast-service';
import { DropdownModule } from 'primeng/dropdown';

@Component({
  selector: 'app-client-dialog',
  standalone: true,
  imports: [
    ButtonModule,
    DialogModule,
    DropdownModule,
    FormsModule,
    TableModule,
    CommonModule,
    TooltipModule,
    MultiSelectModule
  ],
  templateUrl: './client-dialog.component.html',
  styleUrl: './client-dialog.component.css'
})
export class ClientDialogComponent implements OnChanges {
  // Primer modal
  @Input() visible: boolean = false;

  @Output() cancelEmit = new EventEmitter;

  //Segundo modal
  selectedClients: Array<{ client: any, type: 'INQUILINO' | 'PROPIETARIO' | null }> = [];

  clientTypes = [
    { label: 'INQUILINO', value: 'INQUILINO' },
    { label: 'PROPIETARIO', value: 'PROPIETARIO' }
  ];

  addClientModalVisible: boolean = false;
  private hadClientsOnOpen = false;

  //Compartido
  @Input() functionalUnit!: UnitFunctionalConsortium;
  @Input() clients!: Client[];
  bindClients: Client[] = [];

  constructor(
    private readonly functionalUnitService: FunctionalUnitService,
    private readonly toastService: ToastService
  ) { }

  //Primer modal
  ngOnChanges(): void {
    if (this.clients.length > 0) {
      this.clients = this.clients.map(c => ({
        ...c,
        fullName: `${c.firstName} ${c.lastName}`
      })
      );
    }
    if (this.functionalUnit?.clients && this.functionalUnit.clients.length > 0) {
      this.bindClients = this.functionalUnit.clients.map(c => ({
        ...c,
        fullName: `${c.firstName} ${c.lastName}`
      })
      );
    }
  }

  closeDialog() {
    this.cancelClients();
    this.bindClients = [];
    if (!this.addClientModalVisible) {
      this.cancelEmit.emit(this.functionalUnit);
    }
  }

  getHeader(): string | undefined {
    return `Clientes asociados - Unidad ${this.functionalUnit?.name}`
  }

  openAddClientModal() {
    this.hadClientsOnOpen = this.bindClients.length > 0;

    this.selectedClients = this.bindClients.map(bindClient => {
      const clientFromList = this.clients.find(c => c.id === bindClient.id) || bindClient;
      return {
        client: clientFromList,
        type: bindClient.occupantType
      };
    });

    this.addClientModalVisible = true;
  }

  //Segundo modal
  addNewClient() {
    this.selectedClients.push({ client: null, type: null });
  }

  removeClient(index: number) {
    this.selectedClients.splice(index, 1);
  }

  confirmClients() {
    if (!this.canSave) {
      return;
    }

    const clients: ClientFunctionalUnitDto[] = this.selectedClients.map(c => ({
      clientId: c.client.id,
      occupantType: c.type as OccupantType
    }));

    const body: AssignClientsRequest = {
      functionalId: this.functionalUnit.id,
      clients
    }

    this.functionalUnitService.updateClients(body).subscribe({
      next: () => {
        this.toastService.setSuccessMessage("Los clientes se han actualizado con éxito.")
        this.postConfirm();
      },
      error: (error) => {
        this.toastService.setErrorMessage("Ha ocurrido un error al añadir los clientes.")
        console.error("Error al cargar los datos:", error);
      }
    });
  }

  cancelClients() {
    this.selectedClients = [];
    this.hadClientsOnOpen = false;
    this.addClientModalVisible = false;
  }

  get availableClientsFiltered() {
    const selectedIds = this.selectedClients
      .filter(sc => sc.client !== null)
      .map(sc => sc.client.id);
    return this.clients.filter(client =>
      !selectedIds.includes(client.id)
    );
  }

  getAvailableClientsForItem(currentItem: any) {
    const selectedIds = this.selectedClients
      .filter(sc => sc.client !== null && sc !== currentItem)
      .map(sc => sc.client.id);

    return this.clients
      .filter(client => !selectedIds.includes(client.id));
  }

  get canSave(): boolean {
    if (this.hadClientsOnOpen && this.selectedClients.length === 0) {
      return true;
    }

    if (this.selectedClients.length === 0) {
      return false;
    }
    return this.selectedClients.every(sc =>
      sc.client !== null && sc.type !== null
    );
  }

  postConfirm() {
    this.bindClients = this.selectedClients.map(c => ({
      ...c.client,
      occupantType: c.type
    }));

    this.functionalUnit.clients = this.bindClients;
    this.selectedClients = [];
    this.addClientModalVisible = false;
  }
}
