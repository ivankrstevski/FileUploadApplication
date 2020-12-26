import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-no-result-box',
  templateUrl: './no-result-box.component.html',
  styleUrls: ['./no-result-box.component.css']
})
export class NoResultBoxComponent implements OnInit {

  constructor() { }

  @Input() public text: string;
  @Input() public icon: string;

  ngOnInit(): void {
  }

}
