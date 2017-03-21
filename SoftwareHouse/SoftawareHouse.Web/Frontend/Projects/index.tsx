import * as React from "react";
import * as ReactDOM from "react-dom";

import "../Shared/Styles/common.scss";

import ProjectsListConatiner from "./Components/ProjectsListContainer/ProjectsListContainer";

ReactDOM.render(<ProjectsListConatiner />, document.getElementById("react-root"));

declare var module: any;
if (module.hot) {
    module.hot.accept();
}