import { Component } from '@angular/core';
import { FormComponent } from '../form/form.component';
import { GenericFormComponent } from '../form/generic-form.class';
import { DocumentType, Role, UserRequest } from '../../interfaces/model.interfaces';
import { FormField, TypeField } from '../../interfaces/components.interface';
import { Validators } from '@angular/forms';
import { emailCustomValidator, noWhitespaceValidator } from '../../util/customValidators';
import { enumToSelectOptions } from '../../util/enumUtils';

@Component({
  selector: 'app-user-form',
  standalone: true,
  imports: [FormComponent],
  templateUrl: './user-form.component.html',
  styleUrl: './user-form.component.css'
})
export class UserFormComponent extends GenericFormComponent<UserRequest>{
    fields: FormField[] = [
      {
        label: 'Nombre', 
        controlName: 'firstName', 
        type: TypeField.TEXT, 
        placeholder: 'Ingrese el nombre', 
        errorMessage: 'Dato obligatorio. Máximo 255 caracteres.',
        validators: [Validators.required, Validators.maxLength(255), noWhitespaceValidator],
      },
      {
        label: 'Apellido', 
        controlName: 'lastName', 
        type: TypeField.TEXT, 
        placeholder: 'Ingrese el apellido', 
        errorMessage: 'Dato obligatorio. Máximo 255 caracteres.',
        validators: [Validators.required, Validators.maxLength(255), noWhitespaceValidator],
      },
      {
        label: 'Tipo Documento',
        controlName: 'documentType',
        type: TypeField.SELECT,
        placeholder: 'Ingrese el CUIT',
        errorMessage: 'Dato obligatorio',
        validators: [Validators.required],
        selectList: enumToSelectOptions(DocumentType)
      },
      {
        label: 'Número documento',
        controlName: 'documentNumber',
        type: TypeField.NUMBER,
        placeholder: 'Ingrese el número de documento',
        errorMessage: 'Dato obligatorio.',
        validators: [Validators.required]
      },
      {
        label: 'Rol',
        controlName: 'role',
        type: TypeField.SELECT,
        placeholder: 'Ingrese el role',
        errorMessage: 'Dato obligatorio',
        validators: [Validators.required],
        selectList: enumToSelectOptions(Role)
      },
      {
        label: 'E-mail',
        controlName: 'email',
        type: TypeField.TEXT,
        placeholder: 'Ingrese el email',
        errorMessage: 'Dato obligatorio. Formato inválido.',
        validators: [Validators.required, emailCustomValidator]
      },
      {
        label: 'Teléfono',
        controlName: 'phone',
        type: TypeField.TEXT,
        placeholder: 'Ingrese el teléfono',
        errorMessage: 'Dato obligatorio.',
        validators: [Validators.required] //TODO crear validador para telefono 
      },
      {
        label: 'Contraseña',
        controlName: 'password',
        type: TypeField.PASSWORD,
        placeholder: 'Ingrese la contraseña',
        errorMessage: 'Dato obligatorio',
        validators: [Validators.required],
        disabledOnUpdate: true
      },
    ];  
}
