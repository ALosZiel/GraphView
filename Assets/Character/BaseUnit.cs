using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // graphProxy.Update();
    }

    [ExportMethod]
    public void Move(Vector2 input)
    {
        Debug.Log(input);
        transform.Translate(input.x, 0, input.y);
    }
}