from collections import defaultdict
from typing import List

class Solution:
    def calcEquation(self, equations: List[List[str]], values: List[float], queries: List[List[str]]) -> List[float]:
        '''
            so this is easy-peasy: 
            1) we build a graph
            2) we search through it
        '''
        
        # equ_graph = {
        #     'a': {'b': 2},
        #     'b': {'c': 3, 'a':0.5 },
        #     'c': {'b': 0.33333 }
        # }
        equ_graph = defaultdict(dict)
        
        for idx, equation in enumerate(equations):
            equ_graph[equation[0]][equation[1]] = values[idx]
            equ_graph[equation[1]][equation[0]] = 1 / values[idx]
            
            
        def find_ratio(curr_name: str, search_node_name: str):
            if curr_name in visited:
                return None

            visited.add(curr_name)

            if search_node_name in equ_graph[curr_name]:
                return equ_graph[curr_name][search_node_name]

            for key, curr_ration in equ_graph[curr_name].items():
                ratio = find_ratio(key, search_node_name)
                if ratio:
                    return ratio * curr_ration

            return None

        results = []
        
        visited = set()

        for query_pair in queries:
            result = find_ratio(query_pair[0], query_pair[1])

            results.append(result if result else -1.0)
            visited.clear()

        return results
                
            