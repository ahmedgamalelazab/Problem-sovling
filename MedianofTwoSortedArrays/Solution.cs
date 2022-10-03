namespace MedianofTwoSortedArrays;
public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {

        if (nums1.Length > nums2.Length)
        {
            return FindMedianSortedArrays(nums2, nums1);
        }

        int x = nums1.Length;
        int y = nums2.Length;

        int low = 0;
        int high = x;

        while (low <= high)
        {

            //partitioning the x
            int partitionX = (low + high) / 2;
            //partitioning the y 
            int partitionY = (x + y + 1) / 2 - partitionX;
            //left side x
            int maxLeftX = (partitionX == 0) ? int.MinValue : nums1[partitionX - 1];
            //right side x
            int minRightX = (partitionX == x) ? int.MaxValue : nums1[partitionX];
            //left side y 
            int maxLeftY = (partitionY == 0) ? int.MinValue : nums2[partitionY - 1];
            //right side y
            int minRightY = (partitionY == y) ? int.MaxValue : nums2[partitionY];

            if (maxLeftX <= minRightY && maxLeftY <= minRightX)
            {
                if ((x + y) % 2 == 0)
                {
                    //even case
                    return ((double)Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY)) / 2;
                }
                else
                {
                    //odd case 
                    return (double)Math.Max(maxLeftX, maxLeftY);
                }
            }
            else if (maxLeftX > minRightY)
            {
                high = partitionX - 1;
            }
            else
            {
                low = partitionX + 1;
            }


        }

        throw new Exception("something went wrong");
    }


}
