import { Component } from '@angular/core';
import { SearchTextService } from '../services/SearchText/search-text.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  title = 'SimonsVossLsmSearch-WebPortal';
  searchText: string = "";
  searchResults: any = null;

  constructor (private searchTextService: SearchTextService) {}

  loadSearchResult() {
    debugger;
    this.searchTextService.getSearchResult(this.searchText).then(searchResults => {
      debugger;
      this.searchResults = searchResults;
    }, error => window.alert(`Error: ${error}`));  
  }

}

