guidPossibilities = 2 ** 128

def getGuidNoCollisionOdds(numGuids: int) -> float:
    out = 1
    for i in range(999_999_999_999_999_990_000_000, numGuids): # starting with the big numbers to save time.
        j = (guidPossibilities - i)/guidPossibilities
        out *= j
    
    print(out)
    return 1 - out


print(guidPossibilities)
# getGuidNoCollisionOdds(1) # 1.0
# getGuidNoCollisionOdds(10) # 1.0
# getGuidNoCollisionOdds(1000) # 1.0
getGuidNoCollisionOdds(1000_000_000_000_000_000_000_000) # 0.9999999711342014 <- the odds of it NOT happening