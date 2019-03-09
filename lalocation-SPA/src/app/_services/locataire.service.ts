import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Locataire } from '../_models/locataire';

@Injectable({
  providedIn: 'root'
})
export class LocataireService {
  baseUrl = environment.apiUrl;
constructor(private http: HttpClient) {
}

  getLocataires(): Observable<Locataire[]> {
    return this.http.get<Locataire[]>(this.baseUrl + 'locataires');
  }

  getLocataire(id): Observable<Locataire> {
    return this.http.get<Locataire>(this.baseUrl + 'locataires/' + id);
  }
}
