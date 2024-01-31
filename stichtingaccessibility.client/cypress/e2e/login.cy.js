// cypress/integration/frontPage.spec.js

describe('Front Page Accessibility', () => {
  it('should allow the user to sign in if all credentials are valid', () => {
    // Visit the front page
    cy.visit('https://localhost:5173/');

    // Check if login form is visible
    cy.get('[name="username"]').should('be.visible');
    cy.get('[name="password"]').should('be.visible');
    cy.contains('Login').should('exist');

    // Input username and password
    cy.get('[name="username"]').type('Test');
    cy.get('[name="password"]').type('Test123!');

      // Click the login button with force: true due to an SVG blocking the button
      cy.contains('Login').click({ force: true });

  });

  
it('handles invalid login credentials', () => {
  // Visit the login page
  cy.visit('https://localhost:5173/');

  // Input invalid username and password
  cy.get('[name="username"]').type('invalid_username');
  cy.get('[name="password"]').type('invalid_password');

  // Click the login button
  cy.contains('Login').click({force: true });

     // Wait for 20000 milliseconds
     cy.wait(20000);


  // Assert that an error message is displayed
  cy.contains('User name bestaat niet').should('be.visible');

  // Assert that the URL remains on the login page
  cy.url().should('include', '/');

});
});
