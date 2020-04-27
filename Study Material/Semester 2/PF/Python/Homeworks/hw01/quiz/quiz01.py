def multiple(a, b):
    """Return the smallest number n that is a multiple of both a and b.

    >>> multiple(3, 4)
    12
    >>> multiple(14, 21)
    42
    """
    n = min(a, b)
    while not (a % n == 0 and b % n == 0):
        n -= 1
    return (min(a, b)/n) * max(a, b) 
    

def unique_digits(n):
    """Return the number of unique digits in positive integer n

    >>> unique_digits(8675309) # All are unique
    7
    >>> unique_digits(1313131) # 1 and 3
    2
    >>> unique_digits(13173131) # 1, 3, and 7
    3
    >>> unique_digits(10000) # 0 and 1
    2
    >>> unique_digits(101) # 0 and 1
    2
    >>> unique_digits(10) # 0 and 1
    2
    """
    def has_digit(x, d):
        while x > 0:
            if x % 10 == d:
                return True
            else:
                x = x // 10
        return False

    counter = 0
    while n > 0:
        last, rest = n % 10, n // 10
        if not has_digit(rest, last):
            counter += 1
        n = n // 10
    return counter
