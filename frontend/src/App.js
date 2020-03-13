import React from "react";
import logo from "./logo.svg";
import "./App.css";
import Filter from "./components/filter";
import Jumbotron from './components/jumbotron';
import CareerList from "./components/careerList";
import axios from 'axios';
class App extends React.Component {
  state = {
    locations: []
  }

  componentDidMount() {
    axios.get(`https://private-8dbaa-nibdevchallenge.apiary-mock.com/location`)
      .then(res => {
        const locations = res.data;
        this.setState({ locations });
      })
  }

  handleLocationSelect = selectedLocation => {
    axios.get(`https://localhost:44314/careers/byLocation?locationId=`+selectedLocation.id)
    .then(res => {
      const careers = res.data;
      this.setState({ careers : careers, selectedLocation });
    })
  }

  render() {
    return (
      <>
        <Filter locations={this.state} onLocationSelect = { this.handleLocationSelect }/>
        <Jumbotron selectedLocation={this.state.selectedLocation}/>
        <CareerList careers={this.state.careers} selectedLocation={this.state.selectedLocation}/>
      </>
    );
  }
}
export default App;
