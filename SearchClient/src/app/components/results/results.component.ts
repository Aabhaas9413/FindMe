import { Component, Input} from '@angular/core';
import { SearchService } from 'src/app/services/search.service';

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.css']
})
export class ResultsComponent {
  text  = "";
  userList : any = [];
  totalCount : number = 0;
  resultFound : boolean = false;

  constructor(private searchService : SearchService) {
     
  }

  getUserListByKeyword(keyword : string){
   this.searchService.getSearchedUserList(keyword).subscribe((userRes:any[]) => {
    this.text = keyword;
    if(userRes.length > 0){      
      this.userList = userRes;
      this.totalCount = userRes.length
      this.resultFound = true
    }else{
      this.resultFound = false;
      this.userList = [];
    }    
   });
  }
}
