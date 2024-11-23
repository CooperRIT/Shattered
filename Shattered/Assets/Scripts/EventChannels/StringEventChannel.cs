using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/String Event Channel")]
public class StringEventChannel : GenericEventChannel<StringEvent> { }

[System.Serializable]
public struct StringEvent
{
    public string stringref;

    public StringEvent(string stringRef) => stringref = stringRef;
}
