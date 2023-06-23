import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { MonsterWeakness } from 'src/app/model/monsterweakness.model';
import { MonsterWeaknessService } from 'src/app/services/monster-weakness.service';

@Component({
  selector: 'app-edit-weakness',
  templateUrl: './edit-weakness.component.html',
  styleUrls: ['./edit-weakness.component.css']
})
export class EditWeaknessComponent implements OnInit {
 
  weaknessDetail: MonsterWeakness ={
    id:'',
    name:'',
    type:'',
    weaknessPerc:0 
   }

   constructor(private route: ActivatedRoute,
     private weaknessService: MonsterWeaknessService,
     private router: Router){}
     a:any

   ngOnInit(): void {
    this.route.paramMap.subscribe({
      next:(param)=>{
        const id = param.get('id');

        if(id){
          this.weaknessService.getWeak(id).subscribe({
            next:(response) =>{
              this.weaknessDetail = response;
              this.a = response.id;
              console.log(this.weaknessDetail,'ciao compare')
            }
          })
        }
      }
    })
  }

  updateMonsterWeakness(){
    if(this.weaknessDetail.id !== undefined){
      this.weaknessService.updateMonsterWeak(this.weaknessDetail.id,this.weaknessDetail)
      .subscribe({
        next:(response)=>{
          this.router.navigate(['mosnterWeakness'])
          console.log(response);
        }
      })
    }else{
      console.error('Id non trovato')
    }
  }

  daleteMonsterWeak(){
    if(this.weaknessDetail.id !== undefined){
      this.weaknessService.deletetWeak(this.weaknessDetail.id)
      .subscribe({
        next: (response)=>{
          this.router.navigate(['mosnterWeakness'])
          console.log(response);
        }
      })
    }
  }


}
