using System;
using System.Reflection;
public static class ReflectionHelper
{
    public static void GenerateMenuContent()
    {
        // var methods = type.GetMethods();
        // foreach (var method in methods)
        // {
        //     // var a = Attribute.GetCustomAttribute(method, typeof(ExportMethodAttribute)) as ExportMethodAttribute;
        //     var a = method.GetCustomAttribute<ExportMethodAttribute>();
        //     if (a == null) continue;

        // }
    }
    public static ExcuteNode DoExportMethod(MethodInfo methodInfo)
    {
        ExcuteNode newNode = new ExcuteNode();
        newNode.OnCreate();
        newNode.title = methodInfo.Name;
        if (!methodInfo.IsStatic)
        {
            newNode.AddInputValuePort("target");
        }

        foreach (var para in methodInfo.GetParameters())
        {
            // para.ParameterType();
            newNode.AddInputValuePort(para.Name);
        }

        if (methodInfo.ReturnType != typeof(void))
        {
            newNode.AddOutputValuePort("return");
        }
        return newNode;
    }
}