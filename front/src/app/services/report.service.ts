import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../enviroments/enviroments";
import { ExpensesRequest, FinancialRequest } from "../interfaces/model.interfaces";

@Injectable({
  providedIn: 'root'
})
export class ReportService {
  protected baseUrl: string;

  constructor(protected httpClient: HttpClient) {
    this.baseUrl = `${environment.apiUrl}/report`;
  }
  
  getExpenseReport(request: ExpensesRequest): Observable<Blob> {
    const params: any = {
      year: request.year,
      month: request.month
    };

    return this.httpClient.get(`${this.baseUrl}/consortium/expenses/${request.consortiumId}`, {
      params,
      responseType: 'blob'
    });
  }

  
  getFinancialReport(request: FinancialRequest): Observable<Blob> {
    const params: any = {
      year: request.year,
      format: request.format
    };

    if (request.month !== undefined) {
      params.month = request.month;
    }

    return this.httpClient.get(`${this.baseUrl}/financial/${request.consortiumId}`, {
      params,
      responseType: 'blob'
    });
  }
}
