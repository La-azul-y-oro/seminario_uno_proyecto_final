import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../enviroments/enviroments";

/**
 * @param <T> Request
 * @param <R> Response
 */
export abstract class GenericService<T, R> {
  protected baseUrl: string;

  constructor(protected httpClient: HttpClient, resource: string) {
    this.baseUrl = `${environment.apiUrl}/${resource}`;
  }

  getAll(): Observable<R[]> {
    return this.httpClient.get<R[]>(this.baseUrl);
  }

  getById(id: number): Observable<R> {
    return this.httpClient.get<R>(`${this.baseUrl}/${id}`);
  }

  deleteById(id: number): Observable<void> {
    return this.httpClient.delete<void>(`${this.baseUrl}/${id}`);
  }

  update(id: number, request: T): Observable<R> {
    return this.httpClient.put<R>(`${this.baseUrl}/${id}`, request);
  }

  create(request: T): Observable<R> {
    return this.httpClient.post<R>(this.baseUrl, request);
  }
}
