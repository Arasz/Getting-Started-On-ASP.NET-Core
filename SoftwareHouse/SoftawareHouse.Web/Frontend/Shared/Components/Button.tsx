import * as React from "react";


interface IButtonProps {
    hasLink : boolean;
    href : string;
    extraClassNames : string[];
}

class Button extends React.Component<IButtonProps, any>{
    
    private baseClassName = "btn";

    constructor(props){
        super(props);
    }

    private get classNames(){
        return`${this.baseClassName} ${this.props.extraClassNames.join(" ")}`;
    }

    public render() {
        if(this.props.hasLink){
            return (
            <a className={this.classNames} href={this.props.href}>
                {this.props.children}
            </a>);
        }
        else{
            return (
            <button className={this.classNames}>
                {this.props.children}
            </button>);
        }
    }
}

export default Button;