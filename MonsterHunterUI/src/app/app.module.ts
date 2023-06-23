import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MonsterListComponent } from './components/monsters/monster-list/monster-list.component';
import { HttpClientModule } from '@angular/common/http';
import { AddMonsterComponent } from './components/monsters/add-monster/add-monster.component';
import { FormsModule } from '@angular/forms';
import { MonsterUpdateComponent } from './components/monsters/monster-update/monster-update.component';
import { RouterLink } from "@angular/router";
import { DropListComponent } from './components/monsterDrop/drop-list/drop-list.component';
import { AddDropComponent } from './components/monsterDrop/add-drop/add-drop.component';
import { WeaknessListComponent } from './components/monsterWeakness/weakness-list/weakness-list.component';
import { AddWeaknessComponent } from './components/monsterWeakness/add-weakness/add-weakness.component';
import { EditDropComponent } from './components/monsterDrop/edit-drop/edit-drop.component';
import { EditWeaknessComponent } from './components/monsterWeakness/edit-weakness/edit-weakness.component';


@NgModule({
    declarations: [
        AppComponent,
        MonsterListComponent,
        AddMonsterComponent,
        MonsterUpdateComponent,
        DropListComponent,
        AddDropComponent,
        WeaknessListComponent,
        AddWeaknessComponent,
        EditDropComponent,
        EditWeaknessComponent
    ],
    providers: [],
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        FormsModule,
        RouterLink
    ]
})
export class AppModule { }
