import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Monster } from 'src/app/model/monster.model';
import { MonsterService } from 'src/app/services/monster.service';

@Component({
  selector: 'app-monster-update',
  templateUrl: './monster-update.component.html',
  styleUrls: ['./monster-update.component.css']
})

export class MonsterUpdateComponent implements OnInit {

  monsterDetail: Monster = {
    id:'',
    type: '',
    name: '',
    description: '',
    drop: [],
    weakness: [],
    note: '',
    imageUrls: ''
  }
   
  constructor(private route: ActivatedRoute, private monsterService: MonsterService,
    private router: Router){}
  a:any

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (param)=>{
       const id = param.get('id');


       if(id){
        this.monsterService.getMonster(id).subscribe({
          next: (response) =>{
            this.monsterDetail = response;
            this.a = response.id;
            console.log(this.monsterDetail,'dsdasdasdasd')
          }
        })
       }
      }
    })
  }

  updateMonster(){
    if (this.monsterDetail.id !== undefined) {
      this.monsterService.updateMonster(this.monsterDetail.id, this.monsterDetail)
      .subscribe({
        next: (response)=>{
          this.router.navigate(['monster'])
          console.log(response);
        }
      })
    } else {
     console.error("ID del mostro non definito.");
    }
   
  }

  deleteMonstes(){
    if(this.monsterDetail.id !== undefined){
      this.monsterService.deleteMonster(this.monsterDetail.id)
     .subscribe({
      next: (response)=>{
        this.router.navigate(['monster'])
        console.log(response);
      }
    })
    }
    
  }

}
