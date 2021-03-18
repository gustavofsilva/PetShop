import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Alojamento } from '../Models/Alojamento';
import { Animal } from '../Models/Animal';
import { DonoAnimal } from '../Models/DonoAnimal';
import { AlojamentoService } from '../Services/AlojamentoService';

@Component({
  selector: 'app-PetShop',
  templateUrl: './PetShop.component.html',
  styleUrls: ['./PetShop.component.css']
})
export class PetShopComponent implements OnInit {

  alojamentos: Alojamento[] = [];

  public registerForm: FormGroup | any;
  public alojamento: Alojamento = new Alojamento();
  public animal: Animal = new Animal();
  public dono: DonoAnimal = new DonoAnimal();
  

  constructor(
    private alojamentoService: AlojamentoService
    , private fb: FormBuilder
  ) { }

  ngOnInit() {

    this.getAlojamentos();
    this.validation();
  }

  getAlojamentos () {
    this.alojamentoService.getAlojamentos()
    .subscribe(
      response => {
        console.log(response);
                
        this.alojamentos = response;
        response.forEach(element => {
          if (element.animal == null) {
            element.animal = new Animal();
          }
          if (element.animal.dono == null) {
            element.animal.dono = new DonoAnimal();
          }
        });
      }, error => {
        console.log(error);
      }
    )
  }

  salvarAlteracao (template: any) {    

    this.alojamento.animal = new Animal();
    this.alojamento.animal.dono = new DonoAnimal();

    this.alojamento.ocupado = "ocupado";


    this.alojamento.animal.estadoSaude = this.registerForm.controls['estadoSaude'].value;
    this.alojamento.animal.motivoInternacao = this.registerForm.controls['motivoInternacao'].value;
    this.alojamento.animal.foto = this.registerForm.controls['foto'].value;
    this.alojamento.animal.nome = this.registerForm.controls['name'].value;


    this.alojamento.animal.dono.nome = this.registerForm.controls['donoNome'].value;
    this.alojamento.animal.dono.telefone = this.registerForm.controls['telefone'].value;
    this.alojamento.animal.dono.endereco = this.registerForm.controls['endereco'].value;
    

    this.alojamentoService.UpdateAlojamento(this.alojamento)
    .subscribe ( () => {
      this.getAlojamentos();
    }, error => {
      console.log(error);

    });

    template.hide();
  }  
  

  openModal (template: any) {
    this.registerForm.reset();
    template.show();
  }

  editarAlojamento (alojamento: Alojamento, template: any) {
    this.openModal(template);
    this.alojamento = alojamento;
    this.registerForm.patchValue(alojamento);
    
  }

  deleteAnimal (alojamento: Alojamento) {
    this.alojamento = new Alojamento();
    this.alojamento.id = alojamento.id;
    
    console.log(alojamento);
    this.alojamentoService.UpdateAlojamento(this.alojamento)
    .subscribe( () => {
      this.getAlojamentos();
    }, error => {
      console.log(error);
    });
   
    
  }

  validation (){
    this.registerForm = this.fb.group ({
      name: ['', [Validators.required]],
      motivoInternacao: ['', [Validators.required]],
      estadoSaude: ['', [Validators.required]],
      foto: [''],
      donoNome: ['', [Validators.required]],
      telefone: ['', [Validators.required]],
      endereco: ['', [Validators.required]]
    });
  }
}
