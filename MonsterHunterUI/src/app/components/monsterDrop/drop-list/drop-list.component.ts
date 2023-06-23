import { Component, OnInit } from '@angular/core';
import { MonsterDrop } from 'src/app/model/monsterdrop.model';
import { MonsterDropServiceService } from 'src/app/services/monster-drop-service.service';

@Component({
  selector: 'app-drop-list',
  templateUrl: './drop-list.component.html',
  styleUrls: ['./drop-list.component.css']
})
export class DropListComponent implements OnInit {
 
 drops: MonsterDrop[] = []

 constructor(private monsterDropService: MonsterDropServiceService){}

 ngOnInit(): void {
  this.monsterDropService.getAllDrops()
  .subscribe((data =>{
    this.drops = data
    console.log(data,'GET')
  }))
  
}
}
