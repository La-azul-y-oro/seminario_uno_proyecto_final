import { Component } from '@angular/core';
import { FormField, TypeField } from '../../interfaces/components.interface';
import { SupplierRequest } from '../../interfaces/model.interfaces';
import { EmailValidator, Validators } from '@angular/forms';
import { cuitValidator, emailCustomValidator, noWhitespaceValidator } from '../../util/customValidators';
import { GenericFormComponent } from '../form/generic-form.class';
import { FormComponent } from '../form/form.component';

@Component({
  selector: 'app-supplier-form',
  standalone: true,
  imports: [
    FormComponent
  ],
  templateUrl: './supplier-form.component.html'
})
export class SupplierFormComponent extends GenericFormComponent<SupplierRequest> {

  fields: FormField[] = [{
    label: 'Proveedor',
    controlName: 'name',
    type: TypeField.TEXT,
    placeholder: 'Ingrese el nombre',
    errorMessage: 'Dato obligatorio. Máximo 255 caracteres.',
    validators: [Validators.required, Validators.maxLength(255), noWhitespaceValidator]
  },
  {
    label: 'CUIT',
    controlName: 'cuit',
    type: TypeField.NUMBER,
    placeholder: 'Ingrese el CUIT',
    errorMessage: 'Dato obligatorio. Debe contener exactamente 11 dígitos.',
    validators: [Validators.required, cuitValidator]
  },
  {
    label: 'Teléfono',
    controlName: 'phone',
    type: TypeField.NUMBER,
    placeholder: 'Ingrese el teléfono',
    errorMessage: 'Dato obligatorio.',
    validators: [Validators.required]
  },
  {
    label: 'E-mail',
    controlName: 'email',
    type: TypeField.TEXT,
    placeholder: 'Ingrese el email',
    errorMessage: 'Dato obligatorio. Formato inválido.',
    validators: [Validators.required, emailCustomValidator]
  }
  ];
}

