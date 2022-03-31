class Solution(object):
    def reorderLogFiles(self, logs):
        """
        :type logs: List[str]
        :rtype: List[str]
        """
        dig_logs = []
        letter_logs = []

        for l in logs:
            if l.split()[1].isdigit():
                dig_logs.append(l)
            else:
                letter_logs.append(l)
        
        letter_logs.sort(key=lambda x: (x.split()[1:], x.split()[0]))

        output = letter_logs + dig_logs
        return output


s = Solution()
print(s.reorderLogFiles(["dig1 8 1 5 1", "let1 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero"]))
# ["let1 art can","let3 art zero","let2 own kit dig","dig1 8 1 5 1","dig2 3 6"]
print(s.reorderLogFiles(["a1 9 2 3 1","g1 act car","zo4 4 7","ab1 off key dog","a8 act zoo"]))
# ["g1 act car","a8 act zoo","ab1 off key dog","a1 9 2 3 1","zo4 4 7"]