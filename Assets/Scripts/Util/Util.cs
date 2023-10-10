using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Util
{
    public static List<int> SelectNumber(int start, int end, int select)
    {
        List<int> ints = new List<int>();
        int count = end - start;

        for (int i = start; i < count; i++)
        {
            ints.Add(i);
        }

        for (int i = 0; i < count - select; i++)
        {
            int randInt = Random.Range(0, ints.Count);
            ints.RemoveAt(randInt);
        }

        return ints;

    }

    public static List<int> SelectIndex<T>(List<T> list, int select)
    {
        List<int> ints = new List<int>();

        for (int i = 0; i < list.Count; i++)
        {
            ints.Add(i);
        }

        for (int i =0; i <list.Count -select; i++)
        {
            int randInt = Random.Range(0, ints.Count);
            ints.RemoveAt(randInt);
        }

        return ints;
    }
    public static List<T> SelectItemsFromList<T>(List<T> list, int select)
     {
        // list에서 select개의 요소롤 선택해 list를 return한다.

        List<int> ints = new List<int>();
        List<T> returnList = new List<T>();

        for (int i = 0; i < list.Count; i++)
        {
            ints.Add(i);
        }

        for (int i = 0; i < select; i++)
        {
            int randInt = Random.Range(0, ints.Count);
            int selectedIndex = ints[randInt];

            returnList.Add(list[selectedIndex]);
            ints.RemoveAt(randInt);
            
        }

        return returnList;
        
    }

    public static T SelectItemFromList<T>(List<T> list)
    {
        
        int randInt = Random.Range(0, list.Count);
        return list[randInt];
    }

    public static void RemoveRandomItemsFromList(List<int> list,int number)
    {
        for(int i=0; i< number; i++)
        {
            int randInt = Random.Range(0, list.Count);
            list.RemoveAt(randInt);
        }
        
    }
}