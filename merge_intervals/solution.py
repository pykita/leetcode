# not solved but I was close
# The solution looks too complicated - I might be doing something wrong here

class Solution:
    def merge(self, intervals: List[List[int]]) -> List[List[int]]:
        final_list = [intervals[0]]
        
        def is_merged(original_pair, cand_pair):
            # print(f'Is merging {original_pair} and {cand_pair}?')
            if original_pair[0] <= cand_pair[0] <= original_pair[1] or \
                original_pair[0] <= cand_pair[1] <= original_pair[1] or \
                cand_pair[0] <= original_pair[0] <= cand_pair[1] or \
                cand_pair[0] <= original_pair[1] <= cand_pair[1]:
                original_pair[0], original_pair[1] = min(cand_pair[0], original_pair[0]), max(cand_pair[1], original_pair[1])
                # print('Yes!')
                return True
            else:
                # print('No!')
                return False
        
        
        def merge_sorted(merge_list, pair):
            def find_insert_index(m_l, num):
                start, end = 0, len(m_l) - 1
                while start != end:
                    m_idx = (end - start + 1) // 2 + start
                    m_val = m_l[m_idx]
                    if m_val[0] <= num <= m_val[1]:
                        return m_idx
                    elif num < m_val[0]:
                        end = max(m_idx - 1, start)
                    elif m_val[1] < num:
                        start = min(m_idx + 1, end)
                print(f'Searching for {num} in {m_l} found {start}')
                        
                insert_idx = start + 1 if num > m_l[1] else start
                return insert_idx
            first_idx, second_idx = find_insert_index(merge_list, pair[0]), find_insert_index(merge_list, pair[1])
            if first_idx == second_idx:
                insert_idx = first_idx
                insert_val = merge_list[insert_idx]

                if len(merge_list) > insert_idx and is_merged(insert_val, pair):
                    return 

                merge_list.insert(insert_idx, pair)
            else:
                # this part needs to be tested
                print(f'Deleting from {second_idx + first_idx} to {first_idx} and the curr arr is {merge_list}')
                first_to_del, last_to_del = second_idx + first_idx + 1 if pair[0] > merge_list[second_idx + first_idx][1] else second_idx + first_idx, first_idx - 1 if pair[1] < merge_list[first_idx - 1][1]
                for i in range(second_idx + first_idx, first_idx - 1, -1):
                    is_merged(pair, merge_list[i])
                    del merge_list[i]
                    
                merge_list.append(pair)
                
        for interval_idx in range(1, len(intervals)):
            merge_sorted(final_list, intervals[interval_idx])
            
        return final_list
