import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, of } from 'rxjs';
import { ICharacter } from '../interfaces/character.interface';
import { environments } from 'src/environments/environments';

@Injectable({ providedIn: 'root' })
export class CharacterService {

  private baseApiUrl = environments.baseApiUrl;

  constructor(private httpClient: HttpClient) { }

  getCharacters(): Observable<ICharacter[]> {
    return this.httpClient.get<ICharacter[]>(`${this.baseApiUrl}/api/comic/getAll`);
  }
  getCharacterById(id: string): Observable<ICharacter | undefined> {

    return this.httpClient.get<ICharacter>(`${this.baseApiUrl}/api/comic/getById?id=${id}`)
      .pipe(
        catchError(
          error => of(undefined)
        )
      )
  }

  saveOrEditCharacter(character: ICharacter): Observable<any> {
    return this.httpClient.post<any>(`${this.baseApiUrl}/api/comic/saveCharacter`, character)
      .pipe(
        catchError(
          error => of(undefined)
        )
      )
  }


}