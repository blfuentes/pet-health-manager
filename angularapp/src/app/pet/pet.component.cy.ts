import { PetComponent } from './pet.component'

describe('PetComponent', () => {
  it('should mount', () => {
    cy.mount(PetComponent)
  })
})