using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New String Scriptable Object", menuName = "String Scriptable Object", order = 1)]
public class StringVariable : ScriptableObject
{
    public string value;
    [TextArea]
    public string description;
}
