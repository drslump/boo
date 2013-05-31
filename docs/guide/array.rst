Arrays
======

Arrays are similar to arrays in C, C#, or Java. They are initialized to a certain fixed length, and all the items in an array are generally of the same type (int, string, etc.).

In boo, arrays use parentheses to surround the items instead of brackets: ``(1,2,3)``.

If you need to declare the type of an array, use parentheses surrounding the type of item in the array, such as ``(int)`` for an array of ints or ``(object)`` for an array of objects.

Boo's arrays are zero-based, so the first item is item 0, the 2nd is item 1, etc.

::

	//Create an array with 3 strings - the 'as (string)' part is optional
	myarray as (string) = ("one", "two", "three")
	for i in myarray:
	    print i
	 
	//Create an array to hold 10 integers:
	a as (int) = array(int,10)
	//set the 2nd item to 3
	a[1] = 3
	print a[1]
	 
	//Convert from array to list:
	mylist = [item for item in myarray]
	print mylist
	 
	//Convert from list back to array:
	 
	//This is the preferred way to do it:
	array2 = array(string, mylist)
	 
	//but there is this way too: (compiler can't tell the type though)
	array3 = mylist.ToArray(string)
	for i in array2:
	    print i
	 
	// Append two arrays:
	a = (1, 2) + (3, 4)
	assert a == (1, 2, 3, 4)


Byte Arrays
-----------

Boo right now doesn't support implicitly converting int literals to type byte, so you need to use the array() builtin function::

	#won't work: bytes as (byte) = (1,2,3,4,5)
	 
	//int to byte
	bytes = array(byte, (1,2,3,4,5))
	 
	print bytes.GetType() //-> System.Byte[]
	 
	for b in bytes:
	    print b
	 
	//hex literals to byte
	bytes = array(byte, (0xFF, 0xBB, 0x3F))
	for b in bytes:
	    print b
	 
	//chars or string to a byte array:
	bytes = System.Text.ASCIIEncoding().GetBytes("abcABC")
	for b in bytes:
	    print b



Char arrays
-----------

Boo right now doesn't have support for implicitly converting single character string literals (like "a") to the char type. A workaround it to use slicing (``"a"[0]``), but in this case you can use the ``ToCharArray`` method of the string class instead::

	#won't work: charbytes as (char) = ("a", "b", "c")
	 
	//String.ToCharArray()
	charbytes = "abcABC".ToCharArray()
	 
	print charbytes.GetType() //-> System.Char[]
	 
	for b in charbytes:
	    print b


Creating an empty, zero-length array
------------------------------------

Sometimes a system function might require passing an array even if it is empty. Here are some ways to create an empty zero-length array of type ``(object)``::

	emptyArray = array(object, 0)
	 
	//other ways:
	emptyArray = array(object,[])
	emptyArray = [].ToArray(object)
	emptyArray = array([])
	 
	//If the type is to be (object), then you can simply use:
	emptyArray = (,)


Multidimensional Arrays
-----------------------

Boo has support for *Multidimensional Arrays*, also called *rectangular arrays*. When declaring a variable or a field as a multidimensional array, use this syntax::

	foo as (int, 3) //declare a 3 dimensional array of integers.

When creating a brand spanking new multidimensional array, use this syntax::

	foo = matrix(int, 2, 3, 4)
	//That creates an empty 3 dimensional array.
	//1st dimension will have 2 items, 2nd has 3, 3rd has 4

Set and retrieve data from the array::

	foo[0,0,1] = 100
	print foo[0,0,1]

This shows looping over the array to set or get values::

	n = 1
	for i in range(len(foo,0)): //# of items in 1st dimension
		for j in range(len(foo,1)): //2nd dimension
			for k in range(len(foo,2)): //3rd dimension
				foo[i,j,k] = n
				++n

	//Print the values out in a table format:
	columns = len(foo, foo.Rank - 1)
	line = []
	for item in foo:
		line.Add(item.ToString("00"))
		if len(line) >= columns:
			print join(line)
			line.Clear()

The whole code together produces this output::

	100
	01 02 03 04
	05 06 07 08
	09 10 11 12
	13 14 15 16
	17 18 19 20
	21 22 23 24
