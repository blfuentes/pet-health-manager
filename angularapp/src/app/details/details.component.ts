import { Component, Input } from '@angular/core';
import { Pet } from '../pets/models/pet';
import { PetsService } from '../pets/services/pets.service';
import { WeightService } from '../weight-list/services/weight.service';
import { Weight } from '../weight-list/models/weight';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrl: './details.component.scss'
})
export class DetailsComponent {
  currentWeights: Weight[] | undefined;

  constructor(private weightsService: WeightService) { }


  ngOnInit(): void {
    this.weightsService.currentWeights.subscribe((weights) => this.currentWeights = weights);
  }
}
