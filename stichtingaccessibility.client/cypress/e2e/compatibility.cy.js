describe('Compatibility Tests', () => {
  it('should work on Chrome', () => {
    cy.visit('https://localhost:5173/');
  });

  it('should work on Firefox', () => {
    cy.visit('https://localhost:5173/');
  });

  it('should work on Edge', () => {
    cy.visit('https://localhost:5173/');
  });
});

describe('Device Compatibility Tests', () => {
  it('should be responsive on mobile devices', () => {
    cy.viewport('iphone-6');
    cy.visit('https://localhost:5173/');
  });

  it('should display correctly on tablet devices', () => {
    cy.viewport('ipad-2');
    cy.visit('https://localhost:5173/');
  });

  it('should display correctly on desktop', () => {
    cy.viewport('macbook-13');
    cy.visit('https://localhost:5173/');
  });
});
