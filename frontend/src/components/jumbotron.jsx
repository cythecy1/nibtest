import React from "react";

class Jumbotron extends React.Component {
  state = {
    selectedLocation : this.props.selectedLocation
  };

  componentDidUpdate(prevProps) {
    if(prevProps.selectedLocation !== this.props.selectedLocation) {
      this.setState({selectedLocation: this.props.selectedLocation});
    }
  }
  render() {
    return (
      <>
        <div className="jumbotron">
          <div className="container">
          <h1 className="display-3">Career Page { this.state.selectedLocation && this.state.selectedLocation.selectedLocation.name }</h1>
            <p>
              Welcome to this career page.  You will see jobs posted here from based on chosen location.
              { this.state.selectedLocation && "  Your chosen location is " + this.state.selectedLocation.selectedLocation.name }
            </p>
            <p>
              <a className="btn btn-primary btn-lg" href="#" role="button">
                Learn more &raquo;
              </a>
            </p>
          </div>
        </div>
      </>
    );
  }
}
export default Jumbotron;
