using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Void Event Channel")]
public class VoidEventChannel : GenericEventChannel<VoidEvent> { }

[System.Serializable]
public struct VoidEvent
{

}
