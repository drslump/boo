Lists
=====

Lists are mutable sequences of items. They are similar to lists in Python.

Lists are surrounded by brackets, just like python: ``[1,2,3]``

Here is some sample code demonstrating different operations you can do on lists::

    //the "as List" is optional:
    mylist as List = ["foo", "bar", "baz", 0, 1, 2]
    print mylist
     
    for item in mylist:
        print item
     
    print "len(mylist): " + len(mylist)
     
    for i in range(mylist.Count):
        print mylist[i]
     
     
    print mylist.Join("=") //foo=bar=baz=0=1=2
     
    mylist[1] = "bbb" //set 2nd item
    print mylist
    print "mylist[1]: " + mylist[1] //print 2nd item
    print "Index of \"bbb\": " + mylist.IndexOf("bbb")
    mylist.Add("new item") //also mylist.Push does same thing
    print mylist
    mylist.Insert(4,"abc") //insert "abc" at 5th spot
    print mylist
    mylist.Remove("bbb") //remove the "bbb" item
    print mylist
    mylist.RemoveAt(1) //remove the 2nd item
    print mylist
    mylist.Remove(0) //remove the zero item (not 1st item)
    print mylist
    mylist += ["test"]
    print mylist
    mylist.Extend(["one","two"])
    print mylist
    lastitem = mylist.Pop() //removes last item from list and returns it
    print mylist
     
    if mylist == ["foo","abc",1,2,"new item","test","one"]:
        print "equals other list"
     
    //List comprehensions:
    print "just the string items: " + [i for i in mylist if i isa string]
    print "just the int items:    " + [i for i in mylist if i isa int]
    //"i isa string" is the same as "i.GetType() == string"
     
    //another way to do it using the "as" cast: (see Casting Types)
    //   (i as string) will be null if item is an integer
    print "just the string items: " + [stritem for i in mylist
                        if stritem=(i as string)]
    print "just 3 letter items:   " + [stritem for i in mylist
                        if stritem=(i as string)
                        and len(stritem) == 3]
     
    if "foo" in mylist:
        print "foo is in mylist"
     
    //another way to do the same thing:
    if mylist.Contains("foo"):
        print "contains foo"
     
    if "baditem" not in mylist:
        print "baditem is not in mylist"
     
    //You can also pass a special search function or closure to Find.
    //Find returns the first item that returns true from the search function.
    if mylist.Find({item | return item == "foo"}):
        print "found foo"
     
    //using a multiline do/def closure with Find:
    result = [1, 2, 3].Find() do (item as int):
            return item > 1
    print "item > 1 in [1,2,3]: " + result
     
    //Collect is similar to Find but it returns a list of all items that
    //return true from the search function.
    result = [1, 2, 3].Collect() do (item as int):
            return item > 1
    print "all items > 1 in [1,2,3]: " + result
     
    //Sorting a list.  Only works if all the items are comparable
    //(all ints or strings for example)
    //or if you pass your own compare function.
    newlist =  [2, 4, 3, 5, 1]
    print newlist
    print newlist.Sort()
    result = newlist.Sort() do (left as int, right as int):
        return right - left //reverse sort order
    print result
     
    mylist = mylist * 3
    print mylist
     
    mylist.Clear()