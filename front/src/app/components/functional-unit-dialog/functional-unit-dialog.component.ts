import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { MessagesModule } from 'primeng/messages';
import { TableModule } from 'primeng/table';
import { TooltipModule } from 'primeng/tooltip';
import { FunctionalUnitService } from '../../services/functional-unit.service';
import { InputIconModule } from 'primeng/inputicon';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { ToastService } from '../toast/toast-service';

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
    TooltipModule,
    InputIconModule,
    ProgressSpinnerModule,
  ],
  templateUrl: './functional-unit-dialog.component.html',
  styleUrl: './functional-unit-dialog.component.css'
})
export class FunctionalUnitDialogComponent {
  @Input() visible: boolean = false;
  @Input() consortiumId!: number | undefined;

  @Output() onCancel = new EventEmitter;
  @Output() onSave = new EventEmitter;

  form: FormGroup;
  units: FormArray;
  totalFactor = 0;

  @Input() originalUnits: any[] = [];
  deletedUnitIds: number[] = [];

  isLoading : boolean = false;
  hasError : boolean = false;

  actionButtonStyle = {
    height: '30px',
    width: '30px', 
    padding: '0px',
    marginLeft: '5px',
    marginRight: '5px'
  };

  constructor(
    private readonly fb: FormBuilder,
    private readonly functionalUnitService: FunctionalUnitService,
    private readonly toastService: ToastService
  ) {
    this.form = this.fb.group({
      units: this.fb.array([])
    });
    this.units = this.form.get('units') as FormArray;
  }

  ngOnChanges(): void {
    if (this.consortiumId && this.visible) {
      this.isLoading = true;
      this.loadUnits();
    }
  }

  loadUnits() {
    this.functionalUnitService.getByConsortiumId(this.consortiumId!).subscribe({
      next: (response) => {
        const filteredData = response.filter(e => !(e as any).hasOwnProperty('active') || (e as any).active);
        this.originalUnits = JSON.parse(JSON.stringify(filteredData));

        filteredData?.forEach((u: any) => {
          this.units.push(this.fb.group({
            id: [u.id],
            name: [u.name, Validators.required],
            factor: [u.factor, [Validators.required, Validators.min(1), Validators.max(100)]],
            balance: [u.balance],
            consortiumId: [u.consortiumId]
          }));
        });

        this.recalculateTotal();
        this.isLoading = false;
      },
      error: (error) => {
        console.error(error);
        this.toastService.setErrorMessage('Ha ocurrido un error al intentar obtener las unidades funcionales.');
        this.isLoading = false;
        this.hasError = true;
      }
    })
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

  removeUnit(index: number) {
    const unit = this.units.at(index) as FormGroup;
    if (!this.canDelete(unit)) return;

    const id = unit.get('id')?.value;
    if (id) {
      this.deletedUnitIds.push(id);
    }

    this.units.removeAt(index);
    this.recalculateTotal();
  }

  addUnit(): void {
    const newUnit = this.fb.group({
      name: ['', Validators.required],
      factor: [0, [Validators.required, Validators.min(1), Validators.max(100)]],
      balance: [0],
      consortiumId: [this.consortiumId]
    });
    this.units.push(newUnit);

    this.recalculateTotal();

    this.form.updateValueAndValidity();
  }

  canSave(): boolean {
    return this.totalFactor === 100 && this.form.valid;
  }

  save() {
    if (!this.canSave()) return;

    const current = this.units.value;

    const toCreate = current.filter((u: any) => !u.id);
    const toUpdate = current.filter((u: any) => {
      const original = this.originalUnits.find(o => o.id === u.id);
      return original && (
        original.name !== u.name ||
        (original.factor * 100).toFixed(2) !== (+u.factor).toFixed(2)
      );
    });

    const toDelete = this.deletedUnitIds;

    const result = {
      create: toCreate,
      update: toUpdate,
      delete: toDelete
    };

    this.onSave.emit(result)
  }

  closeDialog() {
    this.units = this.fb.array([]);
    this.originalUnits = [];
    this.consortiumId = undefined;
    this.hasError = false;
    this.onCancel.emit();
  }

  showTooltipCannotDelete(unit: any) {
    const canDelete = this.canDelete(unit);
    return canDelete ? "Remover" : "No se pueden borrar las unidades con balance distinto de 0 (cero)";
  }
}
