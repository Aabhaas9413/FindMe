import { Component, ViewChild } from '@angular/core';
import { FormGroup , FormBuilder, Validators} from '@angular/forms';
import { ResultsComponent } from '../results/results.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  text = "";
  myForm: FormGroup;
  @ViewChild(ResultsComponent, { static: false })
  resultsComponent!: ResultsComponent;

  constructor(private fb: FormBuilder) {
    this.myForm = this.fb.group({
      keyword: ['', Validators.required]
    });
  }

  getSearchResults(){
    if (this.myForm.valid) {
      this.resultsComponent.getUserListByKeyword(this.myForm.value["keyword"])
    }
  }
}
