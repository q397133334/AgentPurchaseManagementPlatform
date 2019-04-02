import { AgentPurchaseManagementPlatformTemplatePage } from './app.po';

describe('AgentPurchaseManagementPlatform App', function() {
  let page: AgentPurchaseManagementPlatformTemplatePage;

  beforeEach(() => {
    page = new AgentPurchaseManagementPlatformTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
