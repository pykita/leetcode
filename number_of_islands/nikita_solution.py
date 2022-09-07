from collections import namedtuple
from typing import List

Point = namedtuple('Point', ['x', 'y'])

directions = [Point(-1, 0), Point(1, 0), Point(0, -1), Point(0, 1)]

def is_within_range(point: Point, grid: List[List[str]]) -> bool:
    MAX_Y = len(grid) - 1
    MAX_X = len(grid[0]) - 1
    
    return point.x >= 0 and point.x <= MAX_X and point.y >= 0 and point.y <= MAX_Y

def get_possible_directions(current_point: Point, grid: List[List[str]], banned_points: set[Point]) -> set[Point]:
    possible_directions = set[Point]()
    
    for direction in directions:
        new_point = Point(x=current_point.x + direction.x, y=current_point.y + direction.y)
        
        if new_point not in banned_points and is_within_range(new_point, grid):
            possible_directions.add(new_point)
            
    return possible_directions

class Solution:
    def numIslands(self, grid: List[List[str]]) -> int:
        island_counter = 0
        islands_points = set[Point]()
        
        def outline_island(point: Point) -> None:
            if point in islands_points:
                return
            
            queue = [point]
            islands_points.add(point)
            
            while queue:
                curr_point = queue.pop(0)
                possible_directions = get_possible_directions(curr_point, grid, islands_points)
                
                island_directions = list(filter(lambda p: grid[p.y][p.x] == "1", possible_directions))
                
                
                if island_directions:
                    queue.extend(island_directions)
                    islands_points.update(island_directions)
                
        for row_idx, row in enumerate(grid):
            for cell_idx, cell in enumerate(row):
                curr_point = Point(x=cell_idx, y=row_idx)
                
                if cell == "1" and curr_point not in islands_points:
                    island_counter += 1
                    outline_island(curr_point)
                    
        return island_counter
                    
            