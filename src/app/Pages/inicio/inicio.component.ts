import { Component, inject } from '@angular/core';

import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { PropiedadService } from '../../Services/propiedad.service';
import { Propiedad } from '../../Models/Propiedades';
import { Router } from '@angular/router';

@Component({
  selector: 'app-inicio',
  standalone: true,
  imports: [MatCardModule, MatTableModule, MatIconModule, MatButtonModule],
  templateUrl: './inicio.component.html',
  styleUrl: './inicio.component.css'
})
export class InicioComponent {

  private propiedadServicio = inject(PropiedadService);
  public listaPropiedades:Propiedad[] = [];
  public displayedColumns : string[] = [
    'IDPropiedad',
    'TerrenoM2',
    'Descripcion',
    'CantCuartos',
    'CantBanhos',
    'CantDormitorios',
    'NotasExtra',
    'Precio',
    'FechaDeCompra',
    'IDDireccionPropiedadesP',
    'IDEstatusPropiedadP',
    'IDPropietarioP',
    'accion'];

  obtenerPropiedades(){
    this.propiedadServicio.lista().subscribe({
      next:(data)=>{
        if(data.length > 0){
          this.listaPropiedades = data;
        }
      },
      error:(err)=>{
        console.log(err.message)
      }
    })
  }

  constructor(private router:Router){
    this.obtenerPropiedades();
  }

  nuevo(){
    this.router.navigate(['/Pia',0]);
  }

  editar(objeto:Propiedad){
    this.router.navigate(['/Pia',objeto.IDPropiedad]);
  }

  eliminar(objeto:Propiedad){
    if(confirm("Desea Eliminar la Propiedad " + objeto.IDPropiedad)){
      this.propiedadServicio.eliminar(objeto.IDPropiedad).subscribe({
        next:(data)=>{
          if(data.isSuccess){
            this.obtenerPropiedades();
          }
          else{
            alert("No se logró eliminar")
          }
        },
        error:(err)=>{
          console.log(err.message)
        }
      })
    }
  }
}
