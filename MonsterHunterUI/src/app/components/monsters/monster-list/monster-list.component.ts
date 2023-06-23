import { Component, OnInit } from '@angular/core';
import { Monster } from 'src/app/model/monster.model';
import { MonsterService } from 'src/app/services/monster.service';

@Component({
  selector: 'app-monster-list',
  templateUrl: './monster-list.component.html',
  styleUrls: ['./monster-list.component.css']
})

export class MonsterListComponent implements OnInit {

  monsters: Monster[]= []
 
  constructor(private monsterService: MonsterService){}

  ngOnInit(): void {
    this.monsterService.getAllMonster()
    .subscribe((data)=>{
      this.monsters=data
      console.log(data,'GET')
      
    })
  
  }
     
}
