import { Component, Input } from '@angular/core';
import { Pet } from '../pets/models/pet';
import { WeightService } from '../weight-list/services/weight.service';
import { PetsService } from '../pets/services/pets.service';

@Component({
  selector: 'app-pet',
  templateUrl: './pet.component.html',
  styleUrl: './pet.component.scss',
})
export class PetComponent {
  @Input() currentPet!: Pet;

  constructor(public petsService: PetsService, public weightService: WeightService) {}

  loadWeights(petid: number) {
    this.petsService
      .loadPet(petid, true)
      .subscribe((pet) => this.currentPet = pet);

    //this.weightService
    //  .loadWeights(petid)
    //  .subscribe((weights) => (this.currentPet.weights = weights));
  }
}
