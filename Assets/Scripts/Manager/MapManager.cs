using System.Collections.Generic;
using System.Text;
using UnityEngine;
public class LocationInfo
{
    public LocationInfo(int x, int y)
    {
        Init(x, y);
    }

    public void Init(int x, int y)
    {
        Index = x;
        Floor = y;
        RouteIndexs = new List<int>();
    }
    public int Index { get; private set; }
    public int Floor { get; private set; }
    public List<int> RouteIndexs { get; private set; }
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
            Map[0].Add(new LocationInfo(index, 0));
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
        Map[floor+1].Add(new LocationInfo(Util.SelectItemFromList(selectList), floor + 1));
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
