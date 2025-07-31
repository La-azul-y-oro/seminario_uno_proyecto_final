import { Component, Input } from '@angular/core';
import { FormComponent } from '../form/form.component';
import { GenericFormComponent } from '../form/generic-form.class';
import { ConceptResponse, ConsortiumResponse, FunctionalUnitResponse, MovementRequest, MovementType, SupplierResponse } from '../../interfaces/model.interfaces';
import { FormField, TypeField } from '../../interfaces/components.interface';
import { Validators } from '@angular/forms';
import { hasValidRoles } from '../../util/rolesUtil';

@Component({
  selector: 'app-movement-form',
  standalone: true,
  imports: [
    FormComponent
  ],
  templateUrl: './movement-form.component.html'
})
export class MovementFormComponent extends GenericFormComponent<MovementRequest> {

  @Input() consortiumList: ConsortiumResponse[] = [];
  @Input() supplierList: SupplierResponse[] = [];
  @Input() conceptList: ConceptResponse[] = [];
  @Input() functionalUnitList: FunctionalUnitResponse[] = []; 

  movementTypeOptions = Object.values(MovementType).map(value => ({
    name: value,
    id: value
  }));

  fields: FormField[] = [{
    label: 'Fecha',
    controlName: 'date',
    type: TypeField.CALENDAR,
    placeholder: 'Seleccione una fecha',
    errorMessage: 'Dato obligatorio.',
    validators: [Validators.required]
  },
  {
    label: 'Monto',
    controlName: 'amount',
    type: TypeField.NUMBER,
    placeholder: 'Ingrese un monto',
    errorMessage: 'Dato obligatorio.',
    validators: [Validators.required]
  },
  {
    label: 'Tipo',
    controlName: 'movementType',
    type: TypeField.SELECT,
    placeholder: 'Ingrese el tipo de movimiento',
    errorMessage: 'Dato obligatorio.',
    validators: [Validators.required],
    selectList: this.movementTypeOptions
  },
  {
    label: 'Recibo',
    controlName: 'receipt',
    type: TypeField.TEXT,
    placeholder: 'Ingrese el recibo (opcional)'
  },
  {
    label: 'Consorcio',
    controlName: 'consortiumId',
    type: TypeField.SELECT,
    placeholder: 'Seleccione un consorcio',
    errorMessage: 'Dato obligatorio.',
    validators: [Validators.required],
    selectList: this.consortiumList
  },
  {
    label: 'Proveedor',
    controlName: 'supplierId',
    type: TypeField.SELECT,
    placeholder: 'Seleccione un proveedor',
    selectList: this.supplierList
  },
  {
    label: 'Concepto',
    controlName: 'conceptId',
    type: TypeField.SELECT,
    placeholder: 'Seleccione un concepto',
    errorMessage: 'Dato obligatorio.',
    validators: [Validators.required],
    selectList: this.conceptList
  },
  {
    label: 'Unidad Funcional',
    controlName: 'functionalUnitId',
    type: TypeField.SELECT,
    placeholder: 'Seleccione una unidad funcional',
    selectList: this.functionalUnitList
  },
  {
    label: 'Comentario',
    controlName: 'comment',
    type: TypeField.TEXT,
    placeholder: 'Ingrese un comentario (opcional)'
  }
]
}
