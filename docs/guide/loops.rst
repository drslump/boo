Loops
=====

The for loop
------------

The for loop syntax is::

	for var in range:
	    // action

where range can be any type of collection. Examples::

	// print numbers from 0 until 9
	for i in range(0, 10):
	    print(i)

it is equivalent to the traditional construct in other languages::

	for (int i = 0; i < 10; i++) 
	    // print

You can also use it with lists::

	for i in [300, 100, 23, 1, 55]:
	    print(i)

	itens = [2, 44, 56, 123, 98, 77, 1000]
	for i in itens:
	    print (i)

or with arrays::

	for i in (1, 4, 98, 399, 1000, 34, 199):
	    print (i)


The while loop
--------------

The syntax is::

	i = 0
	while i < 10:
	    print (i)
	    ++i
	i = 0
	while not(i > 10):
	    print (i)
	    ++i

Iterating over collections::

	import System.Collections

	class Test:
	    def showAllValues(items as IList):
	        i = 0
	        itemsLen = len(items)
	        while i < itemsLen and items[i].GetType() is not int:
	            print("Bad, bad type: " + items[i].GetType())
	            ++i

	class Foo:
	    pass

	t = Test()
	f = Foo()
	t.showAllValues(["1", t, f, 87, 31])