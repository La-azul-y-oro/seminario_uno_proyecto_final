import { Component, Input } from '@angular/core';
import { FormField, TypeField } from '../../interfaces/components.interface';
import { ConceptResponse, SupplierRequest } from '../../interfaces/model.interfaces';
import { Validators } from '@angular/forms';
import { cuitValidator, emailCustomValidator, noWhitespaceValidator, phoneValidator } from '../../util/customValidators';
import { GenericFormComponent } from '../form/generic-form.class';
import { FormComponent } from '../form/form.component';

@Component({
  selector: 'app-supplier-form',
  standalone: true,
  imports: [
    FormComponent,
  ],
  templateUrl: './supplier-form.component.html'
})
export class SupplierFormComponent extends GenericFormComponent<SupplierRequest> {
  override fields: FormField[] = [];

  @Input() conceptList: ConceptResponse[] = [];
  @Input() isReady : boolean = false;
  @Input() hasError : boolean = false;

  ngOnChanges() {
    if (this.conceptList.length > 0) {
      this.initializeFields();
    }
  }

  initializeFields() {
    this.fields = [{
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
      type: TypeField.TEXT,
      placeholder: 'Ingrese el teléfono',
      errorMessage: 'Dato obligatorio. Debe contener exactamente 10 dígitos.',
      validators: [Validators.required, phoneValidator]
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
      label: 'Categorias',
      controlName: 'concepts',
      type: TypeField.MULTISELECT,
      placeholder: 'Seleccione las categorias',
      errorMessage: 'Seleccione al menos una categoria',
      validators: [Validators.required],
      selectList: this.conceptList
    }
    ];
  }
}

