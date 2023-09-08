import { Guid } from 'guid-typescript';

export class UserAlarm {
  id: Guid;
  idAccount: Guid;
  name: string;
  lastName: string;
  email: string;
  phone: string;
  figth: boolean;
  gunDetected: boolean;
  personDetection: boolean;
  handsUp: boolean;
}
