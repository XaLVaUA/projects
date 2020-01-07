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

  pageNumber: number;
  pageElementCount: number;
  message: string;
  lots: Array<Lot>;
  lotsToShow: Array<Lot>;

  constructor(
    private lotService: LotService,
    private userService: UserService
  ) { }

  ngOnInit() {
    this.pageNumber = 1;
    this.pageElementCount = 10;
    this.message = '';
    this.getLots();
  }

  getLots(): void {
    this.lotService.getLots(this.pageNumber, this.pageElementCount).subscribe(lots => { this.lots = lots; this.lotsToShow = this.lots; });
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

  onNextPage(): void {
    if (this.lots.length < this.pageElementCount) {
      return;
    }

    this.pageNumber++;
    this.getLots();
  }

  onPrevPage(): void {
    if (this.pageNumber < 2) {
      return;
    }

    this.pageNumber--;
    this.getLots();
  }

  onSearch(word: string): void {
    word = word.toLowerCase();
    this.lotsToShow = this.lots.filter(l => l.name.toLowerCase().match(`${word}`));
  }

}
