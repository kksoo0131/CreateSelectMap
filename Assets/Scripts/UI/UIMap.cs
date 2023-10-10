using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class UIMap : MonoBehaviour
{
    public int floorNumber;
    public GameObject floor;
    public GameObject root;

    public List<UIFloor> FloorList { get; private set; }

    private void Awake()
    {
        FloorList = new List<UIFloor>();
        MapManager.Instance.GenerateMapStructure(11);
    }

    private void Start()
    {
        InitMap();
    }

    public void InitMap()
    {
        for(int i=0; i< floorNumber; i++) 
        {
            GameObject go = Instantiate(floor, root.transform);
            FloorList.Add(go.GetComponent<UIFloor>());
            FloorList[i].InitFloor(i);
        }
    }
}
/*
 public int maxX, maxY, startPos;
    public float paddingX, paddingY, paddingIconX, paddingIconY;
    public GameObject EventIcon;
    
    RectTransform rectTransform;
    RectTransform iconRectTransform;

    float limitPosX, limitPosY, nowPosX, nowPosY, minSpacingX, maxSpacingX, minSpacingY, maxSpacingY;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        iconRectTransform = EventIcon.GetComponent<RectTransform>();
        UIMapInit();
    }

    public void UIMapInit()
    {
        MapManager.Instance.GenerateMap(maxX, maxY, startPos);

        limitPosX = rectTransform.rect.width / 2 - paddingX - (iconRectTransform.rect.width/2);
        limitPosY = rectTransform.rect.height / 2 - paddingY - (iconRectTransform.rect.height/2);

        minSpacingX = iconRectTransform.rect.width * 2;
        maxSpacingX = limitPosX * 2 / maxX;
        minSpacingY = iconRectTransform.rect.height * 2;
        maxSpacingY = limitPosY * 2 / maxY;

        nowPosX = -limitPosX;
        nowPosY = -limitPosY;
    }

    public void LimitPos(ref float x, ref float y)
    {
        x = x < -limitPosX ? -limitPosX : x;
        x = x > limitPosX ? limitPosX : x;
        y = y < -limitPosY ? -limitPosY : y;
        y = y > limitPosY ? limitPosY : y; 
    }


    private void Start()
    {
        for (int i =0; i< maxY; i++)
        {
            List<EventIcon> thisFloor = MapManager.Instance.Map[i];

            for (int j = 0; j< thisFloor.Count; j++)
            {
                LimitPos(ref nowPosX, ref nowPosY);
                thisFloor[j].transform.localPosition =  new Vector3(nowPosX, nowPosY, 0);
                nowPosX += Random.Range(minSpacingX, maxSpacingX);
            }
            nowPosX = -limitPosX;
            nowPosY += Random.Range(minSpacingY, maxSpacingY);
        }
    }
 */