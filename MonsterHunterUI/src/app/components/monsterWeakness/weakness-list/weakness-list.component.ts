import { Component, OnInit } from '@angular/core';
import { MonsterWeakness } from 'src/app/model/monsterweakness.model';
import { MonsterWeaknessService } from 'src/app/services/monster-weakness.service';

@Component({
  selector: 'app-weakness-list',
  templateUrl: './weakness-list.component.html',
  styleUrls: ['./weakness-list.component.css']
})
export class WeaknessListComponent implements OnInit {
  weaks: MonsterWeakness[]=[]
  constructor(private weaknessService:MonsterWeaknessService){}

  ngOnInit(): void {
      this.weaknessService.getAllWeak()
      .subscribe((data=>{
        this.weaks = data
        console.log(data,'GET')
      }))
  }

}
