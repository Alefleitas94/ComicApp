import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ICharacter } from '../interfaces/character.interface';
import { ICharacterFilter } from '../interfaces/character-filter.interface';
import { environments } from 'src/environments/environments';

@Injectable({ providedIn: 'root' })
export class CharacterService {

  private baseApiUrl = environments.baseApiUrl;

  constructor(private httpClient: HttpClient) { }

  getCharacters(filter: ICharacterFilter): Observable<ICharacter[]> {
    const queryParams = {
      textToSearch: filter.textToSearch || '',
      columnToSearch: filter.columnToSearch || '',
      pageIndex: filter.pageIndex || 1,
      pageSize: filter.pageSize || 10
    };
    const params = new HttpParams({ fromObject: queryParams });

    return this.httpClient.get<ICharacter[]>(`${this.baseApiUrl}/api/comic/getAll`, { params });
  }
}