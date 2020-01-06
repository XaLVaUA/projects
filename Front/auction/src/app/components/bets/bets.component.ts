import { Component, OnInit, Input } from '@angular/core';
import { Bet } from 'src/app/models/bet';

@Component({
  selector: 'app-bets',
  templateUrl: './bets.component.html',
  styleUrls: ['./bets.component.css']
})
export class BetsComponent implements OnInit {

  @Input() bets: Array<Bet>;

  constructor() { }

  ngOnInit() {
  }

}
