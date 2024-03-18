import { Component, Input } from '@angular/core';
import { Pet } from '../pets/models/pet';

@Component({
  selector: 'app-pet',
  templateUrl: './pet.component.html',
  styleUrl: './pet.component.css',
})
export class PetComponent {
  @Input() currentPet!: Pet;
}
