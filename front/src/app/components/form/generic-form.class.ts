import { EventEmitter, Input, Output, ViewChild, Directive } from '@angular/core';
import { FormComponent } from './form.component';
import { FormField } from '../../interfaces/components.interface';

@Directive()
export abstract class GenericFormComponent<T> {
  @ViewChild("form") formComponent!: FormComponent;
  @Input() data?: T;
  @Output() onSave = new EventEmitter<T>();
  @Output() onUpdate = new EventEmitter<T>();

  abstract fields: FormField[];

  saveData(data: T) {
    this.onSave.emit(data);
  }

  updateData(data: T) {
    this.onUpdate.emit(data);
  }

  showForm() {
    this.formComponent.form.reset();
    this.formComponent.visible = true;
  }

  resetAndHideForm() {
    this.formComponent.resetAll();
    this.formComponent.visible = false;
  }
}
