import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MonsterDrop } from '../model/monsterdrop.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MonsterDropServiceService {
  public baseUrl = 'https://localhost:7275'

  constructor(private http: HttpClient) { }



  getAllDrops(): Observable<MonsterDrop[]> {
    return this.http.get<MonsterDrop[]>(this.baseUrl + '/api/MonsterDrop');
  }

  getDrop(name: string): Observable<MonsterDrop>{
    return this.http.get<MonsterDrop>(this.baseUrl+'/api/MonsterDrop/'+ name);
  }

  deleteDrop(name: string): Observable<MonsterDrop>{
    return this.http.delete<MonsterDrop>(this.baseUrl+'/api/MonsterDrop/'+ name);
  }

  addMonsterDrop(addDropRequest: MonsterDrop): Observable<MonsterDrop> {
    return this.http.post<MonsterDrop>(this.baseUrl + '/api/MonsterDrop', addDropRequest);
  }

  updateMonster(name: string, updateDrop: MonsterDrop): Observable <MonsterDrop> {
    return this.http.put<MonsterDrop>(this.baseUrl + '/api/MonsterDrop/' + name, updateDrop);
  }
}
