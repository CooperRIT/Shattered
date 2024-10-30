using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Float Event Channel")]
public class FloatEventChannel : GenericEventChannel<FloatEvent> { }
[System.Serializable]
public struct FloatEvent
{
    public float FloatValue;

    public FloatEvent(float floatValue) => FloatValue = floatValue;
}
