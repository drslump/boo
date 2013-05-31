Functions
=========

Functions do not necessarily have to be created inside of classes in Boo.

This is valid code::

	def doWickedAndNaughtyThings():
	     print "I'm doing evil, wicked things to you."
	     print "No, don't call the police!"
	     print "...crap."
	 
	doWickedAndNaughtyThings()

So is this::

	class Wife:
	    def MakeSandwich(toppings as (string) ):
	        for items in toppings:
	            GruelOverStove(items)
	        return Sandwich(toppings.Length)
	    def GruelOverStove(item):
	        print "$(item)?! $(item)?! Who eats $(item)s?!"
	 
	class Sandwich:
	    def constructor(length):
	        self.toppingCount= length
	    public toppingCount as int
	 
	// Here's when things go procedural!
	def EatSandwich(sammich):
	    print "What, only $((sammich as Sandwich).toppingCount) toppings?!"
	 
	redhead = Wife()
	EatSandwich(redhead.MakeSandwich( ("Pickles", "Turkey", "Mayonase", "Mustard", "Lettuce")  ) )
	print "Delicious! Now, where's the remote control?"

Functions can also be placed inside other functions (these are called Closures or "blocks" in some languages)::

	def SpiceyMayo():
	    somethingNotDeservingOfAFunction = def():
	        print "lol"
	    somethingNotDeservingOfAFunction()
	SpiceyMayo()

Closures are also handy in a variety of other situations.

There are also 3 special functions that can be used in classes. They are ``constructor``, ``static constructor``, and ``destructor``. Each have no return type, modifiers, or attributes. Only the plain constructor takes parameters. Constructors are invoked when an instance is created. Static constructors are called only the first time the type is used. They should be used to initialize uninitialized static fields. Destructors perform commands when objects are freed.


Parameters
----------

Parameters are the objects you can pass to `Functions`_, `Closures`_ or `Callables`_ which handle `Events`_.

A parameter is declared with a name, followed by ``as``, followed by the type: ``paramname as type``. If there is no ``as type``, then the type is assumed to be type ``object``.

Method/Function example::

	def mymethod(x as int, y as long):
	        ...

Closure example::

	c = def(z):
	         print z
	 
	obj = "a string"
	c(obj)

Callable Type + Event example::

	import System
	 
	class Sandwich:
	    event Eating as EatingEvent
	    callable EatingEvent(sammich as object, type as string)
	 
	    def Eat():
	        Eating(self, "Turkey sammich.")
	 
	turkeyAndSwiss = Sandwich()
	turkeyAndSwiss.Eating += def(obj, sammich):
	    print "You're eating a $sammich! It must be good."
	turkeyAndSwiss.Eat()


Boo allows you to call or declare methods that accept a variable (unknown) number of parameters.

You add an asterix (``*``) before the parameter name to signify that it holds multiple parameter values. If there is no ``as type``, the type is assumed to be an array of objects: ``(object)``. You can declare the type as any array type. For example ``(int)`` if your method only accepts ``int`` parameters.

Here is an example::

	def mymethod(x as int, *rest):
	    print "first arg:", x
	    for item in rest:
	        print "extra param:", item
	    print
	 
	mymethod(1, "a", "b", "c")
	mymethod(2, 3, 4, 5, 6, 7)

Some boo builtins accept a variable number of parameters, like ``matrix`` and ``ICallable.Call``.


Parameters by reference
-----------------------

Add a ``ref`` keyword before the parameter name to make a parameter be passed by reference instead of by value. This allows you to change a variable's value outside of the context where it is being used. Some examples:

Basic byref example::

	def dobyref(ref x as int):
	        x = 4
	 
	x = 1
	print x  // 1
	dobyref(x)
	print x  // 4

Wrapping a native method that takes a parameter by reference::

	import System.Windows.Forms from System.Windows.Forms
	import System.Drawing from System.Drawing
	import System.Runtime.InteropServices
	 
	class ExtTextBox(TextBox):
	    //must be static
	    [DllImport("user32")]
	    static def GetCaretPos(ref p as Point):
	        pass
	 
	 
	f = Form(Text: "byref test")
	t = ExtTextBox()
	f.Controls.Add(t)
	 
	b = Button(Text: "GetCaretPos")
	b.Click += do:
	    p = Point(0,0)
	    t.GetCaretPos(p)
	    MessageBox.Show(p.X.ToString())
	b.Location = Point(0,100)
	f.Controls.Add(b)
	Application.Run(f)

See also ``tests/testcases/integration/byref*.boo`` in the boo source distribution.
