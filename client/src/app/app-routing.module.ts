import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DaneComponent } from './dane/dane.component';
import { HomeComponent } from './home/home.component';
import { InneComponent } from './inne/inne.component';

import { WykresComponent } from './wykres/wykres.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'wykres', component: WykresComponent },
  { path: 'dane', component: DaneComponent },
  { path: 'inne', component: InneComponent },
  { path: '**', component: HomeComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
