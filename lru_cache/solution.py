class DoubleLinkedNode:
    def __init__(self):
        self.key = 0
        self.value = 0
        self.prev = None
        self.next = None

class LRUCache:

    def __init__(self, capacity: int):
        self.capacity = capacity
        self.size = 0
        self.cache = {}
        self.head = DoubleLinkedNode()
        self.tail = DoubleLinkedNode()
        self.head.next = self.tail
        self.tail.prev = self.head
        
    def _delete_node(self, node):
        node.prev.next = node.next
        node.next.prev = node.prev
        
    def _add_node(self, node):
        node.next = self.tail
        node.prev = self.tail.prev
        self.tail.prev.next = node
        self.tail.prev = node
        
    def _move_to_tail(self, node):
        # Remove old links to the node
        self._delete_node(node)
        
        # Add new links to the node
        self._add_node(node)

    def get(self, key: int) -> int:
        if key not in self.cache:
            return -1
        
        # Get the node
        node = self.cache[key]
        
        self._move_to_tail(node)
        
        return node.value
        

    def put(self, key: int, value: int) -> None:
        # add new node
        if key not in self.cache:
            new_node = DoubleLinkedNode()
            new_node.key = key
            new_node.value = value
            self.cache[key] = new_node

            self._add_node(new_node)

            if self.size >= self.capacity:
                # remove node
                rem_node = self.head.next
                self._delete_node(rem_node)
                del self.cache[rem_node.key]
            else:
                self.size += 1
        else:
            self.cache[key].value = value
            self._move_to_tail(self.cache[key])


# Your LRUCache object will be instantiated and called as such:
# obj = LRUCache(capacity)
# param_1 = obj.get(key)
# obj.put(key,value)
