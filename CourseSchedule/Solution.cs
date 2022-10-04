namespace CourseSchedule;

public class Solution
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        var preMap = new Dictionary<int, List<int>>();
        for (int i = 0; i < prerequisites.Length; i++)
        {
            if (preMap.ContainsKey(prerequisites[i][0]))
            {
                preMap[prerequisites[i][0]].Add(prerequisites[i][1]);
            }
            else
            {
                preMap.Add(prerequisites[i][0], new List<int>());
                preMap[prerequisites[i][0]].Add(prerequisites[i][1]);
            }
        }

        //my visitSet
        var visitSet = new HashSet<int>();

        for (int i = 0; i < numCourses; i++)
        {
            if (DFS(i, visitSet, preMap) == false)
            {
                return false;
            }
        }

        return true;

    }

    public bool DFS(int vertice, HashSet<int> visitiSet, Dictionary<int, List<int>> preMap)
    {

        if (visitiSet.Contains(vertice))
        {
            return false;
        }

        if (!preMap.ContainsKey(vertice))
        {
            preMap.Add(vertice, new List<int>());
        }
        if (preMap[vertice].Count == 0)
        {
            return true;
        }

        visitiSet.Add(vertice);

        foreach (var crs in preMap[vertice])
        {
            if (DFS(crs, visitiSet, preMap) == false) return false;
        }

        visitiSet.Remove(vertice);
        preMap[vertice] = new List<int>();
        return true;

    }

}
