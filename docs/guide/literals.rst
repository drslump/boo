Literals
========

Arrays are statically sized homogeneous data structures::

	l = (,) // empty array (typed (object))
	l = (1, 2, 3) // integer array with three elements
	l = ("Eric", ) // string array with a single element

Lists are dynamically sized heterogeneous data structures::

	l = [] // empty list
	l = ["one", 2, 3]

Hash literals, also known as *associative arrays* or *dictionaries*::

	h = {} // empty hash
	h = { "spam" : "eggs" }
	print h["spam"]

Timespan literals::

	print 50s // 50 seconds
	print 1d // 1 day
	print 2m // 2 minutes
	print 42ms // 42 miliseconds

	print "Tomorrow this time will be: $(date.Now + 1d)"

Regular Expressions::

	fname, lname = /(\w+)/.Matches(" Eric Idle ")
	print fname
	print lname

Extended regular expressions can also contain white space and tab characters but they must be started by the ``@/`` sequence::

	fname, lname = @/ /.Split("Eric Idle")
	print fname
	print lname