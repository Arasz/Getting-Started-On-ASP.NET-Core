import * as React from "react";
import "./EmptyListWarning.scss";
import Button from "../../../Shared/Components/Button";

class EmptyListWarning extends React.Component<any,any>{

    private paths = {
        createProjectUrl:"/Projects/Add",
        createProjectLogo:"https://cdn.iconsflow.com/qwA3QsaXac57Uh3BdV3syAAV_B3i9CxkmLGGoXV4PD9c7IZZ.png"
    }

    public render() : any {
        return (
            <section className="EmptyListWarning"> 
                <img className="center-block" src={this.paths.createProjectLogo}/>
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
export default EmptyListWarning;
