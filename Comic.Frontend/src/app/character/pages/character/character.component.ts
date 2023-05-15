import { Component, OnInit } from '@angular/core';
import { CharacterService } from '../../services/character-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { delay, switchMap } from 'rxjs';
import { ICharacter } from '../../interfaces/character.interface';

@Component({
  selector: 'app-character',
  templateUrl: './character.component.html'
})
export class CharacterComponent implements OnInit {

  public character?: ICharacter;

  constructor(private _characterService: CharacterService,
    private _activateRoute: ActivatedRoute,
    private router: Router) {
  }

  ngOnInit(): void {
    this._activateRoute.params
      .pipe(
        switchMap(({ id }) => this._characterService.getCharacterById(id))
      )
      .subscribe(character => {
        if (!character) return this.router.navigate(['/character/list']);
        this.character = character;
        console.log(this.character);
        return;
      })
  }

  goBack(): void {
    this.router.navigateByUrl("character/list")
  }

}
