import React from "react";
import { render } from "@testing-library/react";
import Error from "./error";
import Enzyme, { mount } from "enzyme";

test("error comp: renders text from document", () => {
  const { getByText } = render(<Error />);
  const linkElement = getByText(/Something went wrong./i);
  expect(linkElement).toBeInTheDocument();
});

test("function called on click", () => {
  const component = mount(<Error />);
  console.log(component.find("details"));
  /* expect(context.errorMessage.).toBe(1); */
});

const mockContext = {
  isDataGetInProgress: true,
  current: {},
  errorMessage: "hi",
  filtertype: 0
};
jest.mock("../../context/app-context", () => ({
  Consumer: ({ children }) => children(mockContext)
}));

describe("FruityComponent", () => {
 
  ["hi", "hello", "ok"].map(error =>
    test(`should pass ${error} context to FruityHeader`, () => {
      mockContext.errorMessage= error;
      const fruityHeader = mount(<Error />).find("details");
      expect(fruityHeader.prop("children")).toEqual(error);
    })
  );
});
