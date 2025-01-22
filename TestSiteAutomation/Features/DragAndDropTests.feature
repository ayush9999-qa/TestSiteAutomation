Feature: Drag and drop tests

    Scenario: Successful navigation from Home page
        Given I have opened the browser
        When I navigate to the home page
        When I click on Drag and drop link
        Then the "DragAndDropPage" title should be "Drag and Drop page for Automation Testing Practice"

        When I drag and drop
        Then texts of elements should change