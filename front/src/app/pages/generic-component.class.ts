import { Directive, ViewChild, OnInit } from '@angular/core';
import { GenericService } from '../services/generic-service.class';
import { ConfirmDialogComponent } from '../components/confirm-dialog/confirm-dialog.component';
import { ToastComponent } from '../components/toast/toast.component';
import { ActionButtonConfig } from '../components/action-buttons/action-buttons.component';
import { Column } from '../interfaces/components.interface';
import { finalize } from 'rxjs';

@Directive()
export abstract class GenericComponent<TRequest, TResponse> implements OnInit {
  @ViewChild('dialog') dialog!: ConfirmDialogComponent;
  @ViewChild('toast') toast!: ToastComponent;
  @ViewChild('form') form!: any;

  title!: string;
  labelButtonAdd!: string;
  idToUpdate?: number;
  dataList: TResponse[] = [];
  dataObject?: TRequest;

  isLoading: boolean = false;
  hasError: boolean = false;
  isEmpty: boolean = false;


  abstract columns: Column[];
  abstract buttonConfig: ActionButtonConfig[];

  constructor(protected service: GenericService<TRequest, TResponse>) { }

  ngOnInit() {
    this.loadData();
  }

  protected transformResponseData(data: TResponse[]): TResponse[] {
    return data;
  }

  loadData() {
    this.isLoading = true;
    this.hasError = false;
    this.isEmpty = false;

    this.service.getAll().pipe(
      finalize(() => {
        this.isLoading = false;
      })
    ).subscribe({
      next: (response) => {
        const filteredData = response.filter(e => (e as any).active);
        this.dataList = this.transformResponseData(filteredData);
        this.isEmpty = this.dataList.length === 0;
      },
      error: (error) => {
        this.hasError = true;
        console.error("Error al cargar los datos:", error);
      }
    });
  }

  openForm() {
    this.form.showForm();
  }

  save(data: TRequest) {
    this.service.create(data).subscribe({
      next: response => {
        this.toast.showSuccessCreate();
        this.handlePostCreate(response);
      },
      error: error => {
        this.toast.showErrorCreate();
        console.error(error);
      }
    });
  }

  openFormEdit(data: any) {
    this.idToUpdate = data.id;
    this.dataObject = { ...data };
    this.form.showForm();
  }

  update(data: TRequest) {
    this.service.update(this.idToUpdate!, data).subscribe({
      next: response => {
        this.toast.showSuccessUpdate();
        this.handlePostUpdate(response);
      },
      error: error => {
        this.toast.showErrorUpdate();
        console.error(error);
      }
    });
  }

  openConfirmDialog(data: any) {
    this.dialog.openDialog(data.id);
  }

  deleteItem(id: number) {
    this.service.deleteById(id).subscribe({
      next: () => {
        this.toast.showSuccessDelete();
        this.dataList = this.dataList.filter(item => (item as any).id !== id);
        if (this.dataList.length == 0) this.isEmpty = true;
      },
      error: error => {
        this.toast.showErrorDelete();
        console.error(error);
      }
    });
  }

  handlePostCreate(response: TResponse) {
    this.isEmpty = false;
    const processNewData = this.transformResponseData([response]);
    this.dataList = [...this.dataList, processNewData[0]];
    this.form.resetAndHideForm();
  }

  handlePostUpdate(response: TResponse) {
    if (response === null) {
      this.updateDataListWithId(this.idToUpdate!);
    }
    this.form.resetAndHideForm();
    this.idToUpdate = undefined;
    this.dataObject = undefined;
  }

  updateDataListWithId(id: number): void {
    this.service.getById(id).subscribe({
      next: updatedData => {
        const index = this.dataList.findIndex(item => (item as any).id === id);
        if (index !== -1) {
          const processNewData = this.transformResponseData([updatedData]);
          this.dataList[index] = processNewData[0];
        }
      },
      error: error => {
        console.error("Error al obtener el dato actualizado", error);
      }
    });
  }

}
