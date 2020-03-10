import React from "react";
import logo from "./logo.svg";
import "./App.css";
import Filter from "./components/filter";
import Jumbotron from "./components/jumbotron";
import CareerList from "./components/careerlist";

class App extends React.Component {
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
