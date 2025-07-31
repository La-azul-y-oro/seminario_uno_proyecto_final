import { Injectable } from '@angular/core';
import { AssignClientsRequest, FunctionalUnitRequest, FunctionalUnitResponse, UnitFunctionalConsortium } from '../interfaces/model.interfaces';
import { GenericService } from './generic-service.class';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../enviroments/enviroments';

@Injectable({
  providedIn: 'root'
})
export class FunctionalUnitService extends GenericService<FunctionalUnitRequest, FunctionalUnitResponse> {
  constructor(httpClient: HttpClient) {
    super(httpClient, "functionalunit");
  }

  getByConsortiumId(consortiumId: number) : Observable<any []> {
    const customUrl = `${environment.apiUrl}/functionalunit/consortium/${consortiumId}`;
    return this.httpClient.get<any []>(customUrl);
  }

  updateClients(body: AssignClientsRequest) : Observable<void> {
    const customUrl = `${environment.apiUrl}/functionalunit/assign-clients`;
    return this.httpClient.post<void>(customUrl, body);
  }

  getByClientId(clientId: any) : Observable<any []> {
    const customUrl = `${environment.apiUrl}/functionalunit/client/${clientId}`;
    return this.httpClient.get<any []>(customUrl);
  }

  updateFunctionalUnits(body: any) : Observable<UnitFunctionalConsortium []> {
    const customUrl = `${environment.apiUrl}/functionalunit/update-units`;
    return this.httpClient.post<UnitFunctionalConsortium []>(customUrl, body);
  }
}