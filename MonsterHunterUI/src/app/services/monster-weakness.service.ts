import { Injectable } from '@angular/core';
import { MonsterWeakness } from '../model/monsterweakness.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MonsterWeaknessService {

  public baseUrl = 'https://localhost:7275'

  constructor(private http: HttpClient) { }



  getAllWeak(): Observable<MonsterWeakness[]> {
    return this.http.get<MonsterWeakness[]>(this.baseUrl + '/api/MonsterWeakness');
  }

  getWeak(id:string): Observable<MonsterWeakness>{
    return this.http.get<MonsterWeakness>(this.baseUrl +'/api/MonsterWeakness/'+ id);
  }

  addMonsterWek(addMonsterRequest: MonsterWeakness): Observable<MonsterWeakness> {
    return this.http.post<MonsterWeakness>(this.baseUrl + '/api/MonsterWeakness', addMonsterRequest);
  }

  updateMonsterWeak(id:string, updateWeakness: MonsterWeakness): Observable<MonsterWeakness>{
    return this.http.put<MonsterWeakness>(this.baseUrl + '/api/MonsterWeakness/'+id,updateWeakness);
  }

  deletetWeak(id:string): Observable<MonsterWeakness>{
    return this.http.delete<MonsterWeakness>(this.baseUrl +'/api/MonsterWeakness/'+ id);
  }

}
