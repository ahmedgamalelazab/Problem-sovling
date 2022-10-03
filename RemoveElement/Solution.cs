
namespace RemoveElement;

public class Solution
{
    public int RemoveElement(int[] nums, int val)
    {

        var cleanItems = new List<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                cleanItems.Add(nums[i]);
            }
        }

        for (int i = 0; i < cleanItems.Count; i++)
        {
            nums[i] = cleanItems[i];
        }

        return cleanItems.Count;


    }
}