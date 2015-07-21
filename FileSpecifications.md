## v1.2+ ##


Whitespace is trimmed for names. (Group and Property names)
Property value is anything inbetwen = and ; including Whitespace and comments!

```
Group name
{
	Prperty name=Property value;
	sub group
	{
		This propertys value is its name;
	}
	
	prop/*tester*/erty;
	/*Is the same as:*/
	property;
}
```
```
Group name{Property=Value;}HELLO!!;
/*is the same as*/
Group name
{
	Property/*where is the value?*/
	=Value;/*ohh*/
}
HELLO!!
;
```

```
   group /*HI*/ 1 {}
group name is "group 1"

p= 123 ;
value is " 123 "

p= /*NOOO*/
 ;
value is " /*NOOO*/
 "
```