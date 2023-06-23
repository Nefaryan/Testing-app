import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MonsterDrop } from 'src/app/model/monsterdrop.model';
import { MonsterDropServiceService } from 'src/app/services/monster-drop-service.service';

@Component({
  selector: 'app-edit-drop',
  templateUrl: './edit-drop.component.html',
  styleUrls: ['./edit-drop.component.css']
})
export class EditDropComponent implements OnInit {

  dropDetail: MonsterDrop={
    id:'',
    name:'',
    description:'',
    dropRate:0
  }

  constructor(private route: ActivatedRoute, private dropService:MonsterDropServiceService,
    private router: Router ){
    
  }
  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next:(param)=>{
        const name = param.get('name');
        console.log('andrea puzza',param)

        if(name){
          this.dropService.getDrop(name).subscribe({
            next:(response)=>{
              this.dropDetail = response;
              console.log(this.dropDetail,'Ciao sono qui')
            }
          })
        }
      }
    })
  }

  updateDrop(){
    if(this.dropDetail.name !== null){
      this.dropService.updateMonster(this.dropDetail.name,this.dropDetail)
      .subscribe({
        next:(response)=>{
          console.log(response)
          this.router.navigate(['monsterDrop']) 
        }
      })
    }else{
      console.error("Nome non esistente")
    }
  }

  deleteDrop(){
    if(this.dropDetail.name !== null){
      this.dropService.deleteDrop(this.dropDetail.name)
      .subscribe({
        next:(response)=>{
          console.log(response)
          this.router.navigate(['monsterDrop'])
        }
      })
    }
  }

}
