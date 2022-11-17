class Solution:
    def lengthOfLIS(self, nums: List[int]) -> int:
        increasing_seqs = []
        max_seq_number = 0
        
        for val in nums:
            max_for_val = 1
            for seq in increasing_seqs:
                if val > seq['latest']:
                    max_for_val = max(seq['count'] + 1, max_for_val)
                    
            increasing_seqs.append({'latest':val, 'count': max_for_val})
            max_seq_number = max(max_for_val, max_seq_number)

        return max_seq_number
