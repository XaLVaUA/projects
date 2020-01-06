import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Bet } from 'src/app/models/bet';
import { Token } from '../../models/token';

@Injectable({
  providedIn: 'root'
})
export class BetService {

  betsApiUri = 'https://localhost:44375/api/bets';

  constructor(
    private http: HttpClient
  ) { }

  getBets(): Observable<Array<Bet>> {
    const url = this.betsApiUri;
    return this.http.get<Array<Bet>>(url);
  }

  getBetsByLotId(lotId: number): Observable<Array<Bet>> {
    const url = this.betsApiUri;
    const params = new HttpParams().set('lotId', lotId.toString());
    return this.http.get<Array<Bet>>(url, { params });
  }

  getBetById(id: number): Observable<Bet> {
    const url = `${this.betsApiUri}/${id}`;
    return this.http.get<Bet>(url);
  }

  createBet(bet: Bet, token: Token): Observable<Bet> {
    const url = this.betsApiUri;
    bet.userName = token.userName;
    const headers = new HttpHeaders({ Authorization: token.token });
    return this.http.post<Bet>(url, bet, { headers });
  }

  updateBet(id: number, bet: Bet, token: Token): Observable<Bet> {
    const url = `${this.betsApiUri}/${id}`;
    const headers = new HttpHeaders({ Authorization: token.token });
    return this.http.put<Bet>(url, bet, { headers });
  }

  deleteBet(id: number, token: Token): Observable<Bet> {
    const url = `${this.betsApiUri}/${id}`;
    const headers = new HttpHeaders({ Authorization: token.token });
    return this.http.delete<Bet>(url, { headers });
  }
}
