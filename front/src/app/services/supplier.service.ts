import { Injectable } from '@angular/core';
import { SupplierRequest, SupplierResponse } from '../interfaces/model.interfaces';
import { GenericService } from './generic-service.class';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SupplierService extends GenericService<SupplierRequest, SupplierResponse> {
  constructor(httpClient: HttpClient) {
    super(httpClient, "supplier");
  }
}