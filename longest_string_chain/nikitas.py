from typing import List

def get_all_predecessors(word: str) -> List[str]:
    possible_predecessors = []
    for idx, ch in enumerate(word):
        candidate = word[:idx] + word[idx + 1:]
        if candidate:
            # print(f'the candidate: {candidate}')
            possible_predecessors.append(candidate)
    return possible_predecessors

class Solution:
    def longestStrChain(self, words: List[str]) -> int:
        
        ordered_words = sorted(words, key=lambda x: len(x))
        
        children_chain = {}
        longest_chain_count = 0
        
        for word in ordered_words:
            predecessors = get_all_predecessors(word)
            
            for predecessor in predecessors:
                if predecessor in children_chain:
                    new_chain = children_chain[predecessor][:]
                    new_chain.append(word)
                    longest_chain_count = max(len(new_chain), longest_chain_count)
                    if word in children_chain:
                        children_chain[word] = new_chain if len(new_chain) > len(children_chain[word]) else children_chain[word]
                    else:
                        children_chain[word] = new_chain
                    
            if not word in children_chain:
                children_chain[word] = [[word]]
                longest_chain_count = max(1, longest_chain_count)
                
        return longest_chain_count
                