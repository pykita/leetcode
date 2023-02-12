from collections import namedtuple

Point = namedtuple("Point", 'x y')

class Solution:
    def is_out_of_matrix(self, point, matrix):
        return point.y < 0 or point.y >= len(matrix) or point.x < 0 or point.x >= len(matrix[0])
    
    def is_valid(self, point: Point, matrix: List[List[int]], visited):
        return point not in visited and not self.is_out_of_matrix(point, matrix)
    
    def get_next_point(self, point: Point, directions, direction_index):
        return Point(x=point.x + directions[direction_index % len(directions)].x, y=point.y + directions[direction_index % len(directions)].y)   
        
        
    def spiralOrder(self, matrix: List[List[int]]) -> List[int]:
        visited = set()
        directions = [Point(x=1,y=0),Point(x=0,y=1), Point(x=-1,y=0), Point(x=0,y=-1)]
        direction_index = 0
        result = []
        
        current_point = Point(0,0)
        for i in range(len(matrix)*len(matrix[0])):
            visited.add(current_point)
            result.append(matrix[current_point.y][current_point.x])
            
            next_point = self.get_next_point(current_point, directions, direction_index)
        
            if not self.is_valid(next_point, matrix, visited):
                direction_index += 1
                next_point = self.get_next_point(current_point, directions, direction_index)
                
            current_point = next_point
            # we should just never appear in a situation when there is no place to go
            # because there is exactly M x N moves
                
        return result
                