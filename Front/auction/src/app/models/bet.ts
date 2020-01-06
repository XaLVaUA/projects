import { Lot } from './lot';

export class Bet {
    id: number;
    value: number;
    lotId: number;
    userName: string;
    date: Date;
    lot: Lot;
}
