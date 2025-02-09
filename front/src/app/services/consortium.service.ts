import { Injectable } from '@angular/core';
import { ConsortiumRequest, ConsortiumResponse } from '../interfaces/model.interfaces';
import { HttpClient } from '@angular/common/http';
import { GenericService } from './generic-service.class';

@Injectable({
  providedIn: 'root'
})
export class ConsortiumService extends GenericService<ConsortiumRequest, ConsortiumResponse> {
  constructor(httpClient: HttpClient) {
    super(httpClient, "consortium");
  }
}
