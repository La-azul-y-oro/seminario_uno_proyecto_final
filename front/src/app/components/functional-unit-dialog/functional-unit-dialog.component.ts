import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { MessagesModule } from 'primeng/messages';
import { TableModule } from 'primeng/table';
import { TooltipModule } from 'primeng/tooltip';
import { FunctionalUnitService } from '../../services/functional-unit.service';
import { InputIconModule } from 'primeng/inputicon';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { ToastService } from '../toast/toast-service';
import { InputNumberModule } from 'primeng/inputnumber';
import { InputTextModule } from 'primeng/inputtext';
import { DropdownModule } from 'primeng/dropdown';
import { Client, FunctionalUnitBatchRequest } from '../../interfaces/model.interfaces';
import { noWhitespaceValidator } from '../../util/customValidators';
import { ClientDialogComponent } from '../client-dialog/client-dialog.component';

@Component({
  selector: 'app-functional-unit-dialog',
  standalone: true,
  imports: [
    ButtonModule,
    DialogModule,
    MessagesModule,
    TableModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    TooltipModule,
    InputIconModule,
    InputNumberModule,
    InputTextModule,
    ProgressSpinnerModule,
    DropdownModule,
    ClientDialogComponent
  ],
  templateUrl: './functional-unit-dialog.component.html',
  styleUrl: './functional-unit-dialog.component.css'
})
export class FunctionalUnitDialogComponent implements OnChanges {
  @Input() visible: boolean = false;
  @Input() consortiumId!: number | undefined;
  @Input() functionalUnitList: any[] = [];
  @Input() clients!: Client[];
  @Output() cancelEmit = new EventEmitter;

  openClientDialog: boolean = false;
  functionalUnit: any = null;
  
  initialFunctionalUnits: any[] = [];

  form!: FormGroup;
  units!: FormArray;
  generatorForm: FormGroup;
  totalFactor = 0;
  loadingMethod: 'automatic' | 'manual' | null = null;
  showMainForm: boolean = false;
  previewUnits: any[] = [];
  floorFactors: { floor: number, factor: number }[] = [];
  nomenclatureList = [
    { value: "pisoLetra", label: "Piso + Letra (1A, 1B, 1C...)" },
    { value: "pisoNumero", label: "Piso + Número (101, 102, 103...)" }
  ];
  isManualSelected: boolean = false;
  deletedUnitIds: number[] = [];
  actionButtonStyle = {
    height: '30px',
    width: '30px',
    padding: '0px',
    marginLeft: '5px',
    marginRight: '5px'
  };
  
  constructor(
    private readonly fb: FormBuilder,
    private readonly toastService: ToastService,
    private readonly functionalUnitService: FunctionalUnitService
  ) {
    this.generatorForm = this.initGeneratorForm();
    this.setupFormSubscriptions();
    this.initializeForm();
  }

  initializeForm(): void {
    this.form = this.initForm();
    this.units = this.form.get('units') as FormArray;
  }

  initForm(): FormGroup {
    return this.fb.group({
      units: this.fb.array([])
    });
  }

  initGeneratorForm(): FormGroup {
    return this.fb.group({
      floors: [null, [Validators.required, Validators.min(1), Validators.max(50)]],
      unitsPerFloor: [null, [Validators.required, Validators.min(1), Validators.max(20)]],
      nomenclature: ['pisoLetra', Validators.required],
      baseFactor: [2.5, [Validators.required, Validators.min(0.1), Validators.max(100)]],
      differentFactorsByFloor: [false]
    });
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['visible'] && changes['visible'].currentValue === true) {
      this.resetCompleteState();
    }
    
