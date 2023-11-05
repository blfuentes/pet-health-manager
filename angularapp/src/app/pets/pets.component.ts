import { Component } from '@angular/core';

import { PetsService } from './services/pets.service';
import { Pet } from './models/pet';


@Component({
  selector: 'app-pets',
  templateUrl: './pets.component.html',
  styleUrls: ['./pets.component.css']
})
export class PetsComponent {
  constructor(private petService: PetsService) { }

  pets: Pet[] = [];

  ngOnInit(): void {
    this.getPets();
  }

  getPets() {
    this.petService.getPets().subscribe(pets => this.pets = pets);
  }
}
