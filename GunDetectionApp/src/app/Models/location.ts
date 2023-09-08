import { Guid } from 'guid-typescript';

export class Location {
  id: Guid;
  idUser: Guid;
  name: string;


  SubLocations: SubLocation[];
}
export class SubLocation {
  id: Guid;
  idLocation: Guid; 
  name: string;
}
