import * as React from "react";
import "./ProjectsList.scss";
import "../../../Shared/Styles/common.scss";
import Project from "../../Models/Project";

interface IProjectsListProps{
    projects : Project[];
}

class ProjectsList extends React.Component<IProjectsListProps,any>{

    constructor(props){
        super(props);
    }

    public render() : any {
        return (
            <section className="ProjectList row">
                <div className="col-md-8 col-md-push-2">
                    {this.props.projects.map(project => <ProjectElement model={project}/>)}
                </div>
            </section>
        );

    }
}

export default ProjectsList;