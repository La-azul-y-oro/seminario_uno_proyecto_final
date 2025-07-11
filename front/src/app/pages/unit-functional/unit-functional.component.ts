import { Component } from '@angular/core';
import { GenericComponent } from '../generic-component.class';
import { UnitFunctionalRequest } from '../../interfaces/model.interfaces';
import { PageComponent } from '../../components/page/page.component';
import { ActionButtonConfig } from '../../components/action-buttons/action-buttons.component';
import { FunctionalUnitService } from '../../services/functional-unit.service';
import { ConfirmDialogService } from '../../components/confirm-dialog/confirm-dialog-service';
import { ToastService } from '../../components/toast/toast-service';
import { AuthService } from '../../auth/auth.service';

@Component({
  selector: 'app-unit-functional',
  standalone: true,
  imports: [
    PageComponent
  ],
  templateUrl: './unit-functional.component.html',
  styleUrl: './unit-functional.component.css'
})
export class UnitFunctionalComponent extends GenericComponent<UnitFunctionalRequest, UnitFunctionalRequest> {
  override title = "Unidades funcionales";

  columns = [
    { header: "Unidad", field: "name", sortable: true },
    { header: "Consorcio", field: "consortium.name", sortable: true },
    { header: "Factor (%)", field: "factor", sortable: true },
    { header: "Balance ($)", field: "balance", sortable: true }
  ];

  buttonConfig: ActionButtonConfig[] = [];

  constructor(
    service: FunctionalUnitService,
    confirmService: ConfirmDialogService,
    toastService: ToastService,
    authService: AuthService
  ) {
    super(service, confirmService, toastService, authService);
  }
}
