Basic features of Boo
=====================

Structure of a Boo Script
-------------------------

Boo scripts have a set structure you need to follow to avoid errors when compiling. All of the items are optional, but order of the items is not:

The structure is like:

 - module docstring
 - namespace declaration
 - import statements
 - module members: class/enum/def declarations
 - main code executed when script is run
 - assembly attributes

For example::

	"""module docstring"""

	namespace My.NameSpace #optional namespace declaration

	import Assembly.Reference #import statements

	#followed by the Members of this module (classes, methods, etc.)
	class MyClass:
	    pass

	def domyfunction(it):
	    print(it)

	#start "main" section that is executed when script is run
	x as int
	x = 3
	domyfunction(x)

	#optional assembly attribute declarations used when compiling
	[assembly: AssemblyTitle('foo')]
	[assembly: AssemblyDescription('bar')]


There is one issue with the above structure, however. What if you are creating a library (dll), and you want to have "global" properties or fields? Also, what if you want to do some things when your dll is loaded by another application?

Example use::

	import MyLibrary
	print (Version)
	doit()

Now in Boo, you can do this by specifying a "global" class for your module. You tell the Boo compiler to use your class as the global, module-wide class by adding a [Module] attribute::

	[Module]
	class MainClass:
	    public static Version as string

	    static def constructor():
	        Version = "0.1"

	def doit():
	    #you can refer to "globals" from within your library, too:
	    print("This library's version is: "+MainClass.Version)

Also in Boo you can define which method the compiler should use as the main entry point method. This is useful for example when you want to add an attribute (like STAThread) to the main method. This main method can be anywhere in your boo script, or you can put it inside your main module class if you want to combine both of these techniques::

	[STAThread]
	def Main(argv as (string)):
	    ...main entry point


Imports
-------

	**import** TARGET *(from ASSEMBLY)?* *(as ALIAS)?*

The import construct makes all the members of the imported target available to the current module. So instead of writing::

	System.Console.WriteLine("and now for something completely different... ")
	System.Console.WriteLine("import!")

one can write::

	import System
	 
	Console.WriteLine("anfscd...")
	Console.WriteLine("import!")

The target can be either a namespace or a type. When it's a type, all the type's static members can be referenced directly by name. So the previous example could be simplified even further::

	import System.Console
	 
	WriteLine("anfscd...")
	WriteLine("import!")

The from clause can be used to specify an additional assembly reference as well as to disambiguate namespaces. When using a Namespace that is not defined in an assembly with the name of the Namespace, you should use from::

	import Some.Namespace from Weird.Assembly.Name
	import Gtk from "gtk-sharp"

from also accepts a quoted string as argument for weird named assemblies::

	import Gtk from "gtk-sharp"
	 
	Application.Init()

And speaking of assembly references, the boo compiler automatically add 4 assembly references before compiling any code: Boo, Boo.Lang.Compiler, (ms)corlib and System.


Comments
--------

Single line comments
~~~~~~~~~~~~~~~~~~~~
Everything that comes after a hash character ``#`` or a double backslace ``//`` is ignored until the end of the line::

	# this is a comment
	// This is also a comment
	print("Hello, world!") // A comment can start anywhere in the line


Multi line comments 
~~~~~~~~~~~~~~~~~~~
Multiline comments in boo are delimited by the ``/*`` and ``*/`` sequences. Just like in C. Unlike in C though, boo multiline comments are nestable::

	/* this is a comment */
	/* this
	comment
	spans mutiple
	line */

	/* this is a /*
	                 nested comment */
	    comment */

nested comments must be properly, hmmmm, nested or the parser will complain::

	/* this is a /* syntax error */



Builtin Functions
-----------------

Here is a summary of boo's built-in functions. The actual source code underlying these functions is in ``Boo.Lang/Builtins.cs``.


.. data:: BooVersion as System.Version

	``BooVersion`` is a builtin property that returns the current version of boo that is running. It returns a ``System.Version`` class. See `Getting Boo Version`_ for more info.

.. function:: array(object as IEnumerable)

	Converts an ``IEnumerable`` object to a non-specific (type of ``System.Object``) array.

