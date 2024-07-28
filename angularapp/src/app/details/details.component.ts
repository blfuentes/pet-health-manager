import { Component, Input } from '@angular/core';
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
    this.weightsService.currentWeights.subscribe((weights) => {
      if (weights) {
        // Convert the date property to a Date object if it's not already
        weights.forEach(weight => {
          if (!(weight.date instanceof Date)) {
            weight.date = new Date(weight.date);
          }
        });
      }
      let sortedWeights =  weights?.sort((a, b) => b.date.getTime() - a.date.getTime());
      this.currentWeights = sortedWeights;
    });
  }
}
