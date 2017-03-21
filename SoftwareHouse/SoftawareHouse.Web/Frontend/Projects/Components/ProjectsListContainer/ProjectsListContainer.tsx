import * as React from "react";
import Project from "../../Models/Project";

interface IProjectsListContainerState {
    loadingData: boolean;
    projects: Project[];
}

class ProjectsListContainer extends  React.Component<any, IProjectsListContainerState>{

    constructor(props) {
        super(props);

        this.state = {
            loadingData: true,
            projects: Project[]
        };
    }

    renderProjects() {
        const hasProjects = this.state.projects.length > 0;

        if (hasProjects)
            return <p className="text-center">Projects list</p>;
        else {
            return <p className="text-center">No data</p>;
        }
    }

    render() : any {


        if (this.state.loadingData) {
            return <p className="text-center">Loading...</p>;
        }
        else {
            return this.renderProjects();
        }
    }
}

export default ProjectsListContainer;
