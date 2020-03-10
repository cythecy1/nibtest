import React from "react";
import CareerSummary from "./careersummary";

class CareerList extends React.Component {
  render() {
    return (
      <>
        <div class="container">
          <div class="row">
            <div class="col-md-4">
              <CareerSummary />
            </div>
          </div>
        </div>
      </>
    );
  }
}

export default CareerList;
