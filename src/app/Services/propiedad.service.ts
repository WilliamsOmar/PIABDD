import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { appsettings } from '../Settings/appsettings';
import { Propiedad } from '../Models/Propiedades';
import { ResponseAPI } from '../Models/ResponseAPI';

@Injectable({
  providedIn: 'root'
})
export class PropiedadService {

  private http = inject(HttpClient);
  private apiURL:string =appsettings.apiURL + "Pia";

  constructor() { }

  lista(){
    return this.http.get<Propiedad[]>(this.apiURL);
  }

  obtener(id:number){
    return this.http.get<Propiedad>(`${this.apiURL}/${id}`);
  }

  crear(objeto:Propiedad){
    return this.http.post<ResponseAPI>(this.apiURL,objeto);
  }

  editar(objeto:Propiedad){
    return this.http.put<ResponseAPI>(this.apiURL,objeto);
  }

  eliminar(id:number){
    return this.http.delete<ResponseAPI>(`${this.apiURL}/${id}`);
  }
}
