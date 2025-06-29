import { HttpClient } from "@angular/common/http";
import { MovementRequest, MovementResponse } from "../interfaces/model.interfaces";
import { GenericService } from "./generic-service.class";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class MovementService extends GenericService<MovementRequest, MovementResponse> {
    constructor(httpClient: HttpClient) {
        super(httpClient, "movement");
    }
}