    if (changes['functionalUnitList'] || changes['consortiumId']) {
      this.initialFunctionalUnits = [...this.functionalUnitList];
      this.loadUnits();
    }
  }

  private resetCompleteState(): void {
    this.clearFormArray();
    this.form.reset();
    this.generatorForm.reset({
      nomenclature: 'pisoLetra',
      baseFactor: 2.5,
      differentFactorsByFloor: false
    });
    
    this.showMainForm = false;
    this.loadingMethod = null;
    this.isManualSelected = false;
    this.previewUnits = [];
    this.floorFactors = [];
    this.deletedUnitIds = [];
    this.totalFactor = 0;
    
    this.form.markAsPristine();
    this.form.markAsUntouched();
    this.generatorForm.markAsPristine();
    this.generatorForm.markAsUntouched();
  }

  clearFormArray(): void {
    while (this.units.length !== 0) {
      this.units.removeAt(0);
    }
  }

  loadUnits(): void {
    this.clearFormArray();
    
    this.functionalUnitList?.forEach((u: any) => {
      const unitFormGroup = this.createUnitFormGroup(u);
      this.units.push(unitFormGroup);
    });
    
    this.recalculateTotal();
  }

  createUnitFormGroup(unit: any = null): FormGroup {
    return this.fb.group({
      id: [unit?.id || null],
      name: [
        unit?.name || '', 
        [Validators.required, noWhitespaceValidator, Validators.pattern(/^\S+$/)]
      ],
      factor: [
        unit?.factor || 0, 
        [Validators.required, Validators.min(0), Validators.max(100)]
      ],
      balance: [unit?.balance || 0],
      consortiumId: [unit?.consortiumId || this.consortiumId]
    });
  }

  private setupFormSubscriptions() {
    this.generatorForm.get('floors')?.valueChanges.subscribe(floors => {
      if (floors && this.generatorForm.get('differentFactorsByFloor')?.value) {
        this.generateFloorFactors(floors);
      }
    });

    this.generatorForm.get('differentFactorsByFloor')?.valueChanges.subscribe(isDifferent => {
      if (isDifferent) {
        const floors = this.generatorForm.get('floors')?.value;
        if (floors) {
          this.generateFloorFactors(floors);
        }
      } else {
        this.floorFactors = [];
      }
    });
  }

  private generateFloorFactors(floors: number) {
    const baseFactor = this.generatorForm.get('baseFactor')?.value || 2.5;
    this.floorFactors = [];
    for (let i = 1; i <= floors; i++) {
      this.floorFactors.push({
        floor: i,
        factor: baseFactor
      });
    }
  }

  generatePreview() {
    if (!this.generatorForm.valid) return;
    const formData = this.generatorForm.value;
    this.previewUnits = this.createUnitsList(formData);
  }

  generateUnits() {
    if (!this.generatorForm.valid) return;
    const formData = this.generatorForm.value;
    this.functionalUnitList = this.createUnitsList(formData);
    this.loadUnits();
    this.showMainForm = true;
    
    setTimeout(() => {
      const element = document.querySelector('form[formGroupName="form"]');
      if (element) {
        element.scrollIntoView({ behavior: 'smooth' });
      }
    }, 100);
  }

  private createUnitsList(formData: any): any[] {
    const units: any[] = [];
    const { floors, unitsPerFloor, nomenclature, baseFactor, differentFactorsByFloor } = formData;

    for (let floor = 1; floor <= floors; floor++) {
      const floorFactor = differentFactorsByFloor
        ? this.floorFactors.find(f => f.floor === floor)?.factor || baseFactor
        : baseFactor;

      for (let unit = 1; unit <= unitsPerFloor; unit++) {
        const unitName = this.generateUnitName(floor, unit, nomenclature);
        units.push({
          name: unitName,
          factor: floorFactor,
          balance: 0,
          consortiumId: this.consortiumId
        });
      }
    }
    return units;
  }

  private generateUnitName(floor: number, unit: number, nomenclature: string): string {
    const letters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    switch (nomenclature) {
      case 'pisoLetra':
        return `${floor}${letters[unit - 1]}`;
      case 'pisoNumero':
        return `${floor}${unit.toString().padStart(2, '0')}`;
      default:
        return `${floor}${letters[unit - 1]}`;
    }
  }

  proceedToManualForm() {
    this.showMainForm = true;
    this.isManualSelected = true;
    
    setTimeout(() => {
      const element = document.querySelector('form[formGroupName="form"]');
      if (element) {
        element.scrollIntoView({ behavior: 'smooth' });
      }
    }, 100);
  }

  onFactorChange() {
    this.recalculateTotal();
  }

  recalculateTotal() {
    this.totalFactor = this.units.controls
      .map(ctrl => +ctrl.get('factor')?.value || 0)
      .reduce((a, b) => a + b, 0);
  }

  canDelete(unit: FormGroup): boolean {
    return unit.get('balance')?.value === 0;
  }

  removeUnit(index: number): void {
    const unit = this.units.at(index) as FormGroup;
    if (!this.canDelete(unit)) return;
    
    const id = unit.get('id')?.value;
    if (id) {
      this.deletedUnitIds.push(id);
    }
    
    this.units.removeAt(index);
    this.recalculateTotal();
    this.form.markAsTouched();
  }

  canHandleUsers(unit: FormGroup): boolean {
    return unit.value.id;
  }

  handleUsers(unit: any){
    this.openClientDialog = true;
    this.functionalUnit = this.functionalUnitList.find(u => u.id === unit.value.id);
  }

  handleCloseClientDialog($event: any) {
    if($event){
      const index = this.functionalUnitList.findIndex(fu => fu.id === $event.id);
      if(index !== -1) {
        this.functionalUnitList[index] = $event;
      }
    }
    this.functionalUnit = null;
    this.openClientDialog = false;
  }

  addUnit(): void {
    const newUnit = this.createUnitFormGroup();
    this.units.push(newUnit);
    this.recalculateTotal();
    this.form.markAsTouched();
  }

  canSave(): boolean {
    const totalFactor = Math.round(this.totalFactor * 100) / 100;
    return totalFactor === 100.00 && this.form.valid;
  }

  save() {
    if (!this.canSave()) return;
    
    const current = this.units.value;
    const toCreate = current.filter((u: any) => !u.id);
    const toUpdate = current.filter((u: any) => {
      const original = this.functionalUnitList.find(o => o.id === u.id);
      return original && (
        original.name !== u.name ||
        (original.factor * 100).toFixed(2) !== (+u.factor).toFixed(2)
      );
    }).map((u: any) => ({
      ...u,
      consortiumId: this.consortiumId
    }));
    const toDelete = this.deletedUnitIds;

    const result = {
      create: toCreate,
      update: toUpdate,
      delete: toDelete
    };

    this.updateData({
      ...result,
      consortiumId: this.consortiumId!
    });
  }

  updateData(data: FunctionalUnitBatchRequest) {
    this.functionalUnitService.updateFunctionalUnits(data).subscribe({
      next: (response) => {
        this.toastService.setSuccessMessage("Las unidades funcionales se han procesado con éxito.");
        this.initialFunctionalUnits = response;
      },
      error: (error) => {
        this.toastService.setErrorMessage("Ha ocurrido un error al procesar las unidades funcionales.");
        console.error("Error al procesar unidades funcionales:", error);
      }
    });
  }

  closeDialog() {
    this.cancelEmit.emit(this.initialFunctionalUnits);
  }

  resetForm(): void {
    this.resetCompleteState();
  }

  showTooltipCannotDelete(unit: any) {
    const canDelete = this.canDelete(unit);
    return canDelete ? "Remover" : "No se pueden borrar las unidades con balance distinto de 0 (cero)";
  }

  showTooltipCannotAddClients(unit: any) {
    return (this.canHandleUsers(unit)) ? "Gestionar Usuarios" : "La unidad funcional aún no se encuentra confirmada. Por favor actualice el listado de unidades funcionales antes de gestionar clientes.";
  }

  suggestedFactor() {
    const floors = this.generatorForm.get('floors')?.value;
    const unitsPerFloor = this.generatorForm.get('unitsPerFloor')?.value;
    
    if (floors && unitsPerFloor) {
      return Number(100 / (floors * unitsPerFloor)).toFixed(2);
    } else {
      return null;
    }
  }
}
