import { DonoAnimal } from "./DonoAnimal";

export class Animal {

    
    constructor() {
        
    }

    id: number = 0;
    nome: string = ' ';
    motivoInternacao: string = ' ';    
    estadoSaude: string = ' ';
    foto: string = ' ';
    dono: DonoAnimal = new DonoAnimal();
}
