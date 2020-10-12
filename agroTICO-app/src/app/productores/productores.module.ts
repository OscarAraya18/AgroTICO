import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ProductoresPageRoutingModule } from './productores-routing.module';

import { ProductoresPage } from './productores.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ProductoresPageRoutingModule
  ],
  declarations: [ProductoresPage]
})
export class ProductoresPageModule {}
