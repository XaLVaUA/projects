import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Lot } from 'src/app/models/lot';
import { LotService } from 'src/app/services/lot.service/lot.service';
import { UserService } from '../../services/user.service/user.service';
import { BetService } from 'src/app/services/bet.service/bet.service';
import { Bet } from 'src/app/models/bet';

@Component({
  selector: 'app-lot',
  templateUrl: './lot.component.html',
  styleUrls: ['./lot.component.css']
})
export class LotComponent implements OnInit {

  message: string;
  lot: Lot;

  constructor(
    private route: ActivatedRoute,
    private lotService: LotService,
    private userService: UserService,
    private betService: BetService
  ) { }

  ngOnInit() {
    this.message = '';
    this.getLot();
  }

  getLot(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.lotService.getLotById(id).subscribe(lot => this.lot = lot);
  }

  onMakeBet(value: number): void {
    if (value < this.lot.currentBet) {
      this.message = 'Value must be higher than current';
      return;
    }

    const bet = new Bet();
    bet.value = value;
    bet.lotId = this.lot.id;
    this.betService.createBet(bet, this.userService.getToken()).subscribe(() => this.getLot(), err => this.message = 'Error');
  }

}
