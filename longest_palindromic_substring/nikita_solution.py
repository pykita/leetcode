class Solution:
    def longestPalindrome(self, s: str) -> str:
        longest_palindrome = current_palindrome = [s[0]]
        prev_idx = 0
        
        for curr_idx in range(1, len(s)):
            if s[prev_idx] == s[curr_idx]:
                current_palindrome.append(s[curr_idx])
                continue
            else:
                left, right = prev_idx - 1, curr_idx
                while left >= 0 and right <= len(s) - 1:
                    if s[left] == s[right]:
                        current_palindrome.append(s[right])
                        current_palindrome.insert(0, s[left]) # could be optimised with precreated list of len(s)
                        left -= 1
                        right += 1
                    else:
                        break
                prev_idx = curr_idx
                if len(current_palindrome) > len(longest_palindrome):
                    longest_palindrome = current_palindrome
                current_palindrome = [s[curr_idx]]
                
        if len(current_palindrome) > len(longest_palindrome):
            longest_palindrome = current_palindrome
                
            
            
                
        return ''.join(longest_palindrome)