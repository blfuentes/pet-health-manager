import { TestBed } from "@angular/core/testing";
import { PetsService } from "./pets.service";
import { HttpClientTestingModule, HttpTestingController } from "@angular/common/http/testing";
import { apiConfig } from "../../../api.config";
import { Pet } from "../models/pet";
import { petsCollection1 } from "./spec-helpers/pet-spec-helper";

const petsUrl = `${apiConfig.baseUrl}:${apiConfig.port}/api/pets`;

describe("PetsService", () => {
  let petsService: PetsService;
  let controller: HttpTestingController;


  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [PetsService],
    });
    petsService = TestBed.inject(PetsService);
    controller = TestBed.inject(HttpTestingController);
  });

  it("should be created", () => {
    expect(petsService).toBeTruthy();
  });

  it("should load pets", () => {
    let actualPets: Pet[] | undefined;
    petsService.getPets().subscribe(
      (pets) => {
        actualPets = pets;
      }
    );
    const request = controller.expectOne(petsUrl);
    request.flush(petsCollection1);
    controller.verify();

    expect(actualPets).toEqual(petsCollection1);
  });
});
