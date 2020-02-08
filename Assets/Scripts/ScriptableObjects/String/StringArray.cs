using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New String Array Scriptable Object", menuName = "String Array", order = 2)]
public class StringArray : ScriptableObject
{
    public List<StringVariable> values;
}
