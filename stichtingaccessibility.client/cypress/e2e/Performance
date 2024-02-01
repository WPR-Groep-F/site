describe('Performance Tests', () => {
  it('should measure the load time of the front page', () => {
    const startTime = new Date().getTime();
    cy.visit('https://localhost:5173/');
    const endTime = new Date().getTime();
    const pageLoadTime = endTime - startTime;
    cy.log(`Front page load time: ${pageLoadTime} milliseconds`);
    expect(pageLoadTime).to.be.lessThan(5000); 
  });

  it('should measure the load time of the Forgot Password page', () => {
    const startTime = new Date().getTime();
    cy.visit('https://localhost:5173/');
    cy.contains('Forgot password?').click();
    cy.url().should('include', '/forgot');
    const endTime = new Date().getTime();
    const pageLoadTime = endTime - startTime;
    cy.log(`Forgot Password page load time: ${pageLoadTime} milliseconds`);
    expect(pageLoadTime).to.be.lessThan(5000); 
  });

  it('should measure the load time of the Register page', () => {
    const startTime = new Date().getTime();
    cy.visit('https://localhost:5173/');
    cy.contains('Register here').click();
    cy.url().should('include', '/register');
    const endTime = new Date().getTime();
    const pageLoadTime = endTime - startTime;
    cy.log(`Register page load time: ${pageLoadTime} milliseconds`);
    expect(pageLoadTime).to.be.lessThan(5000); 
  });
});

describe('API Performance Test', () => {
  it('should measure the performance of the API call and receive a status code 500 within an acceptable timeframe', () => {
    // Use cy.clock() to control time
    cy.clock();

    // Network request and force a 500 status response
    cy.intercept('POST', 'https://localhost:7024/api/BedrijfPortaal/CreateOnderzoek', {
      statusCode: 500,
    }).as('createOnderzoek');

    // Start measuring time for the API call
    const apiCallStartTime = new Date().getTime();
    
    cy.visit('https://localhost:5173/deskundig');
    cy.get('input[placeholder="Titel onderzoek"]').type('Test Titel');
    cy.get('input[placeholder="Beschrijving"]').type('Test Beschrijving');
    cy.get('button[type="submit"]').click();

    // Wait for the API call to complete
    cy.wait('@createOnderzoek').then(() => {
      // Stop measuring time for the API call
      const apiCallEndTime = new Date().getTime();
      const apiCallDuration = apiCallEndTime - apiCallStartTime;

      // Log the API call duration
      cy.log(`API call duration: ${apiCallDuration} milliseconds`);

      // Assert that the API call duration is within an acceptable timeframe (e.g., less than 500 milliseconds)
      expect(apiCallDuration).to.be.lessThan(3000);
    });

    // Restore the clock
    cy.clock().invoke('restore');
  });
});
