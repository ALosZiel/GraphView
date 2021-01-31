
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using System;

public class FlowEntryPort// : Port
{
    // protected InputFlowPort() : base(Orientation.Horizontal, Direction.Input, Capacity.Single, typeof(InputFlowPort))
    // {

    // }
}

public class FlowExitPort// : Port
{
    // protected OutputFlowPort() : base(Orientation.Horizontal, Direction.Output, Capacity.Single, typeof(OutputFlowPort))
    // {

    // }
}

public class InputValuePort: Port
{
    protected InputValuePort() : base(Orientation.Horizontal, Direction.Input, Capacity.Single, typeof(FlowExitPort))
    {

    }
}

public class OutputValuePort: Port
{
    protected OutputValuePort() : base(Orientation.Horizontal, Direction.Output, Capacity.Single, typeof(FlowEntryPort))
    {

    }
}