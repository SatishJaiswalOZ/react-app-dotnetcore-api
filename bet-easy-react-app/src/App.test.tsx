import React from "react";
import { render } from "@testing-library/react";
import App from "./App";
import { shallow } from "enzyme";

test("renders learn react link", () => {
  const { getByText } = render(<App />);
  const linkElement = getByText(/Next to Jump/i);
  expect(linkElement).toBeInTheDocument();
});

it("app renders header text of racing", () => {
  const ez = shallow(<App />);
  const beginHeader = <div className="parent__title">Next to Jump</div>;
  expect(ez.contains(beginHeader)).toEqual(true);
});
