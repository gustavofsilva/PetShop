import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { DonoAnimal } from "../Models/DonoAnimal";

@Injectable({
    providedIn: 'root'
})
export class DonoService {

    baseURL = 'http://localhost:5000/api/DonoAnimal';

    constructor(private http: HttpClient) {
        
    }
    
    postDono(dono: DonoAnimal): Observable<DonoAnimal> {
        return this.http.post<DonoAnimal>(this.baseURL + "/post", dono);
    }
}
