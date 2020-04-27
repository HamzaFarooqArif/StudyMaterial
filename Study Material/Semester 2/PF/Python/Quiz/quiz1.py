#Q1
"""
>>> count_digits(26348222, 2)
4
>>> count_digits(1112, 3)
0
>>> count_digits(32111, 1)
3
"""
def count_digits(n, d):
    if n <= 0:
        return 0
    if d == n % 10:
        return 1 + count_digits(n // 10, d)
    else:
        return count_digits(n // 10, d)
    
"""count = 0
	while n > 0:
		if d == n % 10: # Check if last digit of n is digit d
			count += 1
		n = n // 10 # Remove the last digit from n
	return count"""
#Q2
"""
>>> alternate_apply(lambda x: x+1, lambda x: x+2, 1, 0)
3
>>> alternate_apply(lambda x: x+1, lambda x: x+2, 2, 0)
6
"""
def alternate_apply(f, g, n, x):
	if n == 1 :
		return g(f(x)) # Return the value of x on which f and g are alternately applied
	else:
		return alternate_apply(f, g, n - 1, g(f(x))) # Return the value of x on which f and g are applied n times by calling alternate_apply recursively


#Q3
"""
>>> a = make_ordered_linked_list(6, empty)
>>> b = make_ordered_linked_list(8, a)
>>> c = make_ordered_linked_list(4, b)
>>> first(c)
4
>>> d = make_ordered_linked_list(7, c)
>>> first(d)
4
"""

	    
empty = 'empty'

def make_ordered_linked_list(First, Rest = empty):
    if type(Rest) != str and first(Rest) < First:
        return make_ordered_linked_list(first(Rest), make_ordered_linked_list(First, rest(Rest)))
    return [First] + [Rest]
    
def first(s):
    return s[0]

def rest(s):
    return s[1]

"""Doctests
>>> a = make_ordered_linked_list(1, make_ordered_linked_list(3, empty))
>>> first(a)
>>> rest(a)
"""
