import React from "react";
import Error from "./error";
import AppContext from "../../context/app-context";
class ErrorBoundary extends React.Component<
  {},
  { error: any; errorInfo: any }
> {
  constructor(props: any) {
    super(props);
    this.state = { error: null, errorInfo: null };
  }

  componentDidCatch(error: any, errorInfo: any) {
    // Catch errors in any components below and re-render with error message
    this.setState({
      error: error,
      errorInfo: errorInfo
    });
    // You can also log error messages to an error reporting service here
  }

  render() {
    if (this.state.errorInfo) {
      // Error path
      return (
        <AppContext.Consumer>
          {(context: any) => {
            context.errorMessage = this.state.error;
            return (
              <div>
                <Error />
              </div>
            );
          }}
        </AppContext.Consumer>
      );
    }
    // Normally, just render children
    return this.props.children;
  }
}
export default ErrorBoundary;
