import { Role } from "./role";
import { State } from "./state";

export class User {
  id: number;
  name: string;
  roleId: number;
  role: Role;
  stateId: number;
  state: State;
  address: string;
}
