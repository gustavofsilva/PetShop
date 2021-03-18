import { Animal } from "./Animal";

export class Alojamento {
    
    constructor() {
        
    }

    id: number=0;
    ocupado: string = 'Livre';
    animalId: Number = 0;
    animal: Animal = new Animal();
}
