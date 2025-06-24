import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../enviroments/enviroments";
import { Liquidation, LiquidationRequest } from "../interfaces/model.interfaces";

@Injectable({
  providedIn: 'root'
})
export class LiquidationService{
  protected baseUrl: string;

  constructor(protected httpClient: HttpClient) {
    this.baseUrl = `${environment.apiUrl}/liquidation`;
  }

  generateLiquidation(request: LiquidationRequest): Observable<any> {
    return this.httpClient.post<any>(this.baseUrl, request);
  }

  getAllByConsortiumId(consortiumId : number): Observable<Liquidation[]> {
    return this.httpClient.get<Liquidation[]>(`${this.baseUrl}/consortium/${consortiumId}`);
  }
}
