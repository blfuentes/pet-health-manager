import { Weight } from "src/app/weight-list/models/weight";

export interface Pet {
  id: number;
  name: string;
  species: string;
  breed: string;
  birth: Date;
  death?: Date;
  adoption: Date;
  colors: string[];
  weights: Weight[];
}
