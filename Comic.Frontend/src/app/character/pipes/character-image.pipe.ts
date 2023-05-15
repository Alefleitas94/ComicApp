import { Pipe, PipeTransform } from '@angular/core';
import { ICharacter } from '../interfaces/character.interface';

@Pipe({
  name: 'characterImage'
})
export class CharacterImagePipe implements PipeTransform {

  transform(character: ICharacter): string {
    if (!character.id && !character.name) {
      return 'hola';
    }
    return 'outside of if';
  }
}
