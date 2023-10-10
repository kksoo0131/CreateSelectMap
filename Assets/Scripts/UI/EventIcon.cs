using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventIcon : MonoBehaviour
{
    int indexX;
    int indexY;
    public List<RectTransform> root;
    public List<EventIcon> nextFloorList;

    private void Awake()
    {
        nextFloorList = new List<EventIcon>();
    }



    // ���� �ɶ� �� ��ġ�� ���� �����ִ� ��ġ�� �˾ƾߵ�.

    // �׷��� �ش���ġ�� root�� ȸ��������.

    public void Init(int y, int x)
    {
        indexY = y;
        indexX = x;

        for(int i =0; i <nextFloorList.Count; i++) 
        {
            root[i].gameObject.SetActive(true);
            RectTransform rectTransform = nextFloorList[i].GetComponent<RectTransform>();

            Vector2 direction = root[i].InverseTransformDirection(rectTransform.position - root[i].position).normalized;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            root[i].eulerAngles = new Vector3(0, 0, angle);
        }

        
    }

}
