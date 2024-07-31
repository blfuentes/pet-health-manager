import { Component, Input } from '@angular/core';
import { WeightService } from '../weight-list/services/weight.service';
import { Weight } from '../weight-list/models/weight';
import { EventAnnotation } from '../event-list/models/eventAnnotation';
import { EventAnnotationService } from '../event-list/services/event.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrl: './details.component.scss',
})
export class DetailsComponent {
  currentWeights: Weight[] | undefined;
  currentEventAnnotations: EventAnnotation[] | undefined;

  constructor(
    private weightsService: WeightService,
    private eventAnnotationsService: EventAnnotationService
  ) {
    this.currentEventAnnotations = [];
  }

  ngOnInit(): void {
    this.weightsService.currentWeights.subscribe((weights) => {
      if (weights) {
        // Convert the date property to a Date object if it's not already
        weights.forEach((weight) => {
          if (!(weight.date instanceof Date)) {
            weight.date = new Date(weight.date);
          }
        });
      }
      let sortedWeights = weights?.sort(
        (a, b) => b.date.getTime() - a.date.getTime()
      );
      this.currentWeights = sortedWeights;
    });

    this.eventAnnotationsService.currentEventAnnotations.subscribe(
      (eventAnnotations) => {
        if (eventAnnotations) {
          // Convert the date property to a Date object if it's not already
          eventAnnotations.forEach((eventAnnotation) => {
            if (!(eventAnnotation.date instanceof Date)) {
              eventAnnotation.date = new Date(eventAnnotation.date);
            }
          });
        }
        let sortedEventAnnotations = eventAnnotations?.sort(
          (a, b) => b.date.getTime() - a.date.getTime()
        );
        this.currentEventAnnotations = sortedEventAnnotations;
      }
    );
  }
}
