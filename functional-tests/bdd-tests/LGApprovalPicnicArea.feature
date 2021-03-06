﻿Feature: LGApprovalPicnicArea
    As a logged in business user
    I want to submit a Picnic Area Endorsement Application for review and approval

@e2e @catering @privatecorporation @picnic @lgapproval
Scenario: Local Government Approval for Picnic Area Endorsement
    Given I am logged in to the dashboard as a private corporation
    And I click on the Start Application button for a Manufacturer Licence
    And I review the account profile for a private corporation
    And I review the organization structure for a private corporation
    And I click on the button for Submit Organization Information
    And I complete the Manufacturer application for a winery in Saanich
    And I review the security screening requirements for a private corporation
    And I click on the button for Pay for Application
    And I enter the payment information
    And I confirm the payment receipt for a Manufacturer Licence application
    And the application is approved
    And I pay the licensing fee for a Manufacturer application
    And I request a picnic area endorsement
    And I log in as local government for Saanich
    And I specify that the zoning allows the endorsement
    And I specify my contact details
    And I log in as a return user
    And I review the local government response for a picnic area endorsement
    And the dashboard status is updated as Application Under Review
    And the account is deleted
    Then I see the login page 