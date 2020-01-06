import { Component, OnInit } from '@angular/core';
import { LotService } from '../../services/lot.service/lot.service';
import { Lot } from 'src/app/models/lot';
import { UserService } from '../../services/user.service/user.service';

@Component({
  selector: 'app-lots',
  templateUrl: './lots.component.html',
  styleUrls: ['./lots.component.css']
})
export class LotsComponent implements OnInit {

  message: string;
  lots: Array<Lot>;

  constructor(
    private lotService: LotService,
    private userService: UserService
  ) { }

  ngOnInit() {
    this.message = '';
    this.getLots();
  }

  getLots(): void {
    this.lotService.getLots().subscribe(lots => this.lots = lots);
  }

  onCreateLot(name: string, description: string, startValue: number) {
    const lot = new Lot();
    lot.name = name;
    lot.description = description;
    lot.currentBet = startValue;
    this.lotService.createLot(lot, this.userService.getToken()).subscribe(() => this.getLots(), err => this.message = 'Error');
  }

  onDeleteLot(id: number): void {
    this.lotService.deleteLot(id, this.userService.getToken()).subscribe(() => this.getLots(), err => this.message = 'Error');
  }

}
