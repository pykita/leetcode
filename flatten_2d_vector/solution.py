class Vector2D:
    
    def get_to_next(self):
        while self.curr_x >= self.len_x and self.curr_y < self.len_y:
            self.curr_y += 1
            if self.curr_y < self.len_y:
                self.curr_x = 0
                self.len_x = len(self.vec[self.curr_y])

    def __init__(self, vec: List[List[int]]):
        self.vec = vec
        self.len_y = len(vec)
        self.len_x = len(vec[0]) if len(vec) else 0
        self.curr_x = 0
        self.curr_y = 0
        self.get_to_next()
        

    def next(self) -> int:
        next_item = self.vec[self.curr_y][self.curr_x]
        
        self.curr_x += 1
        self.get_to_next()
            
        return next_item

    def hasNext(self) -> bool:
        has_next = not (self.curr_y + 1 >= self.len_y and self.curr_x >= self.len_x)
        return has_next
