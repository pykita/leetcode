class Solution:
    def evalRPN(self, tokens: List[str]) -> int:
        stack = []
        sign_map = {
            '+': lambda first, second: first + second,
            '-': lambda first, second: first - second,
            '*': lambda first, second: first * second,
            '/': lambda first, second: int(first / second),
        }
        
        for token in tokens:
            if token not in sign_map:
                stack.append(int(token))
            else:
                second, first = stack.pop(), stack.pop()
                print(f'Second, first, sign: {first, second, token}')
                result = sign_map[token](first, second)
                stack.append(result)
                
        return stack.pop()
