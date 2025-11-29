import { Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { AssignClientsRequest, Client, ClientFunctionalUnit, ClientFunctionalUnitDto, ConsortiumResponse, FunctionalUnitClientDto, FunctionalUnitResponse, OccupantType, UIFunctionalUnitItem, UnitFunctionalConsortium, UserResponse } from '../../interfaces/model.interfaces';
import { ConsortiumService } from '../../services/consortium.service';
import { FunctionalUnitService } from '../../services/functional-unit.service';
import { ToastService } from '../toast/toast-service';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { FormsModule } from '@angular/forms';
import { TableModule } from 'primeng/table';
import { CommonModule } from '@angular/common';
import { TooltipModule } from 'primeng/tooltip';
import { MultiSelectModule } from 'primeng/multiselect';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-user-functionalunit-form',
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
  templateUrl: './user-functionalunit-form.component.html',
  styleUrl: './user-functionalunit-form.component.css'
})
export class UserFunctionalunitFormComponent implements OnChanges, OnInit {
  @Input() visible: boolean = false;
  @Input() client!: UserResponse;
  @Input() functionalUnits!: FunctionalUnitResponse[];
  @Input() consortiumList!: ConsortiumResponse[];

  @Output() closeEmit = new EventEmitter;

  selectedFunctionalUnits: UIFunctionalUnitItem[] = [];
  bindFunctionalUnits: ClientFunctionalUnit[] = [];

  clientTypes = [
    { label: 'INQUILINO', value: 'INQUILINO' },
    { label: 'PROPIETARIO', value: 'PROPIETARIO' }
  ];

  private hadFunctionalUnitsOnOpen = false;

  constructor(
    private readonly consortiumService: ConsortiumService,
    private readonly functionalUnitService: FunctionalUnitService,
    private readonly userService: UserService,
    private readonly toastService: ToastService
  ) { }

  ngOnInit(): void { }

  ngOnChanges(): void {
    if (this.client?.id) {
      this.getClientFunctionalUnits();
    }
    if (this.functionalUnits.length > 0) {
      this.initFunctionalUnitList();
    }
  }

  closeDialog() {
    this.selectedFunctionalUnits = [];
    this.hadFunctionalUnitsOnOpen = false;
    this.bindFunctionalUnits = [];
    this.closeEmit.emit();
  }

  getHeader(): string | undefined {
    return `Unidades asociadas - Cliente: ${this.client?.firstName || ""} ${this.client?.lastName || ""}`;
  }

  initFunctionalUnitList() {
    this.hadFunctionalUnitsOnOpen = this.bindFunctionalUnits.length > 0;

    this.selectedFunctionalUnits = this.bindFunctionalUnits.map(fu => ({
      consortiumId: fu.consortiumId,
      consortiumName: fu.consortium,
      functionalUnitId: fu.id,
      functionalUnitName: fu.name,
      type: fu.occupantType as OccupantType
    }));
  }

  addNewFunctionalUnit() {
    this.selectedFunctionalUnits.push({
      consortiumId: null,
      consortiumName: null,
      functionalUnitId: null,
      functionalUnitName: null,
      type: null
    });
  }

  removeFunctionalUnit(index: number) {
    this.selectedFunctionalUnits.splice(index, 1);
  }

  confirmFunctionalUnits() {
    if (!this.canSave) {
      return;
    }

    const functionalUnits: FunctionalUnitClientDto[] = this.selectedFunctionalUnits.map(fu => ({
      functionalUnitId: fu.functionalUnitId!,
      occupantType: fu.type as OccupantType
    }))

    this.userService.assignFunctionalUnitsToClient(this.client.id, functionalUnits).subscribe({
      next: () => {
        this.toastService.setSuccessMessage("Las unidades funcionales se han actualizado con éxito.");
      },
      error: (error) => {
        this.toastService.setErrorMessage("Ha ocurrido un error al añadir las unidades funcionales.")
        console.error("Error al cargar los datos:", error);
      }
    });
  }

  get availableFunctionalUnitsFiltered() {
    const selectedIds = this.selectedFunctionalUnits
      .filter(sfu => sfu.functionalUnitId !== null)
      .map(sfu => sfu.functionalUnitId!);

    return this.functionalUnits?.filter(functionalUnit =>
      !selectedIds.includes(functionalUnit.id)
    );
  }

  get canSave(): boolean {
    if (this.hadFunctionalUnitsOnOpen && this.selectedFunctionalUnits.length === 0) {
      return true;
    }

    if (this.selectedFunctionalUnits.length === 0) {
      return false;
    }

    return this.selectedFunctionalUnits.every(sfu =>
      sfu.functionalUnitId !== null && sfu.type !== null && sfu.consortiumId !== null
    )
  }

  canAddMoreFunctionalUnits() {
    return this.availableFunctionalUnitsFiltered && this.availableFunctionalUnitsFiltered.length > 0
  }

  getClientFunctionalUnits() {
    this.functionalUnitService.getByClientId(this.client.id).subscribe({
      next: (response) => {
        this.bindFunctionalUnits = response;
        this.initFunctionalUnitList();
      },
      error: (error) => {
        console.error(error);
      }
    })
  }

 getAvailableFunctionalUnitsForItem(item: UIFunctionalUnitItem): FunctionalUnitResponse[] {
  if (!item.consortiumId) return [];

  const selectedIds = this.selectedFunctionalUnits
    .filter(sfu => sfu.functionalUnitId !== null && sfu !== item)
    .map(sfu => sfu.functionalUnitId!);

  return this.functionalUnits
    .filter(u =>
      u.consortiumId === item.consortiumId &&
      !selectedIds.includes(u.id)
    );
}

  onSelectFunctionalUnit(item: UIFunctionalUnitItem, fu: FunctionalUnitResponse) {
    item.functionalUnitId = fu.id;
    item.functionalUnitName = fu.name;

    item.consortiumId = fu.consortiumId;
    item.consortiumName = "Consorcio";
  }
}
