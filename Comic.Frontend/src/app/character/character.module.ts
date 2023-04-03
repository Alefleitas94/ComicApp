import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddComponent } from './pages/add/add.component';
import { SearchComponent } from './pages/search/search.component';
import { CharacterComponent } from './pages/character/character.component';
import { HomeComponent } from './pages/home/home.component';
import { HeroListComponent } from './pages/hero-list/hero-list.component';



@NgModule({
  declarations: [
    AddComponent,
    SearchComponent,
    CharacterComponent,
    HomeComponent,
    HeroListComponent
  ],
  imports: [
    CommonModule
  ]
})
export class CharacterModule { }
