import * as React from "react";
import Project from "../../Models/Project";
import EmptyListWarning from "../EmptyListWarning/EmptyListWarning";
import ProjectsList from "../ProjectsList/ProjectsList";


interface IProjectsListContainerState {
    loadingData: boolean;
    projects: Project[];
}

class ProjectsListContainer extends React.Component<any, IProjectsListContainerState>{

    constructor(props) {
        super(props);

        this.state = {
            loadingData: true,
            projects: [] as Project [],
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
                console.log(JSON.parse(data));            
                this.setState({
                    loadingData: false,
                    projects: JSON.parse(data),
                });
            });
    }

    renderProjects() {
        const hasProjects = this.state.projects.length > 0;

        if (hasProjects)
            return <ProjectsList projects={this.state.projects} />
        else {
            return <EmptyListWarning />
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
