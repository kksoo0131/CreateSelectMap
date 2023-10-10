using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class UIMap : MonoBehaviour
{
    public int floorNumber;
    public GameObject root;
    public GameObject icon;
    public GameObject route;

    private void Start()
    {
        InitMap();
    }

    public void InitMap()
    {
        MapManager.Instance.GenerateMapStructure(floorNumber);
        DrawMap();
        DrawRoute();
    }

    public void DrawMap()
    {
        for (int i = 0; i < floorNumber; i++)
        {
            DrawIcon(MapManager.Instance.Map[i], -440 + 880 / floorNumber * i);
            // 맵 root의 길이 760 880
            // 880 / 11 한층의 높이 80
        }

    }

    public void DrawIcon(List<LocationInfo> floor, float y)
    {
        foreach (LocationInfo location in floor)
        {
            GameObject go = Instantiate(icon, root.transform);
            go.transform.localPosition = new Vector3(-380 + 20 + 720 / 9 * location.Index, y, 0);
            location.rectTransform = go.GetComponent<RectTransform>();
        }
        
        // -380 == floor의길이 / 2 * -1
        // +20 == icon의 width / 2
        // 720 == floor의 길이 - icon의 width
        // 최대 인덱스 0 ~ 9
        // info.Index 현재 인덱스
        // 놓아도 되는 범위는? -360 ~ 360 여기에 10개까지 들어간다.
    }

    public void DrawRoute()
    {
        for(int i =0; i < floorNumber-1; i++)
        {
            foreach(LocationInfo location in MapManager.Instance.Map[i])
            {
                int nextIndex = location.RouteIndexs[0];
                Vector3 start = location.rectTransform.position;
                Vector3 end = MapManager.Instance.Map[i + 1][nextIndex].rectTransform.position;
                Vector3 direction = (end - start).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) *Mathf.Rad2Deg;

                Instantiate(route, (start+end) / 2f, Quaternion.Euler(0,0,angle), root.transform);

            }
        }
        
    }
    
}