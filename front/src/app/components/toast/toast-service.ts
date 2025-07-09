// toast.service.ts
import { Injectable } from '@angular/core';
import { ToastComponent } from './toast.component';

@Injectable({ providedIn: 'root' })
export class ToastService {
  private toastComponent!: ToastComponent;

  register(toast: ToastComponent) {
    this.toastComponent = toast;
  }

  // Métodos de delegación
  showSuccessDelete() {
    this.toastComponent.showSuccessDelete();
  }
  showErrorDelete() {
    this.toastComponent.showErrorDelete();
  }

  showSuccessCreate() {
    this.toastComponent.showSuccessCreate();
  }
  showErrorCreate() {
    this.toastComponent.showErrorCreate();
  }

  showSuccessUpdate() {
    this.toastComponent.showSuccessUpdate();
  }
  showErrorUpdate() {
    this.toastComponent.showErrorUpdate();
  }

  setSuccessMessage(msg: string) {
    this.toastComponent.setSuccessMessage(msg);
  }
  setErrorMessage(msg: string) {
    this.toastComponent.setErrorMessage(msg);
  }
}
