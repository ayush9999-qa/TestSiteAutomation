Feature: Open Website
As a user
I want to open the website
So that I can verify the homepage loads correctly

    Scenario: Open the home page and verify the title
        Given I have opened the browser
        When I navigate to the home page
        Then the "HomePage" title should be "Practice Test Automation WebSite"