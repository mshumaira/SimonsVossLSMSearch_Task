import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-medium',
  templateUrl: './medium.component.html',
  styleUrls: ['./medium.component.css']
})
export class MediumComponent implements OnInit {

  @Input() medium: any = {};
  constructor() { }

  ngOnInit() {
  }

}
