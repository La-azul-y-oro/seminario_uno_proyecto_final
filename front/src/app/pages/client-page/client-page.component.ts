import { Component } from '@angular/core';
import { PageComponent } from '../../components/page/page.component';
import { ActionButtonConfig } from '../../components/action-buttons/action-buttons.component';
import { Column } from '../../interfaces/components.interface';
import { FunctionalUnitService } from '../../services/functional-unit.service';
import { ConfirmDialogService } from '../../components/confirm-dialog/confirm-dialog-service';
import { ToastService } from '../../components/toast/toast-service';
import { finalize } from 'rxjs';
import { ClientFunctionalUnit, LiquidationForClient } from '../../interfaces/model.interfaces';
import { AuthService } from '../../auth/auth.service';
import { ClientLiquidationDialogComponent } from '../../components/client-liquidation-dialog/client-liquidation-dialog.component';

@Component({
  selector: 'app-client-page',
  standalone: true,
  imports: [
    PageComponent,
    ClientLiquidationDialogComponent
  ],
  templateUrl: './client-page.component.html',
  styleUrl: './client-page.component.css'
})
export class ClientPageComponent {
  title: string = "Mis unidades";

  isLoading: boolean = false;
  hasError: boolean = false;
  isEmpty: boolean = false;

  columns: Column[] = [
    { header: "Consorcio", field: "consortium", sortable: true },
    { header: "Dirección", field: "consortiumAddress", sortable: true },
    { header: "Unidad", field: "name", sortable: true },
    { header: "Balance actual ($)", field: "balance", sortable: true },
    { header: "Factor ocupación (%)", field: "factor", sortable: true }
  ];

  buttonConfig : ActionButtonConfig[] = [
    { 
      icon: 'pi pi-file', 
      tooltip: 'Liquidaciones', 
      severity: 'info',
      action: (data: ClientFunctionalUnit) => this.openLiquidationDialog(data.liquidations)
    }
  ];

  dataList: any[] = [];

  showLiquidationDialog: boolean = false;
  liquidations: LiquidationForClient[]= [];

  constructor(
    private readonly functionalUnitService: FunctionalUnitService,
    private readonly authService : AuthService   
  ) { }

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    const userId = this.getUserId();
    this.isLoading = true;
    this.functionalUnitService.getByClientId(userId).pipe(
      finalize(() => {
        this.isLoading = false;
      })
    ).subscribe({
      next: (response) => {
        this.dataList = response;
        this.isEmpty = this.dataList.length <= 0;
      },
      error: (error) => {
        console.error("Error al cargar los datos:", error);
        this.hasError = true;
      }
    });
  }

  openLiquidationDialog(data: LiquidationForClient[]){
    this.showLiquidationDialog = true;
    this.liquidations = data;
  }

  private getUserId() : string{
    const userInfo = this.authService?.userData as any;

    return userInfo?.id;
  }
}
