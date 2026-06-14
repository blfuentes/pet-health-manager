/// <reference types="cypress" />
import { mount } from 'cypress/angular'
import { PetComponent } from './pet.component'

describe('PetComponent', () => {
  it('should mount', () => {
    mount(PetComponent)
  })
})