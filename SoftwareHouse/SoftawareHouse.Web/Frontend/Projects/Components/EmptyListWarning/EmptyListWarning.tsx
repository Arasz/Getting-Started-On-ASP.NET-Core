import * as React from "react";
import "./EmptyListWarning.scss";
import "../../../Shared/Components/Button";

class EmptyListWarning extends React.Component<any,any>{

    private paths = {
        createProjectUrl:"/Projects/Add",
        createProjectLogo:""
    }

    public render() : any {
        return (
            <section className="EmptyListWarning"> 
                <img className="center-block"/>
                <section className="EmptyListWarning-textContainer">
                    <p className='text-center'>It looks like you don't have any projects created.</p>
                    <p className='text-center'>
                        <Button hasLink={true} href={this.paths.createProjectUrl} extraClassNames={['btn-success']}>
                            Create first project
                        </Button>
                    </p>
                </section>
            </section>
        )
    }

}