.. function:: array(type as Type, collection as ICollection)

	Converts any object that implements ``ICollection`` to an array of ``Type``.

.. function:: array(type as Type, enumerable as IEnumerable)

	Converts any object that impelements ``IEnumerable`` to an array of ``Type``.

.. function:: array(type as Type, size as int)

	Creates an empty array of the specified size.

.. function:: enumerate(enumerable as object)

	It is useful when you want to keep a running count while looping through items using a for loop::

		mylist = ["a", "b", "c"]
		for i as int, obj in enumerate(mylist):
		      print i, ":", obj

.. function:: gets()

	Returns a string of input that originates from ``Console.ReadLine()`` - AKA, "Standard Input". See also ``prompt`` below.

.. function:: iterator(enumerable as object)

	Usually not necessary, this builtin returns any ``IEnumerator`` it can find in the object passed. ``for`` loops do this automatically for you.

.. function:: join(enumerable as IEnumerable)

	Joins all of the elements in enumerable into one string, using a single space (ASCII Code: 32) between elements.

.. function:: join(enumerable as IEnumerable, seperator as Char)

	The same as ``join(enumerable as IEnumerable)``, except that ``seperator`` defines what character seperates each element in enumerable.


.. function:: map(enumerable as IEnumerable, function as ICallable)

	Taking an enumerable object such as a list or a collection, it returns an IEnumerable object that applies "function" to each element in the array.

	Examples::

		def HardRock(item):
			return "$item totally rocks out, man!"

		wyclefSongs = ("Two wrongs", "Dirty Dancing")

		x = map(wyclefSongs, HardRock)
		for y in x:
			print y

		//another example using a multiline anonymous closure:
		newlist = map([1,2,3,4,5,6]) def (x as int):
		    return x*x*x

	Output::

		Two wrongs totally rocks out, man!
		Dirty Dancing totally rocks out, man!

.. function:: matrix(elementType as Type, len_1st_dimension as int, len_2nd_dimentsion as int)

	Creates a multidimensional array of type elementType with the specifications of length. See `Multidimensional Arrays`_ for more info, but here is a basic example::

		foo = matrix(int, 2, 2)
		foo[0, 0] = 0
		foo[0, 1] = 1
		foo[1, 0] = 2
		foo[1, 1] = 3

		print join(foo) //prints "0, 1, 2, 3"

.. function:: print(object as Object)

	Prints an object to Standard Out. The equivilent of Console.WriteLine

.. function:: prompt(query as string)

	Prints query to standard output, then waits for a user to 'respond.' Returns a string containing what the user has typed.

.. function:: range(max as int)

	Returns an IEnumerable object that contains elements from 0 to max - 1::

		# This prints 0 through 9:
		for i in range(10):
		    print i

.. function:: range(begin as int, end as int)

	Returns an IEnumerable object that contains elements from begin to end - 1.

.. function:: range(begin as int, end as int, step as int)

	Returns an IEnumerable object that contains all of the elements from begin to end - 1 that match the interval of step::

		for i in range(0, 10, 2):
			print i

	Output:

		0
		2
		4
		6
		8

.. function:: reversed(enumerable as object)

	Returns items as an ``IEnumerable`` in reverse order.


.. function:: shell(filename as string, arguments as string)

	Invoke an application (filename) with the arguments (arguments) specified. Returns a string containing the program's output to Standard Out (aka, the console)

.. function:: shellm(filename as string, arguments as (string) )

	Invoke an application (filename) with an array of arguments (arguments); returns a string containing program's output.

.. function:: shellp(filename as string, arguments as string)

	Starts a process specified by filename with the arguments provided and returns a Process object representing the newly born process.

.. function:: zip(first as IEnumerable, second as IEnumerable)

	zip will return an ``IEnumerable`` object, wherein each element of the ``IEnumerable`` object will be a one dimensional array containing two elements; the first element will be an element located in "firstNames" and the second will be an element located in "lastNames."

	Example::

		firstNames = ("Charles", "Joe", "P")
		lastNames = ("Whittaker", "Manson", "Diddy")

		x = zip(firstNames, lastNames)
		for y in x:
			print join(y)

	Output::

		Charles Whittaker
		Joe Manson
		P Diddy

