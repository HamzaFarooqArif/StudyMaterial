###QUESTION NO 1###
"""
>>> count_digits(26348222, 2)
4
>>> count_digits(1112, 3)
0 """
def count_digits(num , dig):
   if num< 10 :
      if num == dig:
         return 1
      else:
         return 0
   else:
      if num % 10 == dig:
         return 1 + count_digits(num//10 , dig)
      else:
         return count_digits(num//10, dig)

###QUESTION NO 2###

def alternate_apply(f, g ,n, x):
   if n == 0:
      return x
   else:
      return f(alternate_apply(f, g , n-1, x)


###QUESTION NO 3 ###
"""
>>> a = make_ordered_linked_list(6, empty)
>>> a
[6, 'empty']
>>> b = make_ordered_linked_list(8, a)
>>> b
[6, [8, 'empty']]
>>> c = make_ordered_linked_list(4, b)
>>> c
[4, [6, [8, 'empty']]]
"""
      
def make_ordered_linked_list(n , lst):

	if lst == empty or lst == 'empty':
		return [n, 'empty']
	elif first(lst) > n:
		return [ n, lst]
	elif first(lst) < n:
		return [first(lst), make_ordered_linked_list(n, rest(lst))]
	else:
		return make_ordered_linked_list(n, rest(lst))
