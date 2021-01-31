using System.Reflection;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using System.Collections.Generic;
using System.Linq;
public class RunnableGraphView : GraphView
{
    System.Type graphType;
    public RunnableGraphView(System.Type type)
    {
        graphType = type;
        var ss = Resources.Load<StyleSheet>("GridStyle");
        styleSheets.Add(ss);

        SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);
        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());
        this.AddManipulator(new FreehandSelector());
        var grid = new GridBackground();
        Insert(0, grid);
        grid.StretchToParentSize();

        TempInit();
    }

    public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
    {
        var ret = new List<Port>();
        if (startPort.portType == typeof(FlowEntryPort))
        {
            ports.ForEach(port =>
            {
                if (port.portType == typeof(FlowExitPort)) ret.Add(port);
            });
        }
        else if (startPort.portType == typeof(FlowExitPort))
        {
            ports.ForEach(port =>
            {
                Debug.Log(port.name + " " + port.portType);
                if (port.portType == typeof(FlowEntryPort)) ret.Add(port);
            });
        }
        return ret;
    }

    private void TempInit()
    {
        CreateNode<StartNode>(new Rect(200, 200, 100, 150));
        CreateNode<ExcuteNode>(new Rect(400, 200, 100, 150));
        CreateNode<EndNode>(new Rect(600, 200, 100, 150));
        CreateNode<IfNode>(new Rect(800, 200, 100, 150));
        CreateMethodNode("Move");
        MethodInfo info = graphType.GetMethod("Move");
        CreateMethodNode(info);
    }

    public Node CreateNode<T>(Rect position) where T : BaseNode, new()
    {
        T node = new T();
        node.SetPosition(position);
        node.OnCreate();
        AddElement(node);
        return node;
    }

    public void CreateMethodNode(string methodName)
    {
        var node = ReflectionHelper.DoExportMethod(graphType.GetMethod(methodName));
        AddElement(node);
    }
    public void CreateMethodNode(MethodInfo methodInfo)
    {
        var node = ReflectionHelper.DoExportMethod(methodInfo);
        AddElement(node);
    }
    public void RemoveNodes(IEnumerable<Node> nodes)
    {
        foreach (var node in nodes)
        {
            RemoveNode(node);
        }
    }

    public void RemoveNode(Node node)
    {
        RemoveElement(node);
    }
}
