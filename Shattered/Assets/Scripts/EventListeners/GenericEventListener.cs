using UnityEngine;
using UnityEngine.Events;

public abstract class GenericEventListener<TEventChannel, TEventType> : MonoBehaviour where TEventChannel : GenericEventChannel<TEventType>
{
    [SerializeField] protected TEventChannel eventChannel;

    [SerializeField] protected UnityEvent<TEventType> response;

    protected virtual void OnEnable()
    {
        if (eventChannel == null) return;

        eventChannel.OnEventCalled.AddListener(OnEventCalled);
    }

    protected virtual void OnDisable()
    {
        if (eventChannel == null) return;

        eventChannel.OnEventCalled.RemoveListener(OnEventCalled);
    }

    public void OnEventCalled(TEventType type) => response?.Invoke(type);
}
