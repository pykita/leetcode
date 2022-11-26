class Solution:
    def generateParenthesis(self, n: int) -> List[str]:
        generated = {
            1:{
                'p_set': ['()'],
                'p_list': [['','()','']]
            }
        }
        
        for cur in range(2, n + 1):
            prev_generated_lists = generated[cur - 1]['p_list']
            p_set = set()
            p_list = []
            
            for prev_list in prev_generated_lists:
                for i in range(len(prev_list)):
                    for j in range(i, len(prev_list)):
                        new_paranthesis = [*prev_list[:i], '(' + ''.join(prev_list[i:j + 1]) + ')', *prev_list[j + 1:]]
                        joined_paranthesis = ''.join(new_paranthesis)
                        if joined_paranthesis not in p_set:
                            p_set.add(joined_paranthesis)

                            if new_paranthesis[0] != '':
                                new_paranthesis.insert(0, '')

                            if new_paranthesis[-1] != '':
                                new_paranthesis.append('')
                            p_list.append(new_paranthesis)
                    
            generated[cur] = {
                'p_set': p_set,
                'p_list': p_list
            }
            
        return generated[n]['p_set']
