import { Component } from '@angular/core';
import { SearchTextService } from '../services/SearchText/search-text.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  title = 'Simons-Voss LSM Search - WebPortal';
  searchText: string = "";
  searchResults: any = null;

  //searchservice injected
  constructor (private searchTextService: SearchTextService) {}

  loadSearchResult() {
    // extract the search results
    this.searchTextService.getSearchResult(this.searchText).then(searchResults => {
      this.searchResults = searchResults;
    }, error => window.alert(`Error: ${error}`));  
  }

}

