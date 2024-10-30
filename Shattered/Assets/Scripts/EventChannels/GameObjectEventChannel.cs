using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/GameObject Event Channel")]
public class GameObjectEventChannel : GenericEventChannel<GameObjectEvent> { }

public struct GameObjectEvent
{
    public GameObject GameObjectRef;

    public GameObjectEvent(GameObject gameObjectRef) => GameObjectRef = gameObjectRef;
}