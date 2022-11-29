class Solution:
    def uniquePaths(self, m: int, n: int) -> int:
        visited = {}
        
        def get_prev(visited, m, n, steps):
            new_points = [(m-1, n), (m, n-1)]
            total_steps = 0
            
            for point in new_points:
                
                if point not in visited:
                    if point[0] >= 0 and point[1] >= 0:
                        total_steps += max(1, get_prev(visited, point[0], point[1], steps + 1))
                else:
                    total_steps += max(1, visited[point])
                    
               
            visited[(m,n)] = total_steps
                    
            return total_steps
        
        return max(1, get_prev(visited, m - 1, n - 1, 0))
        
        