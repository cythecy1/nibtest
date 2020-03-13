import React from "react";

class Jumbotron extends React.Component {

  render() {
    return (
      <>
        <div className="jumbotron">
          <div className="container">
          <h1 className="display-3">Career Page { this.props.selectedLocation && this.props.selectedLocation.name }</h1>
            <p>
              Welcome to this career page.  You will see jobs posted here from based on chosen location.
              { this.props.selectedLocation && "  Your chosen location is " + this.props.selectedLocation.name }
            </p>
          </div>
        </div>
      </>
    );
  }
}
export default Jumbotron;
