namespace mergeTwoSortedLinkedList;


public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
public class Solution
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {

        //check for nulls
        if (list1 == null && list2 == null)
        {
            return null;
        }
        if (list1 == null)
        {
            return list2;
        }
        else if (list2 == null)
        {
            return list1;
        }
        else
        {

            var p1 = new ListNode(0, list1);
            var p2 = new ListNode(0, list2);

            while (p1.next != null && p2.next != null)
            {
                if (p1.next.val <= p2.next.val)
                {
                    var p1Temp = p1.next.next;
                    var p2Temp = p2.next.next;
                    p2.next.next = p1.next.next;
                    p1.next.next = p2.next;
                    p1.next = p1Temp;
                    p2.next = p2Temp;
                }
                else
                {
                    var p1Temp = p1.next.next;
                    var p2Temp = p2.next.next;
                    p2.next.next = p1.next;
                    var pFix = new ListNode(0, list1);
                    if (pFix.next.next == null)
                    {
                        list1 = p2.next;
                        p1 = new ListNode(0, list1);
                        p1Temp = p1.next;
                    }
                    else
                    {
                        while (pFix.next.next != p1.next)
                        {
                            pFix = pFix.next;
                        }
                        pFix.next.next = p2.next;

                    }
                    p1.next = p1Temp;
                    p2.next = p2Temp;
                }
            }

            return list1;

        }

    }
}