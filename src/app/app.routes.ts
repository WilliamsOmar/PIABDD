import { Routes } from '@angular/router';
import { InicioComponent } from './Pages/inicio/inicio.component';
import { PropiedadesComponent } from './Pages/propiedades/propiedades.component';

export const routes: Routes = [
  {path:'', component:InicioComponent},
  {path:'inicio', component:InicioComponent},
  {path:'Pia/:id', component:PropiedadesComponent},
];
