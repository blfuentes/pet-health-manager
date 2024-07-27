import { Component, Input } from '@angular/core';
import { Pet } from '../pets/models/pet';
import { PetsService } from '../pets/services/pets.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrl: './details.component.scss'
})
export class DetailsComponent {
  currentPet: Pet | undefined;

  constructor(private petsService: PetsService) { }


  ngOnInit(): void {
    this.petsService.currentPet.subscribe(pet => this.currentPet = pet);
  }
}
