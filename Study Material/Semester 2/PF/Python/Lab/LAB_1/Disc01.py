"""
>>> rain = False
>>> wears_jacket(90, rain)
False
>>> wears_jacket(40, rain)
True
>>> wears_jacket(100, True)
True
"""
def wears_jacket(temp, raining):
    return raining or temp<60
"""-----------------------------------------------------------------------"""
"""
>>> handle_overflow(27, 15)
No overflow.
>>> handle_overflow(35, 29)
1 spot left in Section 2.
>>> handle_overflow(20, 32)
10 spots left in Section 1.
>>> handle_overflow(35, 30)
No space left in either section.
"""
def handle_overflow(s1, s2):
    spot=0
    if s1>29 and s2<30:
        spot = 30 - s2
        return str(spot)+' spot left in Section 2.'
    elif s2>29 and s1<30:
        spot = 30 - s1
        return str(spot)+' spot left in Section 1.'
    elif s1>29 and s2>29:
        return 'No space left in either section.'
    elif s1<30 and s2<30:
        return 'No overflow.'
"""-----------------------------------------------------------------------"""
def is_prime(n):
    if n==2 or n==3 or n==5:
        return 'Yes, It is Prime'
    elif n%2==0 or n%3==0 or n%5==0:
        return 'NOT Prime'
    else:
        return 'Yes, It is Prime'
"""-----------------------------------------------------------------------"""
"""Print out all integers 1..i..n where cond(i) is true
>>> def is_even(x):
... # Even numbers have remainder 0 when divided by 2.
... return x % 2 == 0
>>> keep_ints(is_even, 5)
2
4
"""
def is_even(x):
    return x % 2 == 0
def keep_ints(cond, n):
    total=0
    while (total<n):
        total=total+1
        if cond(total):
            print (total)
    return
"""-----------------------------------------------------------------------"""
