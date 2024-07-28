import { Component, Input } from '@angular/core';
import { Pet } from '../pets/models/pet';
import { WeightService } from '../weight-list/services/weight.service';

@Component({
  selector: 'app-pet',
  templateUrl: './pet.component.html',
  styleUrl: './pet.component.scss',
})
export class PetComponent {
  @Input() currentPet!: Pet;

  constructor(public weightService: WeightService) {}

  loadWeights(id: number) {
    this.weightService
      .loadWeights(id)
      .subscribe((weights) => this.currentPet.weights = weights);
  }
}
