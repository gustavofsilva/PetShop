import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Animal } from "../Models/Animal";

@Injectable({
    providedIn: 'root'
})
export class AnimalService {

    baseURL = 'http://localhost:5000/api/Animal';

    constructor(private http: HttpClient) {
        
    }
    
    postAnimal(animal: Animal): Observable<Animal> {
        return this.http.post<Animal>(this.baseURL + "/post", animal);
    }

    getAnimalByNome(nome: string): Observable<Animal> {
        return this.http.get<Animal>(this.baseURL + '/Nome?Nome=' + nome);
    }

}
