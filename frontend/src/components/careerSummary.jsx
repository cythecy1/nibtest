import React from "react";

class CareerSummary extends React.Component {
  render() {
    const roleDesc = this.props.career.roleDescription.substring(0, 130);
    return (
      <div className="col-md-4">
        <h2>{this.props.career.title}</h2>
        <p>
          {roleDesc}
        </p>
        <p>
          <a className="btn btn-secondary" href="#" role="button" onClick={() => this.props.onViewDetails(this.props.career)}>
            View details &raquo;
          </a>
        </p>
      </div>
    );
  }
}
export default CareerSummary;
