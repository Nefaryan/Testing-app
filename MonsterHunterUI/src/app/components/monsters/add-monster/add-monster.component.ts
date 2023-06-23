import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Monster } from 'src/app/model/monster.model';
import { MonsterService } from 'src/app/services/monster.service';



@Component({
  selector: 'app-add-monster',
  templateUrl: './add-monster.component.html',
  styleUrls: ['./add-monster.component.css']
})
export class AddMonsterComponent implements OnInit {

  addMonsterRequest: Monster = {
    type: '',
    name: '',
    description: '',
    drop: [],
    weakness: [],
    note: '',
    imageUrls: ''
  }
  constructor(private monsterService: MonsterService,  private router: Router){}

  ngOnInit(): void {
  }

  addMonster() {
    console.log(this.addMonsterRequest);
    this.monsterService.addMonster(this.addMonsterRequest)
    .subscribe((data)=>console.log(data))
    this.router.navigate(['monster'])
  }
  

}
