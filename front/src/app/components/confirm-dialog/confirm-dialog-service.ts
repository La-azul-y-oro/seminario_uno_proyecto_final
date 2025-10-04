import { Injectable } from '@angular/core';
import { ConfirmDialogComponent, DialogConfirmConfig } from './confirm-dialog.component';
import { Subject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ConfirmDialogService {
  private dialogComponent!: ConfirmDialogComponent;
  private confirmSubject!: Subject<any>;

  register(dialog: ConfirmDialogComponent) {
    this.dialogComponent = dialog;

    this.dialogComponent.onConfirm.subscribe((id) => {
      if (this.confirmSubject) {
        this.confirmSubject.next(id);
        this.confirmSubject.complete();
      }
    });
  }

  open(config: DialogConfirmConfig) {
    this.confirmSubject = new Subject<any>();
    this.dialogComponent.openDialog(config);
    return this.confirmSubject.asObservable();
  }
}