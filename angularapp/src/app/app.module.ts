import { AppComponent } from "./app.component";
import { PetsComponent } from './pets/pets.component';

import { MatTableModule } from '@angular/material/table';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { MessagesComponent } from './messages/messages.component';
import { PetComponent } from './pet/pet.component';
import { WeightListComponent } from './weight-list/weight-list.component';
import { MatPaginatorModule } from "@angular/material/paginator";
import { DetailsComponent } from './details/details.component';

@NgModule({
  declarations: [
    AppComponent,
    PetsComponent,
    MessagesComponent,
    PetComponent,
    WeightListComponent,
    DetailsComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    HttpClientModule,
    MatTableModule,
    MatPaginatorModule
  ],
  providers: [
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
