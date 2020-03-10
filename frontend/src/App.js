import React from "react";
import logo from "./logo.svg";
import "./App.css";
import Filter from "./components/filter";
import Jumbotron from "./components/jumbotron";
import CareerList from "./components/careerlist";

class App extends React.Component {
  state = {
    locations: [
      {
        id: 1,
        name: "Newcastle",
        state: "NSW"
      },
      {
        id: 2,
        name: "Gosford",
        state: "NSW"
      },
      {
        id: 3,
        name: "Sydney",
        state: "NSW"
      },
      {
        id: 4,
        name: "Brisbane",
        state: "QLD"
      },
      {
        id: 5,
        name: "Melbourne",
        state: "VIC"
      },
      {
        id: 6,
        name: "Perth",
        state: "WA"
      }
    ]
  };
  render() {
    return (
      <>
        <Filter />
        <Jumbotron />
        <CareerList />
      </>
    );
  }
}
export default App;
