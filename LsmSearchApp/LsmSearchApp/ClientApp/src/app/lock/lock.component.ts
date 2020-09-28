import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-lock',
  templateUrl: './lock.component.html',
  styleUrls: ['./lock.component.css']
})
export class LockComponent implements OnInit {
  //data record of lock
  @Input() lock: any = {};
  constructor() { }

  ngOnInit() {
  }

}
