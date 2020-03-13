import React from 'react';

class CareerDetail extends React.Component {
    render() { 
        return (
            <div className="container">
                <div className="row">
                    <div className="col-md-12">
                        <h2>{this.props.career.title}</h2>
                    </div>
                </div>
                <div className="row">
                    <div className="col-md-12">
                        <div className="input-group mb-3">
                            <div className="input-group-prepend">
                                <span className="input-group-text" id="basic-addon3">Role Description</span>
                            </div>
                                <input type="text" className="form-control" id="basic-url" aria-describedby="basic-addon3" readOnly value={this.props.career.roleDescription}/>
                        </div>
                    </div>
                </div>
                <div className="row">
                    <div className="col-md-12">
                        <div className="input-group mb-3">
                            <div className="input-group-prepend">
                                <span className="input-group-text" id="basic-addon3">Skills Description</span>
                            </div>
                                <input type="text" className="form-control" id="basic-url" aria-describedby="basic-addon3" readOnly value={this.props.career.skillsDescription}/>
                        </div>
                    </div>
                </div>
                <div className="row">
                    <div className="col-md-12">
                        <div className="input-group mb-3">
                            <div className="input-group-prepend">
                                <span className="input-group-text" id="basic-addon3">Benefits Description</span>
                            </div>
                                <input type="text" className="form-control" id="basic-url" aria-describedby="basic-addon3" readOnly value={this.props.career.benefitsDescription}/>
                        </div>
                    </div>
                </div>
                <div className="row">
                    <div className="col-md-4">
                    <p>
                        <a className="btn btn-secondary" href="#" role="button" onClick={() => this.props.onBackToSummary()}>
                            Back &raquo;
                        </a>
                    </p>
                    </div>
                </div>
            </div>
        );
    }
}
 
export default CareerDetail;