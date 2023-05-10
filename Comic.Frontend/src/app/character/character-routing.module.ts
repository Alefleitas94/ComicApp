import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddComponent } from './pages/add/add.component';
import { SearchComponent } from './pages/search/search.component';
import { CharacterComponent } from './pages/character/character.component';
import { HomeComponent } from './pages/home/home.component';
import { ListComponent } from './pages/list/list.component';

const routes: Routes = [{
  path: '',
  component: HomeComponent,
  children: [
    {
      path: 'list',
      component: ListComponent
    },
    {
      path: 'add',
      component: AddComponent
    },
    {
      path: 'edit/:id',
      component: AddComponent
    },
    {
      path: 'search',
      component: SearchComponent
    },
    {
      path: ':id',
      component: CharacterComponent
    },
    {
      path: '**',
      redirectTo: 'list'
    }
  ]
}]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class CharacterRoutingModule { }
