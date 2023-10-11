using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventData", menuName = "Data/EventData", order = 0)]
public class EventInfoSO : ScriptableObject
{
    public string eventName;
    public string eventInfo;
    public List<string> selectEventInfo = new List<string>();
    public List<EventFuncSO> selectEventFunc = new List<EventFuncSO>();

}
