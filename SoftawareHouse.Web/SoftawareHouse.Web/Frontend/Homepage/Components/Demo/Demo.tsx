import * as React from "react";
import "./Demo.scss";

interface IDemoComponentState {
    time : Date
}




class Demo extends React.Component<any, IDemoComponentState> {

    timerHandle : number;

    public constructor(props: any) {
        super(props);

        this.state = { time: new Date() };

        this.updateTime = this.updateTime.bind(this);
    }

    updateTime(): void {
        this.setState({ time: new Date()});
    }

    componentDidMount(): void {
        this.timerHandle = setInterval(this.updateTime, 1000);
    }

    componentWillUnmount(): void {
        clearInterval(this.timerHandle);
    }

    public render() {
        return (
            <div className="Demo">
                <p>ASP.NET + React, from PoznajProgramowanie.pl how HOT?</p>
                <p>Current time: {this.state.time.toString()}</p>
            </div>
        );
    }
}

export default Demo;