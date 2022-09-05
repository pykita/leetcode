public class Solution {

    public bool CanJump(int[] nums) {

        return CanJumpInternal(nums, 0, 0);

    }

   

    private bool CanJumpInternal(int[] arr, int currentIndex, int b)

    {

        if (currentIndex < 0)

            return false;


        if (arr[currentIndex] <= b)

            if(arr.Length == 1)

                return true;

            else

                return CanJumpInternal(arr, currentIndex - 1, ++b);


        if (currentIndex + arr[currentIndex] + 1 >= arr.Length)

            return true;

           

        return CanJumpInternal(arr, currentIndex + arr[currentIndex], 0);

    }

}