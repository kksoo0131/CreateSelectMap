using System.Collections.Generic;
using System.Text;
using UnityEngine;
public class LocationInfo
{
    public LocationInfo(int x, int y, EventType type)
    {
        Init(x, y, type);
    }

    public void Init(int x, int y, EventType type)
    {
        Index = x;
        Floor = y;
        RouteIndexs = new List<int>();
        EventType = type;
    }
    public int Index { get; private set; }
    public int Floor { get; private set; }
    public List<int> RouteIndexs { get; private set; }
    public RectTransform rectTransform { get; set; }

    public EventType EventType { get; private set; }

    public EventInfoSO EventInfoSO { get; private set; }
}
public class MapManager : Singleton<MapManager>
{
    int maxXIndex = 10;
    int maxYIndex;

    int minX = 3;
    int maxX = 5;

    public List<LocationInfo>[] Map { get; private set; }

    public int[] moveable = { -1, 0, 1 };
    public void GenerateMapStructure(int floorNumber)
    {
        if (Map != null) return;

        Init(floorNumber);

        for( int i =1; i< maxYIndex; i++)
        {
            Map[i] = new List<LocationInfo>();

            int[] Possibility = RouteCountThisFloor(Map[i-1]);

            foreach (LocationInfo location in Map[i-1])
            {
                SelectRoute(location, Possibility);
                // 다음지역 중 하나를 선택한다.
            }
        }

    }

    public void CheckDebugMap()
    {
        StringBuilder sb = new StringBuilder();

        foreach (List<LocationInfo> floor in Map)
        {
            int start = 0;
            foreach (LocationInfo location in floor)
            {
                for (int i = start; i < location.Index; i++)
                {
                    sb.Append(-1);
                }
                sb.Append(location.Index);
                start = location.Index + 1;
            }

            for (int i = start; i < maxXIndex; i++)
            {
                sb.Append(-1);
            }

            sb.AppendLine();
        }

        Debug.Log(sb.ToString());
    }
    public void Init(int floorNumber)
    {
        maxYIndex = floorNumber;
        Map = new List<LocationInfo>[maxYIndex];
        Map[0] = new List<LocationInfo>();

        int choice = UnityEngine.Random.Range(minX, maxX+1);

        foreach(int index in Util.SelectNumber(0, maxXIndex, choice))
        {
            EventType type = (EventType)Random.Range(0, (int)EventType.EndPoint);
            Map[0].Add(new LocationInfo(index, 0, type));
        }
    }

    public int[] RouteCountThisFloor(List<LocationInfo> floor)
    {
        // 이전층의 List를 floor로 받아왔음 지금
        int[] possibleRoute = new int[maxXIndex];

        foreach(LocationInfo location in floor)
        {
            int index = location.Index;

            possibleRoute[index]++;

            if (index - 1 >= 0)
            {
                possibleRoute[index - 1]++;
            }

            if (index + 1 < maxXIndex)
            {
                possibleRoute[index + 1]++;
            }
        }
        return possibleRoute;
    }

    public void SelectRoute(LocationInfo location, int[] possibility)
    {
        int index = location.Index;
        int floor = location.Floor;
        List<int> selectList = new List<int>();

        foreach (int move in moveable)
        {
            int nextX = index + move;
            if (CheckXPos(nextX))
            {
                AddSelectList(selectList, possibility, nextX);
            }
        }

        int nextIndex = Util.SelectItemFromList(selectList);
        EventType type = (EventType)Random.Range(0, (int)EventType.EndPoint);
        Map[floor+1].Add(new LocationInfo(nextIndex, floor + 1,type));
        // 이때 시작점에도 추가해준다.
        location.RouteIndexs.Add(Map[floor+1].Count-1);
    }

    public bool CheckXPos(int x)
    {
        if (x < 0 || x >= maxXIndex)
        {
            return false;
        }
        return true;
    }

    public void AddSelectList(List<int> selectList, int[] possiblity, int x )
    {
        switch (possiblity[x])
        {
            case 1:
                for(int i =0; i< 3; i++)
                {
                    selectList.Add(x);
                }
                break;
            case 2:
                selectList.Add(x);
                break;
            default:
                break;
        }
    }

   
}
