using UnityEngine;
using UnityEngine.Events;

public abstract class GenericEventChannel<T> : ScriptableObject
{
    [Tooltip("Actions performed when this event is called")]
    public UnityEvent<T> OnEventCalled;
    public void CallEvent(T parameter) => OnEventCalled?.Invoke(parameter);
}
