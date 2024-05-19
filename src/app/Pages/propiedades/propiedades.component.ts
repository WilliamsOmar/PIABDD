import { Component, Input, OnInit, inject } from '@angular/core';

import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { PropiedadService } from '../../Services/propiedad.service';
import { Router } from '@angular/router';
import { Propiedad } from '../../Models/Propiedades';


@Component({
  selector: 'app-propiedades',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatButtonModule, ReactiveFormsModule],
  templateUrl: './propiedades.component.html',
  styleUrl: './propiedades.component.css'
})
export class PropiedadesComponent implements OnInit{

  @Input('id') IDPropiedad! : number;
  private propiedadServicio = inject(PropiedadService);
  public formBuild = inject(FormBuilder);

  public formPropiedad:FormGroup = this.formBuild.group({
    TerrenoM2:[0],
    Descripcion:[''],
    CantCuartos:[0],
    CantBanhos:[0],
    CantDormitorios:[0],
    NotasExtra:[''],
    Precio:[0],
    FechaDeCompra:[''],
    IDDireccionPropiedadesP:[0],
    IDEstatusPropiedadP:[0],
    IDPropietarioP:[0]
  })

  constructor(private router:Router){

  }

  ngOnInit(): void {
    if(this.IDPropiedad != 0){
      this.propiedadServicio.obtener(this.IDPropiedad).subscribe({
        next:(data) =>{
          this.formPropiedad.patchValue({
            TerrenoM2:data.TerrenoM2,
            Descripcion:data.Descripcion,
            CantCuartos:data.CantCuartos,
            CantBanhos:data.CantBanhos,
            CantDormitorios:data.CantDormitorios,
            NotasExtra:data.NotasExtra,
            Precio:data.Precio,
            FechaDeCompra:data.FechaDeCompra,
            IDDireccionPropiedadesP:data.IDDireccionPropiedadesP,
            IDEstatusPropiedadP:data.IDEstatusPropiedadP,
            IDPropietarioP:data.IDPropietarioP
          })
        },
        error:(err)=>{
          console.log(err.message)
        }
      })
    }
  }


  guardar(){
    const objeto:Propiedad = {
    IDPropiedad: this.IDPropiedad,
    TerrenoM2: this.formPropiedad.value.TerrenoM2,
    Descripcion:this.formPropiedad.value.Descripcion,
    CantCuartos:this.formPropiedad.value.CantCuartos,
    CantBanhos:this.formPropiedad.value.CantBanhos,
    CantDormitorios:this.formPropiedad.value.CantDormitorios,
    NotasExtra:this.formPropiedad.value.NotasExtra,
    Precio:this.formPropiedad.value.Precio,
    FechaDeCompra:this.formPropiedad.value.FechaDeCompra,
    IDDireccionPropiedadesP:this.formPropiedad.value.IDDireccionPropiedadesP,
    IDEstatusPropiedadP:this.formPropiedad.value.IDEstatusPropiedadP,
    IDPropietarioP:this.formPropiedad.value.IDPropietarioP
    }

    if(this.IDPropiedad == 0){
      this.propiedadServicio.crear(objeto).subscribe({
        next:(data) =>{
          if(data.isSuccess){
            this.router.navigate(["/"]);
          }else{
            alert("Error al Crear")
          }
        },
        error:(err)=>{
          console.log(err.message)
        }
      })
    }else{
      this.propiedadServicio.editar(objeto).subscribe({
        next:(data) =>{
          if(data.isSuccess){
            this.router.navigate(["/"]);
          }else{
            alert("Error al Editar")
          }
        },
        error:(err)=>{
          console.log(err.message)
        }
      })
    }
  }

  volver(){
    this.router.navigate(["/"]);
  }

}
