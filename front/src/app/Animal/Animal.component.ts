import { Component, OnInit } from '@angular/core';
import { Animal } from '../Models/Animal';
import { AnimalService } from '../Services/AnimalService';

@Component({
  selector: 'app-Animal',
  templateUrl: './Animal.component.html',
  styleUrls: ['./Animal.component.scss']
})
export class AnimalComponent implements OnInit {

  animal: Animal = new Animal();

  constructor(
    private animalService: AnimalService
  ) { }

  ngOnInit() {
  }

  pesquisaByNome (nome: string) {
    if (nome == '' || nome == null) return;
    
    this.animalService.getAnimalByNome(nome)
    .subscribe( response => {
      this.animal = response;
    }, error => {
      console.log(error);
    })
  }

}
