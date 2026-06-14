import { ComponentFixture, TestBed } from "@angular/core/testing";
import { HttpClientTestingModule } from "@angular/common/http/testing";
import { of } from "rxjs";
import { PetsComponent } from "./pets.component";
import { Component, Input, CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";
import { PetsService } from "./services/pets.service";
import { Pet } from "./models/pet";
import { petsCollection1 } from "./services/spec-helpers/pet-spec-helper";
import { By } from "@angular/platform-browser";

describe("PetsComponent", () => {
  let component: PetsComponent;
  let fixture: ComponentFixture<PetsComponent>;
  let petsService: PetsService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PetsComponent],
      providers: [PetsService],
      imports: [HttpClientTestingModule],
      schemas: [CUSTOM_ELEMENTS_SCHEMA]
    });

    fixture = TestBed.createComponent(PetsComponent);
    component = fixture.componentInstance;
    petsService = TestBed.inject(PetsService);
  });

  it("should create the component", () => {
    expect(component).toBeTruthy();
  });

  it("should render a list with one element", () => {
    const mockPets: Pet[] = petsCollection1;
    spyOn(petsService, "getPets").and.returnValue(of(mockPets));

    component.ngOnInit();
    fixture.detectChanges();

    // Check that an `app-pet` element is rendered for each pet
    const petElements = fixture.debugElement.queryAll(By.css("app-pet"));
    expect(petElements.length).toBe(mockPets.length);
  });
});
