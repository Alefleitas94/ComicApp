import { Component, OnInit } from '@angular/core';
import { Gender, ICharacter, Publisher } from '../../interfaces/character.interface';
import { CharacterService } from '../../services/character-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { switchMap } from 'rxjs';
import { FormControl, FormGroup } from '@angular/forms';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';
import { GenericResult } from '../../interfaces/generic-result.interface';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html'
})

export class AddComponent implements OnInit {

  successConfig: MatSnackBarConfig = {
    panelClass: ['green-snackbar'],
    duration: 5000,
    verticalPosition: 'top',

  };
  public character?: ICharacter;
  public heroForm = new FormGroup({
    id: new FormControl<number | undefined>(undefined),
    name: new FormControl('', { nonNullable: true }),
    gender: new FormControl<Gender>(Gender.Male),
    publisher: new FormControl<Publisher>(Publisher.DCComics),
    firstAppearance: new FormControl(''),
    createdAt: new FormControl<Date>(new Date(), { nonNullable: false }),
    image: new FormControl('', { nonNullable: false })
  });


  public publishers = [
    { id: 'DC Comics', desc: 'DC - Comics' },
    { id: 'Marvel Comics', desc: 'Marvel - Comics' },
  ];

  constructor(
    private _characterService: CharacterService,
    private _activateRoute: ActivatedRoute,
    private _router: Router,
    private _snackBar: MatSnackBar
  ) {

  }

  get currentHero(): ICharacter {
    const hero = this.heroForm.value as ICharacter;
    return hero;
  }

  ngOnInit(): void {

    if (!this._router.url.includes('edit')) return;

    this._activateRoute.params
      .pipe(
        switchMap(({ id }) => this._characterService.getCharacterById(id))
      ).
      subscribe(hero => {
        if (!hero) return this._router.navigateByUrl('/');
        this.heroForm.reset(hero);
        return;
      });
  }


  onSubmit(): void {

    if (this.heroForm.invalid) return;
    debugger;
    this._characterService.saveOrEditCharacter(this.currentHero)
      .subscribe((result: GenericResult) => {
        this._router.navigate(['/character/edit', result.id])
        this.showSnackBar(result.message, this.successConfig);

      });
  }


  showSnackBar(message: string, config: MatSnackBarConfig): void {
    this._snackBar.open(message, 'Ok', config)

  }


}
