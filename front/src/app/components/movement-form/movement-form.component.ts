import { Component, EventEmitter, Input, OnChanges, OnDestroy, Output } from '@angular/core';
import { ConceptResponse, ConsortiumResponse, MovementType, SupplierResponse } from '../../interfaces/model.interfaces';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { FloatLabelModule } from 'primeng/floatlabel';
import { InputNumberModule } from 'primeng/inputnumber';
import { InputTextModule } from 'primeng/inputtext';
import { CommonModule } from '@angular/common';
import { PasswordModule } from 'primeng/password';
import { MultiSelectModule } from 'primeng/multiselect';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { CalendarModule } from 'primeng/calendar';
import { enumToSelectOptions } from '../../util/enumUtils';
import { noWhitespaceValidator } from '../../util/customValidators';
import { Subject, takeUntil } from 'rxjs';
import { MovementService } from '../../services/movement.service';
import { ToastService } from '../toast/toast-service';
import { ConfirmDialogService } from '../confirm-dialog/confirm-dialog-service';

@Component({
  selector: 'app-movement-form',
  standalone: true,
  imports: [
    ButtonModule,
    DialogModule,
    DropdownModule,
    FloatLabelModule,
    InputNumberModule,
    InputTextModule,
    CommonModule,
    ReactiveFormsModule,
    PasswordModule,
    MultiSelectModule,
    ProgressSpinnerModule,
    CalendarModule
  ],
  templateUrl: './movement-form.component.html',
  styleUrl: './movement-form.component.css'
})
export class MovementFormComponent implements OnChanges, OnDestroy {
  @Input() data?: any;
  @Input() visible: boolean = false;
  @Input() textError: string = "";
  @Input() isReady: boolean = true;
  @Input() hasReadyError: boolean = false;
  @Input() consortiumList: ConsortiumResponse[] = [];
  @Input() supplierList: SupplierResponse[] = [];
  @Input() conceptList: ConceptResponse[] = [];

  @Output() saveEmit = new EventEmitter;
  @Output() onUpdate = new EventEmitter;
  @Output() closeEmit = new EventEmitter;

  titleOnCreate: string = "Crear Movimiento";
  titleOnUpdate: string = "Actualizar registro";
  title: string = this.titleOnCreate;

  movementTypeList = enumToSelectOptions(MovementType)

  form!: FormGroup;

  maxDate: Date = new Date();

  private destroy$ = new Subject<void>();

  constructor(
    private readonly fb: FormBuilder,
    private readonly movementService: MovementService,
    private readonly toastService: ToastService,
    private readonly confirmService: ConfirmDialogService
  ) {
    this.maxDate.setHours(23, 59, 59, 999);
  }

  ngOnChanges() {
    if (this.conceptList.length > 0 && this.supplierList.length > 0 && this.consortiumList.length > 0) {
      this.buildForm();
      this.subcribeConcept();
    }
  }

  private buildForm() {
    this.form = this.fb.group({
      consortiumId: ['', [Validators.required]],
      type: ['', [Validators.required]],
      supplierId: [],
      conceptId: ['', [Validators.required]],
      date: [, [Validators.required]],
      amount: [, [Validators.required]],
      comment: ['', [Validators.required, noWhitespaceValidator]],
      functionalUnitId: [],
      receipt: []
    })
  }

  private subcribeConcept() {
    this.form.get('type')?.valueChanges
      .pipe(takeUntil(this.destroy$))
      .subscribe((value) => {
        if (value === 'EGRESO') {
          this.form.get('supplierId')?.addValidators([Validators.required])
          this.form.get('functionalUnitId')?.clearValidators()
        } else {
          this.form.get('functionalUnitId')?.addValidators([Validators.required])
          this.form.get('supplierId')?.clearValidators()
        }
        this.form.get('conceptId')?.reset()
        this.form.get('supplierId')?.reset()
        this.form.get('functionalUnitId')?.reset()
        this.form.get('date')?.reset()
        this.form.get('amount')?.reset()
        this.form.get('comment')?.reset()
        this.form.get('receipt')?.reset()
      });
  }

  public isFirstStepCompleted() {
    return this.form.get('consortiumId')?.valid && this.form.get('type')?.valid
  }

  public isEgreso() {
    return this.form.get('type')?.value === 'EGRESO';
  }

  public getFunctionalUnits() {
    const consortiumId = this.form.get('consortiumId')?.value;
    return this.consortiumList.find(c => c.id === consortiumId)?.functionalUnits;
  }

  public getConcepts() {
    return (this.isEgreso()) ?
      this.conceptList.filter(c => c.type === MovementType.EGRESO)
      : this.conceptList.filter(c => c.type === MovementType.INGRESO)
  }

  public resetAll() {
    this.buildForm();
    this.closeEmit.emit();
  }

  public canSend() {
    return this.form.valid
  }

  public confirm() {
    if (this.form.invalid) return;

    this.confirmService.open(
      {
        header: 'Guardar movimiento',
        message: 'El movimiento no podrá ser editado, solo eliminado por un administrador siempre y cuando no sea un EGRESO vinculado a un período liquidado. ¿Desea continuar?'
      }
    ).subscribe(() => {
      this.sendData();
    });
  }

  private sendData() {
    if (this.form.invalid) return;

    const values = this.form.value;

    this.movementService.create(values).subscribe({
      next: (response) => {
        this.toastService.setSuccessMessage("El movimiento se ha guardado con éxito.")
        this.saveEmit.emit(response);
        this.resetAll();
      },
      error: (error) => {
        this.handleError(error);
      }
    });
  }

  hasError(nameField: any) {
    let field = this.form.get(nameField);
    return (field?.dirty || field?.touched) && field?.invalid;
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  private handleError(error: any) {
    const msg = (error?.status === 409)
      ? "No se permiten procesar movimientos para un periodo ya liquidado."
      : "Ha ocurrido un error al guardar el movimiento."
    this.toastService.setErrorMessage(msg)
    console.error("Error al guardar movimiento:", error);
  }

}
