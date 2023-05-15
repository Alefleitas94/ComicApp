import { Component, OnInit } from '@angular/core';
import { CharacterService } from '../../services/character-service.service';
import { ICharacter } from '../../interfaces/character.interface';
import { ICharacterFilter } from '../../interfaces/character-filter.interface';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html'
})
export class ListComponent implements OnInit {

  characters: ICharacter[] = [];
  constructor(private _characterService: CharacterService) {

  }
  ngOnInit(): void {
    this._characterService.getCharacters()
      .subscribe((res: ICharacter[]) => {
        this.characters = res;
        console.log(this.characters);
      });

  }

}
