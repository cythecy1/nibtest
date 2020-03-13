import React from "react";
import {DropdownButton, Dropdown} from 'react-bootstrap';

class Filter extends React.Component {
  render() {
    const { locations } = this.props.locations;
    return (
      <>
      <nav className="navbar navbar-expand-md navbar-dark fixed-top bg-dark">
        <a className="navbar-brand" href="#">
          Career Page
        </a>
        <button
          className="navbar-toggler"
          type="button"
          data-toggle="collapse"
          data-target="#navbarsExampleDefault"
          aria-controls="navbarsExampleDefault"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse" id="navbarsExampleDefault">
          <ul className="navbar-nav mr-auto">
          <li className="nav-item dropdown">
            <DropdownButton id="dropdown-basic-button" title="Location">
              {
                locations.map(location => (
                <Dropdown.Item key={location.id} onClick={() => this.props.onLocationSelect(location) }>{location.name}</Dropdown.Item>
                ))
              }
            </DropdownButton>
          </li>
          </ul>
        </div>
      </nav>
      </>
    );
  }
}

export default Filter;
