using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class UIFloor : MonoBehaviour
{
    public GameObject select;
    int floorNumber;

    public List<UISelect> SelectList { get; private set; }

    private void Awake()
    {
        SelectList = new List<UISelect>();
    }

    private void Start()
    {
        
    }
    public void InitFloor(int floor)
    {
        List<LocationInfo> InfoArray = MapManager.Instance.Map[floor];

        for (int i =0; i< InfoArray.Count; i++) 
        {
            if (InfoArray[i] == null) continue;

            GameObject go = Instantiate(select, transform);
            UISelect _uiselect = go.GetComponent<UISelect>();
            SelectList.Add(_uiselect);
            _uiselect.InitSelect(InfoArray[i]);
        }
    }
}