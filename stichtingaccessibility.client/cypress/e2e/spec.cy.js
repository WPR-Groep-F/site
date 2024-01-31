// cypress/integration/frontPage.spec.js

describe('Front Page Accessibility', () => {
  it('should allow the user to register on the site', () => {
    cy.visit('https://localhost:5173/register');
  
          // Check if login form is visible
          cy.get('[name="username"]').should('be.visible');
          cy.get('[name="email"]').should('be.visible');
          cy.get('[name="password"]').should('be.visible');
          cy.get('[placeholder="Confirm Password"]').should('exist');

           // Wait for 1000 milliseconds
           cy.wait(1000);

        // Fill in registration form
        cy.get('[name=username]').type('testuser69');
        cy.get('[name=email]').type('test@example.com');
        cy.get('[name=password]').type('!Testpassword123');
        cy.get('[placeholder="Confirm Password"]').type('testpassword');

        // Submit form
        cy.contains('Registreer').click({ force: true });

      });


      it('Displays errors for invalid registration', () => {
        cy.visit('https://localhost:5173/register');
  
        // Submit form
        cy.contains('Registreer').click({ force: true });
    
        // Check for validation errors
        // cy.get('.ulError').should('be.visible');
        cy.contains('Passwords must be at least 6 characters.').should('be.visible');
        cy.contains('Passwords must have at least one non alphanumeric character.').should('be.visible');
        cy.contains('Passwords must have at least one digit').should('be.visible');
        cy.contains('Passwords must have at least one lowercase').should('be.visible');
        cy.contains('Passwords must have at least one uppercase').should('be.visible');
        cy.contains('Passwords must use at least 1 different characters.').should('be.visible');

         // Assert that the URL remains on the register page
        cy.url().should('include', '/register');
        
    });
  });