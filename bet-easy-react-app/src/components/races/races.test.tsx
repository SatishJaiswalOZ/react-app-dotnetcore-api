import React from "react";
import { render } from "@testing-library/react";
import Races from "./races";
import Enzyme, { mount } from "enzyme";

const mockContext = {
  isDataGetInProgress: true,
  current: [
    {
      EventName: "Race 6",
      AdvertisedStartTime: "2018-11-27T00:49:00Z",
      EventType: {
        EventTypeID: 2
      },
      Venue: {
        Venue: "Northfield Park"
      }
    },
    {
      EventName: "Race 3 - Claiming",
      AdvertisedStartTime: "2018-11-27T00:51:00Z",
      EventType: {
        EventTypeID: 1
      },
      Venue: {
        Venue: "Mountaineer Park"
      }
    },
    {
      EventName: "Oreti Beach Run",
      AdvertisedStartTime: "2018-11-27T00:52:00Z",
      EventType: {
        EventTypeID: 3
      },
      Venue: {
        Venue: "Ascot Park Nz"
      }
    },
    {
      EventName: "Race 3",
      AdvertisedStartTime: "2018-11-27T00:53:00Z",
      EventType: {
        EventTypeID: 3
      },
      Venue: {
        Venue: "Daytona Beach"
      }
    },
    {
      EventName: "Mohawk Fillies & Mares Pace Ms",
      AdvertisedStartTime: "2018-11-27T00:55:00Z",
      EventType: {
        EventTypeID: 2
      },
      Venue: {
        Venue: "Mohawk"
      }
    }
  ],
  errorMessage: "has error",
  filtertype: 0
};
jest.mock("../../context/app-context", () => ({
  Consumer: ({ children }) => children(mockContext)
}));

describe("Race Component", () => {
  ["Northfield Park"].map(races =>
    test(`should pass ${races} context to Race Venue`, () => {
      const raceItems = mount(<Races />).find('[data-testid="race-venue-0"]');
      expect(raceItems.text()).toBe("Northfield Park");
    })
  );
});
