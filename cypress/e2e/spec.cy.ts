describe('Home page load test', () => {
  it('Visits the initial project page', () => {
    cy.visit('/')
    cy.contains('Pet health manager')
  })
})
