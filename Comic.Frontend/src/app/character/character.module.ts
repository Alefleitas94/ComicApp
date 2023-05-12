import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddComponent } from './pages/add/add.component';
import { SearchComponent } from './pages/search/search.component';
import { CharacterComponent } from './pages/character/character.component';
import { HomeComponent } from './pages/home/home.component';
import { CharacterRoutingModule } from './character-routing.module';
import { MaterialModule } from '../material/material.module';
import { ListComponent } from './pages/list/list.component';
import { CardComponent } from './components/card/card.component';



@NgModule({
  declarations: [
    AddComponent,
    SearchComponent,
    CharacterComponent,
    HomeComponent,
    ListComponent,
    CardComponent
  ],
  imports: [
    CommonModule,
    CharacterRoutingModule,
    MaterialModule
  ]
})
export class CharacterModule { }
