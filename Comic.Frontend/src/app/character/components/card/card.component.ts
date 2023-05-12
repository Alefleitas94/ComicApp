import { Component, Input, OnInit } from '@angular/core';
import { ICharacter } from '../../interfaces/character.interface';

@Component({
  selector: 'app-character-card',
  templateUrl: './card.component.html'
})
export class CardComponent implements OnInit {
  @Input()
  public character!: ICharacter



  ngOnInit(): void {

    if (!this.character) throw new Error('Character property is required.');
  }


}
