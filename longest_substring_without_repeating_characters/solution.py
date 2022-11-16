class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        start, end = 0, 0
        unique = set()
        longest_substring = 0
        
        while end < len(s):
            if s[end] not in unique:
                longest_substring = max(end - start + 1, longest_substring)
            else:
                while start < end:
                    unique.remove(s[start])
                    start += 1
                    if s[start - 1] == s[end]:
                        break
            unique.add(s[end])
            end += 1
            
        return longest_substring
