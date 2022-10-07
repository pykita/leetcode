import math
from collections import namedtuple

Point = namedtuple('Point', ['x', 'y'])

def get_all_routes(grid, curr_cell, visited, elim_points) -> List[tuple[Point, int]]:
    directions = [Point(-1, 0), Point(1, 0), Point(0, -1), Point(0, 1)]
    max_y = len(grid) - 1
    max_x = len(grid[0]) - 1
    routes = []

    for direction in directions:
        new_cell = Point(curr_cell.x + direction.x, curr_cell.y + direction.y)

        if new_cell.x <= max_x and \
            new_cell.x >= 0 and \
            new_cell.y <= max_y and \
            new_cell.y >= 0 and \
            new_cell not in visited and \
            (grid[new_cell.y][new_cell.x] == 0 or \
            (grid[new_cell.y][new_cell.x] == 1 and elim_points > 0)):

            # print(f'New cell added: {new_cell} with visited: {visited}')
            new_elim_points = elim_points - 1 if grid[new_cell.y][new_cell.x] == 1 else elim_points
            routes.append((new_cell, new_elim_points))

    # print(f'Returned routes: {routes}')

    return routes



class Solution:
    def shortestPath(self, grid: List[List[int]], k: int) -> int:
        start_point = Point(0, 0)
        end_point = Point(len(grid[0]) - 1, len(grid) - 1)
        queue = [(start_point, 0, k)]
        min_path = math.inf

        while queue:
            curr_cell, curr_path, elim_points = queue.pop(0)
            if curr_cell == end_point:
                return curr_path
                # min_path = min(curr_path, min_path)
            else:
                possible_routes = get_all_routes(grid, curr_cell, visited, elim_points)
                for route, elim_points in possible_routes:
                    new_visited = visited.copy()
                    new_visited.add(route)
                    queue.append((route, curr_path + 1, elim_points, new_visited))
        
        return -1 if min_path == math.inf else int(min_path)