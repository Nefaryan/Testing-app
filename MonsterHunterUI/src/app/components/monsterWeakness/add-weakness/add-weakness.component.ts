import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MonsterWeakness } from 'src/app/model/monsterweakness.model';
import { MonsterWeaknessService } from 'src/app/services/monster-weakness.service';

@Component({
  selector: 'app-add-weakness',
  templateUrl: './add-weakness.component.html',
  styleUrls: ['./add-weakness.component.css']
})
export class AddWeaknessComponent implements OnInit {
 
  addNewWeak: MonsterWeakness ={
    name:'',
    type:'',
    weaknessPerc:0
  }

  constructor(private weaknessService: MonsterWeaknessService,private router: Router){}

  ngOnInit(): void {
  }

  addWeak(){
    console.log(this.addNewWeak);
    this.weaknessService.addMonsterWek(this.addNewWeak)
    .subscribe((data)=>console.log(data))
    this.router.navigate(['mosnterWeakness'])
  }

}
