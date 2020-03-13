import React from "react";
import CareerSummary from "./careerSummary";

class CareerList extends React.Component {
  state = {
    careers: ['career1', 'career2', 'career3', 'career4', 'career5']
  };
  render() {
    return (
      <>
        <div className="container">
          <div className="row">
            { this.state.careers.map(career => <CareerSummary key={career}/>)}
          </div>
        </div>
      </>
    );
  }
}

export default CareerList;
