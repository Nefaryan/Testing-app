import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Monster } from '../model/monster.model';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class MonsterService {
  public baseUrl = 'https://localhost:7275'

  constructor(private http: HttpClient) { }

  getAllMonster(): Observable<Monster[]> {
    return this.http.get<Monster[]>(this.baseUrl + '/api/Monster');
  }

  addMonster(addMonsterRequest: Monster): Observable<Monster> {
    return this.http.post<Monster>(this.baseUrl + '/api/Monster', addMonsterRequest)
  }

  getMonster(id: string): Observable<Monster> {
    return this.http.get<Monster>(this.baseUrl + '/route/' + id)
  }

  updateMonster(id: string, updateMonsterRequest: Monster): Observable<Monster> {
    return this.http.put<Monster>(this.baseUrl + '/api/Monster/' + id, updateMonsterRequest);
  }
  
  deleteMonster(id:string): Observable<Monster>{
    return this.http.delete<Monster>(this.baseUrl + '/api/Monster/' + id)
  }

}
