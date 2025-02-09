import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ConceptRequest, ConceptResponse } from "../interfaces/model.interfaces";
import { GenericService } from "./generic-service.class";

@Injectable({
  providedIn: 'root'
})
export class ConceptService extends GenericService<ConceptRequest, ConceptResponse> {
  constructor(httpClient: HttpClient) {
    super(httpClient, "concept");
  }
}
