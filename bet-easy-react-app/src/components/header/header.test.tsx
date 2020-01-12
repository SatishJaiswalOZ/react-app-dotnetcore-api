import React from 'react';
import { render } from '@testing-library/react';
import Header from './header';

test('header comp: renders text from document', () => {
  const { getByText } = render(<Header />);
  const linkElement = getByText(/Racing/i);
  expect(linkElement).toBeInTheDocument();
});