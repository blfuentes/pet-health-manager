import { Component, Input } from '@angular/core';
import { Pet } from '../pets/models/pet';
import { WeightService } from '../weight-list/services/weight.service';
import { EventAnnotationService } from '../event-list/services/event.service';

@Component({
  selector: 'app-pet',
  templateUrl: './pet.component.html',
  styleUrl: './pet.component.scss',
})
export class PetComponent {
  @Input() currentPet!: Pet;

  constructor(public weightService: WeightService, public eventAnnotationsService: EventAnnotationService) {}

  loadInfo(id: number) {
    this.weightService
      .loadWeights(id)
      .subscribe((weights) => (this.currentPet.weights = weights));

    this.eventAnnotationsService
      .loadEventAnnotations(id)
      .subscribe((eventAnnotations) =>  (this.currentPet.eventAnnotations = eventAnnotations))
  }
}
