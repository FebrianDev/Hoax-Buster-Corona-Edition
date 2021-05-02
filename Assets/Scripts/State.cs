using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "New Hoax", menuName = "Hoax")]
public class State : ScriptableObject
{
    public List<DataHoax> states = new List<DataHoax>();
};

[System.Serializable]
public struct DataHoax
{
    [TextArea(5,10)]
    public string statement;
    public Key key;
};

public enum Key
{
    TRUE,
    FALSE
}
