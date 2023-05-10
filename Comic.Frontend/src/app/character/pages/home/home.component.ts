import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent {
  public sidebarItems = [
    { label: 'List', icon: 'label', url: './list' },
    { label: 'Add', icon: 'add', url: './add' },
    { label: 'Search', icon: 'search', url: './search' },
  ]
}
