export interface ICharacter {
    id?: number;
    name: string;
    gender: Gender;
    publisher: Publisher;
    firstAppearance: string;
    createdAt: Date;
    image: string;
}

export enum Gender {
    Female = "Female",
    Male = "Male",
}

export enum Publisher {
    DCComics = "DC Comics",
    MarvelComics = "Marvel Comics",
}
