Feature: Login tests

Scenario: Successful navigation from Home page
    Given I have opened the browser
    When I navigate to the home page
    When I click on Login link
    Then the "LoginPage" title should be "Test Login Page for Automation Testing Practice"

    When I enter username as "username"
    And I enter password as "password"
    And I click on Login Button
    Then the "SecurePage" title should be "Secure Page page for Automation Testing Practice"