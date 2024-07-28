import { Pet } from "../../models/pet";

export const pet1: Pet = {
  id: 1,
  name: "Pet1",
  breed: "Breed1",
  species: "Species1",
  colors: ["Colors1", "Colors2"],
  adoption: new Date(),
  birth: new Date(),
  death: undefined,
  imgContent: "",
  weights: []
}


export const petsCollection1: Pet[] = [pet1];
