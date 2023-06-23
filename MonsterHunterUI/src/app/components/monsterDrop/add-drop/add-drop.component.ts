import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { MonsterDrop } from 'src/app/model/monsterdrop.model';
import { MonsterDropServiceService } from 'src/app/services/monster-drop-service.service';



@Component({
  selector: 'app-add-drop',
  templateUrl: './add-drop.component.html',
  styleUrls: ['./add-drop.component.css']
})
export class AddDropComponent implements OnInit {
 addDrops: MonsterDrop = {
  name:'',
  description:'',
  dropRate: 0
 }

 constructor(private dropService: MonsterDropServiceService,private router: Router  ){}

  ngOnInit(): void {
  }

  addDrop(){
    console.log(this.addDrops);
    this.dropService.addMonsterDrop(this.addDrops)
    .subscribe((data)=>console.log(data))
    this.router.navigate(['monsterDrop']) 
  }

}
