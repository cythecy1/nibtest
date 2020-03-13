import React from "react";
import CareerSummary from "./careerSummary";
import CareerDetail from "./careerDetail";

class CareerList extends React.Component {
  state = {
    showDetail : false
  }
  handleViewDetails = selectedCareer => {
    this.setState({showDetail : true, career : selectedCareer});
  }
  
  componentDidUpdate(prevProps) {
    if(prevProps.selectedLocation !== this.props.selectedLocation) {
      this.setState({showDetail : false});
    }
  }
  handleBackToSummary = () => {
    this.setState({showDetail : false});
  }

  render() {
    const showDetail = this.state.showDetail;
    return (
      <>
      {showDetail
        ? <CareerDetail career={this.state.career} onBackToSummary={this.handleBackToSummary}/>
        : <div className="container">
            <div className="row">
              { this.props.careers && this.props.careers.map(career => <CareerSummary key={career.id} career={career} onViewDetails={this.handleViewDetails}/>)}
            </div>
          </div>
      }

      </>
    );
  }
}

export default CareerList;
