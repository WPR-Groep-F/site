// cypress/integration/frontPage.spec.js

describe('Front Page Accessibility', () => {
  it('should have the name containing "Accessibility" and include "Forgot password?" and "Register here" links', () => {
    cy.visit('https://localhost:5173/'); // Visit the front page

    // Assert that the name containing "Accessibility" exists
    cy.contains("Accessibility").should('exist');

    // Assert that the "Forgot password?" link exists
    cy.contains('Forgot password?').should('exist');

    // Assert that the "Register here" link exists
    cy.contains('Register here').should('exist');
  });
});



describe('Forgot Password Link', () => {
  it('should navigate to the Forgot Password page when the link is clicked and have a "Back to Login" link', () => {
    cy.visit('https://localhost:5173/'); // Visit the front page

    
    cy.contains('Forgot password?').click();

    // Assert that the URL has changed to the Forgot Password page
    cy.url().should('include', '/forgot');

    // Assert that there is a "Back to Login" link on the Forgot Password page
    cy.contains('Back to Login').should('exist');
  });
});

describe('Register Link', () => {
  it('should navigate to the Register page when the link is clicked and have a "Back to Login" link', () => {
    cy.visit('https://localhost:5173/'); // Visit the front page

    
    cy.contains('Register here').click();

    // Assert that the URL has changed to the Register page
    cy.url().should('include', '/register');

    // Assert that there is a "Back to Login" link on the Register page
    cy.contains('Back to Login').should('exist');
  });
});
