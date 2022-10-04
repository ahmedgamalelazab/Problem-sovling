namespace CourseScheduleII;
public class Solution
{
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        //modelling the problem 
        var preqMap = new Dictionary<int, List<int>>();
        for (int i = 0; i < prerequisites.Length; i++)
        {
            if (preqMap.ContainsKey(prerequisites[i][0]))
            {
                preqMap[prerequisites[i][0]].Add(prerequisites[i][1]);
            }
            else
            {
                preqMap.Add(prerequisites[i][0], new List<int>());
                preqMap[prerequisites[i][0]].Add(prerequisites[i][1]);
            }
        }

        var visitedList = new HashSet<int>();
        var orderList = new HashSet<int>();

        for (int i = 0; i < numCourses; i++)
        {
            if (DFS(i, preqMap, visitedList, orderList) == false) return new int[] { };
        }

        return orderList.ToArray();
    }

    public bool DFS(int vertice, Dictionary<int, List<int>> preqMap, HashSet<int> visitedList, HashSet<int> orderList)
    {

        if (visitedList.Contains(vertice))
        {
            return false;
        }

        if (!preqMap.ContainsKey(vertice))
        {
            preqMap.Add(vertice, new List<int>());
        }

        if (preqMap[vertice].Count == 0)
        {
            orderList.Add(vertice);
            return true;
        }

        visitedList.Add(vertice);

        foreach (var crs in preqMap[vertice])
        {
            if (DFS(crs, preqMap, visitedList, orderList) == false)
            {
                return false;
            }
        }

        orderList.Add(vertice);
        visitedList.Remove(vertice);
        preqMap[vertice] = new List<int>();
        return true;
    }
}
