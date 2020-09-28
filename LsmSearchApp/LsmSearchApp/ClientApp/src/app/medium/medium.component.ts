import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-medium',
  templateUrl: './medium.component.html',
  styleUrls: ['./medium.component.css']
})
export class MediumComponent implements OnInit {

  //data record of medium
  @Input() medium: any = {};
  constructor() { }

  ngOnInit() {
  }

}
