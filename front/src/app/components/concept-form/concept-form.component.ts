import { Component } from '@angular/core';

import { FormField, TypeField } from '../../interfaces/components.interface';
import { ConceptRequest, MovementType } from '../../interfaces/model.interfaces';
import { Validators } from '@angular/forms';
import { noWhitespaceValidator } from '../../util/customValidators';
import { GenericFormComponent } from '../form/generic-form.class';
import { FormComponent } from '../form/form.component';
import { enumToSelectOptions } from '../../util/enumUtils';

@Component({
  selector: 'app-concept-form',
  standalone: true,
  imports: [
    FormComponent
  ],
  templateUrl: './concept-form.component.html'
})
export class ConceptFormComponent extends GenericFormComponent<ConceptRequest> {
  
  fields: FormField[] = [
    {
      label: 'Concepto', 
      controlName: 'name', 
      type: TypeField.TEXT, 
      placeholder: 'Ingrese el nombre del concepto', 
      errorMessage: 'Dato obligatorio. Máximo 255 caracteres.',
      validators: [Validators.required, Validators.maxLength(255), noWhitespaceValidator]
    },
    {
      label: 'Tipo',
      controlName: 'type',
      type: TypeField.SELECT,
      placeholder: 'Ingrese el tipo de movimiento',
      errorMessage: 'Dato obligatorio.',
      validators: [Validators.required],
      selectList: enumToSelectOptions(MovementType)
    }
  ];
}
