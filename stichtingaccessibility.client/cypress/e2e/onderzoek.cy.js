// cypress/integration/frontPage.spec.js

describe('Front Page Accessibility', () => {
  it('should create and communicate with the API and receive a statuscode 500', () => {
    cy.visit('https://localhost:5173/deskundig');
  
    // Network request and force a 500 status response
    cy.intercept('POST', 'https://localhost:7024/api/BedrijfPortaal/CreateOnderzoek', {
      statusCode: 500,
      // body: {},
    }).as('createOnderzoek');

    // Fill in the form
    cy.get('input[placeholder="Titel onderzoek"]').type('Test Titel');
    cy.get('input[placeholder="Beschrijving"]').type('Test Beschrijving');

    // Submit the form
    cy.get('button[type="submit"]').click();

    // Check for the 500 status response
    cy.wait('@createOnderzoek').then((interception) => {
      expect(interception.response.statusCode).to.equal(500);
    });
  });
});