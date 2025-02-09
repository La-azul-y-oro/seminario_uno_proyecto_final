import { Component } from '@angular/core';

import { FormField, TypeField } from '../../interfaces/components.interface';
import { ConceptRequest } from '../../interfaces/model.interfaces';
import { Validators } from '@angular/forms';
import { noWhitespaceValidator } from '../../util/customValidators';
import { GenericFormComponent } from '../form/generic-form.class';
import { FormComponent } from '../form/form.component';

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
      validators: [Validators.required, Validators.maxLength(255), noWhitespaceValidator],
      classList: "col-12 gap-1 margin-bottom"
    }
  ];
}
