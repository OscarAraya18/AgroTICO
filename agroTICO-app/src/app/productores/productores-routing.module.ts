import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProductoresPage } from './productores.page';

const routes: Routes = [
  {
    path: '',
    component: ProductoresPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProductoresPageRoutingModule {}
