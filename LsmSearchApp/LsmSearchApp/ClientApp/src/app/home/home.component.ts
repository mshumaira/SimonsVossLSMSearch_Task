import { Component } from '@angular/core';
import { SearchTextService } from '../services/SearchText/search-text.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  title = 'Simons-Voss LSM Search - WebPortal';
  // variable to store search text
  searchText: string = "";
  //variable to store searchResults
  searchResults: any = null;

  //searchservice injected
  constructor (private searchTextService: SearchTextService) {}

  loadSearchResult() {
    // extract the search results
    this.searchTextService.getSearchResult(this.searchText).then(searchResults => {
      this.searchResults = searchResults;
    }, error => window.alert(`Error: ${error}`));  
  }

  // Refresh- remove existing searchData
  RefreshSearchResult(){
    this.searchText="";
    this.searchResults = null;

  }

}

