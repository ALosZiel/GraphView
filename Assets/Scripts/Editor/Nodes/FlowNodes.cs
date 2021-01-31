using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class FlowNode : BaseNode
{
    protected void GenerateEntryPort(string portName = "")
    {
        var inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(FlowEntryPort));
        inputPort.portName = portName;
        inputContainer.Add(inputPort);
    }

    protected void GenerateExitPort(string portName = "")
    {
        var outputPort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(FlowExitPort));
        outputPort.portName = portName;
        outputContainer.Add(outputPort);
    }

    public void AddInputValuePort(string name)
    {
        var port = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(InputValuePort));
        port.portName = name;
        inputContainer.Add(port);
    }

    public void AddOutputValuePort(string name)
    {
        var port = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, typeof(OutputValuePort));
        port.portName = name;
        outputContainer.Add(port);
    }
}

public class StartNode : FlowNode
{
    public override void OnCreate()
    {
        title = "Start";
        GenerateExitPort();
    }
}

public class UpdateNode : StartNode
{
    public override void OnCreate()
    {
        base.OnCreate();
    }
}

public class ExcuteNode : FlowNode
{
    public override void OnCreate()
    {
        GenerateEntryPort();
        GenerateExitPort();
    }
}

public class EndNode : FlowNode
{
    public override void OnCreate()
    {
        title = "End";
        GenerateEntryPort();
    }
}

public class BranchNode : FlowNode
{

}

public class IfNode : BranchNode
{
    public override void OnCreate()
    {
        title = "If";
        GenerateEntryPort();
        var inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
        inputContainer.Add(inputPort);

        GenerateExitPort("true");
        GenerateExitPort("false");
    }
}

public class Switch : BranchNode
{

}