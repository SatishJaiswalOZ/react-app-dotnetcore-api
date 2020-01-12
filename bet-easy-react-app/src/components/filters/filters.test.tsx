import React from "react";
import { render } from "@testing-library/react";
import Filters from "./filters";

test("filter comp: renders text from document", () => {
  const { getByText } = render(<Filters />);
  const linkElement = getByText(/All/i);
  expect(linkElement).toBeInTheDocument();
});
