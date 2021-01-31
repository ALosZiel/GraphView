using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

public class RunnableGraphWindow : EditorWindow
{
    RunnableGraphView runnableGraph;

    [MenuItem("RunableGraph/Graph")]
    public static void ShowWindow()
    {
        GetWindow<RunnableGraphWindow>().Show();
    }
    void OnEnable()
    {
        runnableGraph = new RunnableGraphView(typeof(BaseUnit));
        runnableGraph.StretchToParentSize();
        rootVisualElement.Add(runnableGraph);

        var toolbar = new Toolbar();
        toolbar.Add(new ToolbarButton() {text = "A Button"});
        rootVisualElement.Add(toolbar);
    }

    void OnDisable()
    {
        rootVisualElement.Remove(runnableGraph);
    }
}
