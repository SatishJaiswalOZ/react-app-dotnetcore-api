import React from "react";
import "./error.scss";
import AppContext from "../../context/app-context";
class Error extends React.Component {
  render() {
    return (
      <AppContext.Consumer>
        {(context: any) => {
          return (
            <div className="error">
              <h2>Something went wrong.</h2>
              <details style={{ whiteSpace: "pre-wrap" }}>
                {context.errorMessage && context.errorMessage.toString()}
              </details>
            </div>
          );
        }}
      </AppContext.Consumer>
    );
  }
}

export default Error;
