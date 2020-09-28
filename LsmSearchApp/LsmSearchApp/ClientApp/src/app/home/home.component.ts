import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  title = 'SimonsVossLsmSearch-WebPortal';
  searchText: string = "";
  searchResults: any = null;

  constructor () {}

  loadSearchResult() {
    debugger;
  }
}

