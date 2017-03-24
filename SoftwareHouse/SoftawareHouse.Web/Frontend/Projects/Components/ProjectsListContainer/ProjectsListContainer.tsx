import * as React from "react";
import Project from "../../Models/Project";
import EmptyListWarning from "../EmptyListWarning/EmptyListWarning";

interface IProjectsListContainerState {
    loadingData: boolean;
    projects: Array<Project>;
}

class ProjectsListContainer extends React.Component<any, IProjectsListContainerState>{

    constructor(props) {
        super(props);

        this.state = {
            loadingData: true,
            projects: new Array<Project>()
        };
    }

    private paths = {
        getAllProjects: "/Api/Projects"
    };

    componentDidMount(): void {
        fetch(this.paths.getAllProjects, {
            credentials: 'include'
        })
            .then((response) => {
                return response.text();
            })
            .then((data) => {
                this.setState({
                    loadingData: false,
                    projects: JSON.parse(data),
                });
            });
    }

    renderProjects() {
        const hasProjects = this.state.projects.length > 0;

        if (hasProjects)
            return <p className="text-center">Projects list</p>;
        else {
            return <EmptyListWarning/>
        }
    }

    render(): any {
        if (this.state.loadingData) {
            return <p className="text-center">Loading...</p>;
        }
        else {
            return this.renderProjects();
        }
    }
}

export default ProjectsListContainer;
