import { Bet } from './bet';

export class Lot {
    id: number;
    name: string;
    description: string;
    currentBet: number;
    userName: string;
    date: Date;
    bets: Array<Bet>;
}
