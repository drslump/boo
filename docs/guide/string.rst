Strings
=======

String literals
---------------

There are four different ways to quote text as a string literal.

Single quotes: ``'foo bar baz'``
	Allows escape sequences with a backslash "``\``".

Double quotes: ``"foo bar baz"``
	Allows escape sequences with a backslash "``\``". Allows `string interpolation`_

Triple quotes: ``"""foo bar baz"""``
	Can span multiple lines. Allows escape sequences with a backslash "``\``". Allows `string interpolation`_

Back quotes: ```foo bar baz```
	Captures the quoted text verbatim. No escape sequences or interpolation are interpreted.


String Interpolation
--------------------

String interpolation allows you to insert the value of almost any valid boo expression inside a string by quoting the expression with ``$()``.

.. versionchanged:: 0.9
	Older versions used the syntax ``${}`` 

The parentheses are unnecessary if the expression is just a variable::

	now = "IMPORTANT"
	print("Tomorrow will be $now")

String interpolation kicks in for both double and triple quoted strings::

	print("Now is $(date.Now).")
	print("Tomorrow will be $(date.Now + 1d)")

	print("""
	----
	Life, the Universe and Everything: $(len('answer to life the universe and everything')).
	----
	""")

You can scape the $ character to prevent interpolation::

	print("Now is \$(date.Now).") # outputs: Now is $(date.Now).

You don't need to scape the $ char when it is followed by a space::

	print("Calabresa R$ 4,50.")

.. warning:: Interpolation doesn't kick in inside single quoted strings


String Formatting
-----------------

Boo also has the ``%`` (modulus) operator as shorthand for .NET's ``string.Format`` method. This is a little more similar to Python's string interpolation, too::

	s = "Right now it is {0}.  Say hi to {1}."
	print s % (date.Now, "Mary")

the above is basically shorthand for .NET's ``string.Format`` method::

	mystr = string.Format("x = {0}, y = {1}", x, y)

You can also pass the same parameters to ``Console.Write`` or ``WriteLine`` if you just want to print out a formatted string::

	System.Console.WriteLine("x = {0}, y = {1}", x, y)


Combine boo and .net's string formatting
----------------------------------------

This tip suggested by *Arron Washington*. You can combine the two techniques described above to get the best of both, like in this example::

	first = "Reed"
	last = "H"
	age = 2
	print "$first $last is {0:00} years old." % (age,)
	//--> Reed H is 02 years old.
	Another way is to pass formatting codes to the ToString method:

	print age.ToString("00")
	//--> 02

.. seealso:: Here are some related resources on .NET string formatting

	- http://www.codeproject.com/books/0735616485.asp
	- http://www.stevex.org/dottext/articles/158.aspx
	- http://www.csharpfriends.com/quickstart/howto/doc/format.aspx


ToString() Method
-----------------

To convert a class or a type to a string, call the ToString() method. Or if you are writing your own class you can define your own ToString() method to control how your class is printed.

Converting from int to string and Back::

	//string to int
	val as int
	val = int.Parse("1000")
	print val
	 
	//string to double
	pi as double
	pi = double.Parse("3.14")
	print pi
	 
	//int or double to string
	s as string
	s = val.ToString()
	print s
	 
	//multiple values to one formatted string
	astr as string
	astr = "$val and $pi"
	print astr
	 
	//date parsing
	d as date
	d = date.Parse("12/03/04")

For parsing and converting other types, see `this tutorial <http://samples.gotdotnet.com/quickstart/howto/doc/parse.aspx>`_ on the Parse and Convert techniques, as well as date parsing.

String Comparisons::

	//regular comparison
	if "asdf" == "ASDF":
	    print "asdf == ASDF"
	else:
	    print "asdf != ASDF"
	 
	//case-insensitive comparison
	if string.Compare("asdf", "ASDF", true) == 0:
	    print "case-insensitively the same"
	 
	s = "Another String"
	 
	if s.StartsWith("Another"):
	    print "starts with 'Another'"
	if s.EndsWith("String"):
	    print "ends with 'String'"
	 
	print "'String' starts at:", s.IndexOf("String")
	 
	print "The last t is at:", s.LastIndexOf("t")
	 
	//use built-in regex support to split a string
	words = @/ /.Split(s) //split on whitespace (could use \s)
	for word in words:
	    print word

.. seealso:: See the .NET reference on `Basic String Operations <http://msdn.microsoft.com/en-us/library/a292he7t%28v=VS.100%29.aspx>`_ for more information on string comparisons.