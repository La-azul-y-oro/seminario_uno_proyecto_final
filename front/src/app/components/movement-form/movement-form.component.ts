import { Component } from '@angular/core';
import { FormComponent } from '../form/form.component';
import { GenericFormComponent } from '../form/generic-form.class';
import { MovementRequest } from '../../interfaces/model.interfaces';
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
    placeholder: 'Ingrese un monton',
    errorMessage: 'Dato obligatorio.',
    validators: [Validators.required]
  },
  {
    label: 'Tipo',
    controlName: 'movementType',
    type: TypeField.SELECT,
    selectList: [
    { label: 'Ingreso', value: 'Ingreso' },
    { label: 'Egreso', value: 'Egreso' }
    ],
    placeholder: 'Ingrese el tipo de movimiento',
    errorMessage: 'Dato obligatorio.',
    validators: [Validators.required],
  },
  {
    label: 'Fecha',
    controlName: 'date',
    type: TypeField.CALENDAR,
    placeholder: 'Seleccione una fecha',
    errorMessage: 'Dato obligatorio.',
    validators: [Validators.required]
  },
]
}
