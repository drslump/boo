Callables
=========

Callable types are a generalization of the concept of a *delegate* in .Net. In boo, not only delegates and methods can be called as functions but also any reference of type ``System.Type`` or any ``Boo.Lang.ICallable`` implementing type. In the case of ``System.Type`` references, the appropriate constructor will be called, if any. In the case of ``ICallable`` the method ``Call`` will be used.

The language itself allows new callable types to be formally defined through the ``callable`` construct.

This example defines a callable type which takes two arguments of types ``System.Int32`` and ``System.Object`` respectively and returns a ``System.Bool`` value::

	callable MyCallable(param1 as int, param2) as bool

The following example defines a callable type which takes a single argument of type System.Object but has no return value::

	callable AnotherCallable(param)

This last one defines a new callable type taking another callable type as its single argument with no return value::

	callable UseCallable(c as AnotherCallable)

The language allows free interchange of structurally compatible callable references. A callable is considered structurally compatible to a callable reference if the type of the reference is ``System.Object``, ``Boo.Lang.ICallable`` or another callable type declaring the same number of arguments or less and all arguments types are also compatible.

For this scheme to work the compiler needs to implement some automatic conversion rules:

  - ``t as Type`` => ``ICallable``
	Using ``Boo.Lang.RuntimeServices.CallableType(t)``

  - Method reference => ``ICallable`` or ``System.Object``
	new instance of a private ``ICallable`` implementation that takes original object reference (if any) in the constructor and calls the apropriate method in ``ICallable.Call``

  - ``x as CallableX`` => ``y as CallableY``