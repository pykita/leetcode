from collections import namedtuple
from typing import List

Point = namedtuple('Point', ['x', 'y'])

directions = [Point(-1, 0), Point(1, 0), Point(0, -1), Point(0, 1)]

def is_within_range(point: Point, grid: List[List[str]]) -> bool:
    MAX_Y = len(grid) - 1
    MAX_X = len(grid[0]) - 1
    
    return point.x >= 0 and point.x <= MAX_X and point.y >= 0 and point.y <= MAX_Y

class Solution:
    def numIslands(self, grid: List[List[str]]) -> int:
        island_counter = 0
        
        def outline_island(point: Point) -> None:
            queue = [point]
            grid[point.y][point.x] = 0
            
            while queue:
                curr_point = queue.pop(0)
                for direction in directions:
                    new_point = Point(x=curr_point.x + direction.x, y=curr_point.y + direction.y)

                    if is_within_range(new_point, grid) and grid[new_point.y][new_point.x] == "1":
                        grid[new_point.y][new_point.x] = 0
                        queue.append(new_point)

                
        for row_idx, row in enumerate(grid):
            for cell_idx, cell in enumerate(row):
                cell_point = Point(x=cell_idx, y=row_idx)
                
                if cell == "1":
                    island_counter += 1
                    outline_island(cell_point)
                    
        return island_counter
                    
            