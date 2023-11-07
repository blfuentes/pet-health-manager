import { PetsComponent } from "../../../src/app/pets/pets.component"

describe("PetsComponent", () => {
  it("should mount", () => {
    cy.mount(PetsComponent)
  })
})
