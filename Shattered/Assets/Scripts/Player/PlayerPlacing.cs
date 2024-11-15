using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPlacing : MonoBehaviour
{
    [SerializeField] PlacementPointer placementPosition;
    [SerializeField] GameObjectEventChannel openTowerMenu_EventChannel;
    [SerializeField] VoidEventChannel onPlaceTower_EventChannel;
    [SerializeField] VoidEventChannel onExitPlacing_EventChannel;

    bool isPlacing;

    public void EnterPlacementMode()
    {
        placementPosition.gameObject.SetActive(true);
        isPlacing = true;
        openTowerMenu_EventChannel.CallEvent(new(placementPosition.gameObject));
    }

    public void PlaceTower()
    {
        onPlaceTower_EventChannel.CallEvent(new());
        ExitMode();
    }

    public void ExitPlacementMode()
    {
        onExitPlacing_EventChannel.CallEvent(new());
    }

    public void ExitMode()
    {
        isPlacing = false;
        placementPosition.gameObject.SetActive(false);
    }

    public bool IsPlacing
    {
        get { return isPlacing; }
    }

    public bool CanPlace
    {
        get { return placementPosition.CanPlace; }
    }
}
