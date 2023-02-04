class Solution:
    def numDecodings(self, s: str) -> int:
        letter_map = {str(i): chr(i+96) for i in range(1,27)}
        # print(letter_map)
        visited = {}
        
        def get_paths(idx: int) -> int:
            # print(f'Called with {idx}')
            if idx in visited:
                return visited[idx]
            
            if idx >= len(s):
                return 1

            res = 0
            next_char_idx = idx + 1
            
            if s[idx] in letter_map:
                res += get_paths(next_char_idx)
                
                if next_char_idx < len(s) and s[idx: next_char_idx + 1] in letter_map:
                    res += get_paths(next_char_idx + 1)
                    
                    
            visited[idx] = res
            return res
        
        return get_paths(0)
