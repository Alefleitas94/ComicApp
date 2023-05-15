import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ICharacter } from '../../interfaces/character.interface';
import { Observable, map, startWith } from 'rxjs';
import { CharacterService } from '../../services/character-service.service';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html'
})
export class SearchComponent {

  public searchInput = new FormControl('');

  public characters: ICharacter[] = [];

  public selectedCharacter?: ICharacter;

  options: ICharacter[] = [];
  filteredOptions: ICharacter[] = [];

  constructor(private _characterService: CharacterService) {

  }

  ngOnInit() {
    this._characterService.getCharacters()
      .subscribe((res: ICharacter[]) => {
        this.options = res;
        this.characters = res;
      })
  }


  searchHero() {
    const value: string = this.searchInput.value || '';
    console.log(value);
    if (value.trim() === '') {
      // Si no se ingresa ninguna palabra, mostrar todos los personajes
      this.characters = this.options;
    } else {
      const regex = new RegExp(value, 'i'); // 'i' para que sea insensible a mayúsculas y minúsculas
      this.characters = this.characters.filter((character) => regex.test(character.name));
    }
    console.log(this.characters);
  }


  onSelectedOption(event: MatAutocompleteSelectedEvent) {
    const { value: character } = event.option
    console.log(character);

    if (!character) {
      this.selectedCharacter = undefined
    }

    const char: ICharacter = character;

    this.searchInput.setValue(char.name);

  }
}
