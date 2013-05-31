Generators
==========

From time to time there is the need to represent closed sets such as customers in Brazil or open sets like the numbers in the Fibonacci series in a succinct and memory conservative way. Enter generators.

Generators are language constructs capable of producing more than one value when used in an iteration context such as the for in loop.

Generator expressions
---------------------

Generator expressions are defined through the pattern:

	**expression** for **declarations** in **iterator** [if|unless *condition*]

Generator expressions can be used as return values::

	def GetCompletedTasks():
	      return t for t in _tasks if t.IsCompleted

Generator expressions can be stored in variables::

	oddNumbers = i for i in range(10) if i % 2

Generator expressions can be used as arguments to functions::

	print(join(i*2 for i in range(10) if 0 == i % 2))

In all cases the evaluation of each inner expression happens only on demand as the generator is consumed by a ``for in`` loop.

Generator expressions capture their enclosing environment (like closures do) and thus are able to affect it by updating variables::

	i = 0
	a = (++i)*j for j in range(3)
	print(join(a)) # prints "0 2 6"
	print(i) # prints 3

As well as being affected by changes to captured variables::

	i = 1
	a = range(3)
	generator = i*j for j in a
	print(join(generator)) # prints "0 1 2"

	i = 2
	a = range(5)
	print(join(generator)) # prints "0 2 4 6 8"

Remarks
~~~~~~~

boo's variable capturing behavior differs in behavior from python's in a subtle but I think good way::

	import System

	functions = Math.Sin, Math.Cos

	a = []
	for f in functions:
	   a.Add(f(value) for value in range(3))

	for iterator in a:
	   print(join(iterator))

This program properly prints the sins followed by the cosines of 0, 1, 2 because for controlled variable references (such as f) in boo generator expressions as well as in closures are bound early.

Breakdown
~~~~~~~~~

Still having problems understanding generators, huh? Let's start off easy by following their most common syntax:

	*local_variable* = *expression* for *declarations* in *iterator* *conditional_expression*

After the generator expression is run, *local_variable* will become an enumerable object that you can iterate through, like an array, list, or collection. The contents of this enumerable object will be a collection of *expression*.

*expression* are variables that are put into *local_variable* if *conditional_expression* returns true. This means means that by using a *conditional_expression* in a generator, you can decide which objects should be added to the enumerable *local_variable*. *expression* can be manipulated further: for instance, this syntax is valid:

	*local_variable* = MethodToMutilateExpression(*expression*) for *declarations* in *iterator* *conditional_expression*

In this instance, the return value of ``MethodToMutilateExpression`` will be added to the enumerable *local_variable*. This makes generators useful to filter the input that ``MethodToMutilateExpression()`` will be called with.

The rest of the syntax, "for *declaration* in *iterator*" is your typical for loop, like for example: ``for item in collection``

Here's a simple working example of how generators work::

	# An array of integers
	crazyArray = (0, 1, 2, 3, 4, 5)
	# Shazbot. We only want integers that are greater than 3!

	# We want an enumerable object composed only of integers > 3.
	validIntegers = value for value in crazyArray if value > 3

	# Here's some special Boo magic: turn 'ValidIntegers' back into an array!
	# We can do this because all objects within validIntegers are really integers.
	magic = array(int, validIntegers)
	print magic #print the type of this object
	print join(magic) #turn this array into a readable string.

Here's the output::

	System.Int32[]
	4 5


Generator Methods
-----------------

Generator methods are defined by the use of the yield keyword::

	def fibonacci():
	   a, b = 0, 1
	   while true:
	      yield b
	      a, b = b, a+b

Given the definition above the following program would print the first five elements of the Fibonacci series::

	for index as int, element in zip(range(5), fibonacci()):
	   print "$(index+1): $element"

So although the generator definition itself is unbounded (a while true loop) only the necessary elements will be computed, five in this particular case as the zip built-in will stop asking for more when the range is exhausted.

Generator methods are also a great way of encapsulating iteration logic::

	def selectElements(element as XmlElement, tagName as string):
	   for node as XmlNode in element.ChildNodes:
	      if node isa XmlElement and tagName == node.Name:
	         yield node


List Generators
---------------

List generators aka *list comprehensions* and *list displays* provide a quick way to create a list with selected elements from any enumerable object.

List generators are defined through the following syntaxes::

	[element for item in enumerable]
	[element for item in enumerable if condition]
	[element for item in enumerable unless condition]

List with all the doubles from 0 to 5 (exclusive)::

	doubles = [i*2 for i in range(5)]

List with the names of the customers based on Rio de Janeiro::

	rjCustomers = [customer.Name for customer in customers if customer.State == "RJ"]