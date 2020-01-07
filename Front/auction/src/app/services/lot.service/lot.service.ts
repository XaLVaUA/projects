import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Lot } from 'src/app/models/lot';
import { Token } from '../../models/token';

@Injectable({
  providedIn: 'root'
})
export class LotService {

  lotsApiUri = 'https://localhost:44375/api/lots';

  constructor(
    private http: HttpClient
  ) { }

  getLots(pageNumber: number, pageElementCount: number): Observable<Array<Lot>> {
    const url = this.lotsApiUri;
    const params = new HttpParams()
      .set('pageNumber', pageNumber.toString())
      .set('pageElementCount', pageElementCount.toString());
    return this.http.get<Array<Lot>>(url, { params });
  }

  getLotById(id: number): Observable<Lot> {
    const url = `${this.lotsApiUri}/${id}`;
    return this.http.get<Lot>(url);
  }

  createLot(lot: Lot, token: Token): Observable<Lot> {
    const url = this.lotsApiUri;
    lot.userName = token.userName;
    const headers = new HttpHeaders({ Authorization: token.token });
    return this.http.post<Lot>(url, lot, { headers });
  }

  updateLot(id: number, lot: Lot, token: Token): Observable<Lot> {
    const url = `${this.lotsApiUri}/${id}`;
    const headers = new HttpHeaders({ Authorization: token.token });
    return this.http.put<Lot>(url, lot, { headers });
  }

  deleteLot(id: number, token: Token): Observable<Lot> {
    const url = `${this.lotsApiUri}/${id}`;
    const headers = new HttpHeaders({ Authorization: token.token });
    return this.http.delete<Lot>(url, { headers });
  }
}
