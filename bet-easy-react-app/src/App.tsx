import React from "react";
import "./App.css";
import Header from "./components/header/header";
import Filters from "./components/filters/filters";
import Races from "./components/races/races";
import AppContext from "./context/app-context";
import ErrorBoundary from "./components/error/error-boundary";
import Error from "./components/error/error";

class App extends React.Component {
  private static refreshInterval = 1000;
  private tickRef: NodeJS.Timeout | null;
  readonly state: any;
  constructor(props: any) {
    super(props);
    this.state = {
      isDataGetInProgress: true,
      current: {},
      errorMessage: null,
      filtertype: 0
    };
    this.tickRef = null;
  }

  componentDidMount() {
    this.tickRef = setInterval(
      this.dataPollingAndUpdate.bind(this),
      App.refreshInterval
    );
  }

  componentWillUnmount() {
    if (this.tickRef) {
      clearInterval(this.tickRef);
    }
  }

  dataPollingAndUpdate() {
    if (this.state.errorMessage) {
      if (this.tickRef) {
        clearInterval(this.tickRef);
      }
      throw this.state.errorMessage;
    }
    // Avoid additional render on mount
    if (!this.state.isDataGetInProgress) {
      this.setState({ isDataGetInProgress: true });
    }

    // The tickRef check is because the request may be in progress
    // when the timer is canceled. This prevents setState being called after
    // the component has unmounted.
    fetch(
      "https://s3-ap-southeast-2.amazonaws.com/bet-easy-code-challenge/next-to-jump"
    )
      .then(response => {
        if (response.ok) {
          return response.json();
        }
        this.tickRef &&
          this.setState({
            current: null,
            errorMessage: `Communication issue: ${response.statusText} ${response.status}`,
            isDataGetInProgress: false
          });
      })
      .then(data => {
        if (!data) {
          return;
        }
        const filteredData = data.result.filter((item: any) => {
          return this.state.filtertype === 0
            ? true
            : item.EventType.EventTypeID === this.state.filtertype;
        });
        this.tickRef &&
          this.setState({
            current: filteredData,
            errorMessage: null,
            isDataGetInProgress: false
          });
      })
      .catch(error => {
        this.tickRef &&
          this.setState({
            current: {},
            errorMessage: error.message,
            isDataGetInProgress: false
          });
      });
  }

  render() {
    if (this.state.errorMessage) {
      return (
        <AppContext.Provider value={this.state}>
          <React.Fragment>
            <Error />
          </React.Fragment>
        </AppContext.Provider>
      );
    }
    return (
      <AppContext.Provider value={this.state}>
        <ErrorBoundary>
          <React.Fragment>
            <Header />
            <div className="parent">
              <div className="parent__inner1">
                <div className="parent__inner--content">
                  <div className="parent__title">Next to Jump</div>
                  <Filters />
                  <Races />
                </div>
              </div>
            </div>
          </React.Fragment>
        </ErrorBoundary>
      </AppContext.Provider>
    );
  }
}

export default App;
