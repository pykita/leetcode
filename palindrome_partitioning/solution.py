class Solution:
    def partition(self, s: str) -> List[List[str]]:
        visited = {}

        def search_for_poli(s):
            if s in visited:
                return visited[s]
            output = [[c for c in s]]
            added = set()
            added.add(tuple(c for c in s))

            pivot = 0

            def split_and_search(s, start, end):
                if s in visited:
                    return visited[s]
                output = []
                left = search_for_poli(s[:start])
                right = search_for_poli(s[end + 1:])
                for l in left:
                    for r in right:
                        print(l, [s[start:end + 1]], r)
                        output.append(l + [s[start:end + 1]] + r)
                return output

            while pivot < len(s):
                start = end = pivot
                while end + 1 < len(s) and s[start] == s[end + 1]:
                    end += 1
                    rest = split_and_search(s, start, end)
                    for r in rest:
                        if tuple(r) not in added:
                            output.append(r)
                            added.add(tuple(r))
                radius = 1
                left_border, right_border = start - radius, end + radius
                while left_border >= 0 and \
                 right_border < len(s) and \
                 s[left_border] == s[right_border]:
                    rest = split_and_search(s, left_border, right_border)
                    for r in rest:
                        if tuple(r) not in added:
                            output.append(r)
                            added.add(tuple(r))
                    radius += 1
                    left_border, right_border = start - radius, end + radius
                pivot += 1

            visited[s] = output
            return output
        


        return search_for_poli(s)
