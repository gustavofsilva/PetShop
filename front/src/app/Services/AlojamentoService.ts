import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Alojamento } from "../Models/Alojamento";


@Injectable({
    providedIn: 'root'
})
export class AlojamentoService {
    baseURL = 'http://localhost:5000/api/Alojamento';

    
    constructor(private http: HttpClient) {
        
    }

    getAlojamentos(): Observable<Alojamento[]>{
        return this.http.get<Alojamento[]>(this.baseURL);
    }

    UpdateAlojamento(alojamento: Alojamento): Observable<Alojamento> {
        return this.http.put<Alojamento>(this.baseURL + "/put", alojamento);
    }

    CreateAlojamento(alojamento: Alojamento): Observable<Alojamento> {
        return this.http.post<Alojamento>(this.baseURL + "/post", alojamento);
    }
}
