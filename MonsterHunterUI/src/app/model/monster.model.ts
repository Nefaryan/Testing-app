import { MonsterDrop } from "./monsterdrop.model";
import { MonsterWeakness } from "./monsterweakness.model";

export interface Monster {
    id?:string
    name: string;
    type: string;
    description: string;
    imageUrls: string;
    weakness?: MonsterWeakness[];
    drop?: MonsterDrop[];
    note: string;
    
}