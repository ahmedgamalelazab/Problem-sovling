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

        ListNode head = new ListNode(-1);
        ListNode p = head;

        while (list1 != null && list2 != null)
        {

            if (list1.val < list2.val)
            {
                p.next = new ListNode(list1.val);
                list1 = list1.next;
                p = p.next;

            }
            else
            {
                p.next = new ListNode(list2.val); ;
                list2 = list2.next;
                p = p.next;
            }

        }

        if (list1 != null || list2 != null)
        {
            if (list1 != null)
            {
                p.next = list1;
            }
            else
            {
                p.next = list2;
            }
        }


        return head.next;
    }
}