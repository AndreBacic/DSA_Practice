def BFS(root, target) -> int:
    """
    root and target are Nodes of some type
    """

    queue = [root]
    visited = [root]
    step = 0

    while (len(queue) > 0):
        step += 1
        size = len(queue)
        for i in range(size):
            current = queue.pop(0)
            if current == target:
                return step
            for child in current.children:
                if child not in visited:
                    queue.append(child)
                    visited.append(child)
            
    return -1