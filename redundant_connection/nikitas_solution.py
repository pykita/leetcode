from collections import defaultdict


def repaint_disjoint_graph(graph, parent_node, new_weight, visited, weights):
    visited.add(parent_node)
    graph[parent_node]['weight'] = new_weight
    weights[new_weight] += 1
    for curr_node in graph[parent_node]['nodes']:
        if curr_node not in visited:
            repaint_disjoint_graph(graph, curr_node, new_weight, visited)

class Solution:
    def findRedundantConnection(self, edges: List[List[int]]) -> List[int]:
        last_redundant_edge = None
        graph = defaultdict(lambda: dict(weight=-1, nodes=[]))
        weights = defaultdict(lambda: 0)
        weight_counter = 1
        
        '''
            graph = {
                1: [2, 3],
                2: [1],
                3: [1]
            }
        '''
        
        for edge in edges:
            if graph[edge[0]]['weight'] == graph[edge[1]]['weight'] and graph[edge[0]]['weight'] != -1:
                last_redundant_edge = edge
                
            graph[edge[0]]['nodes'].append(edge[1])
            graph[edge[1]]['nodes'].append(edge[0])
            
            
            if graph[edge[0]]['weight'] == -1 and graph[edge[1]]['weight'] == -1:
                graph[edge[0]]['weight'] = graph[edge[1]]['weight'] = weight_counter
                weights[weight_counter] += 2 
                weight_counter += 1
            elif graph[edge[0]]['weight'] == -1 and graph[edge[1]]['weight'] != -1:
                graph[edge[0]]['weight'] = graph[edge[1]]['weight']
                weights[graph[edge[1]]['weight']] += 1
            elif graph[edge[0]]['weight'] != -1 and graph[edge[1]]['weight'] == -1:
                graph[edge[1]]['weight'] = graph[edge[0]]['weight']
                weights[graph[edge[0]]['weight']] += 1
            elif graph[edge[0]]['weight'] != -1 and graph[edge[1]]['weight'] != -1:
                if weights[graph[edge[0]]['weight']] > weights[graph[edge[1]]['weight']]:
                    repaint_disjoint_graph(graph, edge[1], graph[edge[0]]['weight'], set())
                    graph[edge[1]]['weight'] = graph[edge[0]]['weight']
                    weights[graph[edge[0]]['weight']] += 1
                else:
                    repaint_disjoint_graph(graph, edge[0], graph[edge[1]]['weight'], set())
                    graph[edge[0]]['weight'] = graph[edge[1]]['weight']
                    weights[graph[edge[1]]['weight']] += 1
            
                
        print(f'Verticies: {graph}')
                
        return last_redundant_edge