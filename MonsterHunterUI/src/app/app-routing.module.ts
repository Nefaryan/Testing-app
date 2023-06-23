import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MonsterListComponent } from './components/monsters/monster-list/monster-list.component';
import { AddMonsterComponent } from './components/monsters/add-monster/add-monster.component';
import { MonsterUpdateComponent } from './components/monsters/monster-update/monster-update.component';
import { DropListComponent } from './components/monsterDrop/drop-list/drop-list.component';
import { AddDropComponent } from './components/monsterDrop/add-drop/add-drop.component';
import { AddWeaknessComponent } from './components/monsterWeakness/add-weakness/add-weakness.component';
import { WeaknessListComponent } from './components/monsterWeakness/weakness-list/weakness-list.component';
import { EditDropComponent } from './components/monsterDrop/edit-drop/edit-drop.component';
import { EditWeaknessComponent } from './components/monsterWeakness/edit-weakness/edit-weakness.component';

const routes: Routes = [{
  path:'monster',
  component: MonsterListComponent
},
{
  path:'monster/add',
  component: AddMonsterComponent
},
{
  path:'monster/edit/:id',
  component: MonsterUpdateComponent
},
{
  path:'monsterDrop',
  component: DropListComponent
},
{
  path:'drop/add',
  component: AddDropComponent
},
{
  path:'drop/edit/:name',
  component: EditDropComponent
},
{
  path:'weak/add',
  component: AddWeaknessComponent
},
{
  path:'mosnterWeakness',
  component:WeaknessListComponent
},
{
  path:'weak/edit/:id',
  component: EditWeaknessComponent
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
