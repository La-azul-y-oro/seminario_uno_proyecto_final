import { Component } from '@angular/core';
import { FormField, TypeField } from '../../interfaces/components.interface';
import { ConsortiumRequest } from '../../interfaces/model.interfaces';
import { Validators } from '@angular/forms';
import { noWhitespaceValidator } from '../../util/customValidators';
import { GenericFormComponent } from '../form/generic-form.class';
import { FormComponent } from '../form/form.component';

@Component({
  selector: 'app-consortium-form',
  standalone: true,
  imports: [
    FormComponent
  ],
  templateUrl: './consortium-form.component.html'
})
export class ConsortiumFormComponent extends GenericFormComponent<ConsortiumRequest> {

  fields: FormField[] = [{
    label: 'Consorcio',
    controlName: 'name',
    type: TypeField.TEXT,
    placeholder: 'Ingrese el nombre',
    errorMessage: 'Dato obligatorio. Máximo 255 caracteres.',
    validators: [Validators.required, Validators.maxLength(255), noWhitespaceValidator]
  },
  {
    label: 'Dirección',
    controlName: 'address',
    type: TypeField.TEXT,
    placeholder: 'Ingrese la dirección',
    errorMessage: 'Dato obligatorio. Máximo 255 caracteres.',
    validators: [Validators.required, Validators.maxLength(255), noWhitespaceValidator]
  }
  ];
}

