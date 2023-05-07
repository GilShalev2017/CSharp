// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var iterators = new List<Action>();
/*
C# closure is a programming feature that allows a function or lambda expression to capture and 
use variables declared outside of its own scope. In other words, a closure is a function that remembers 
the values of all the variables that were in scope at the time of its creation, even if those variables are 
no longer in scope when the function is called.
C# closures are particularly useful in situations where you need to maintain state across multiple calls to a 
function. For example, if you have a function that performs some kind of iterative calculation, you can use a closure
to remember the current state of the calculation between each call to the function.
C# closures are created automatically by the compiler when you use lambda expressions or anonymous methods, 
and they are implemented using classes that capture the values of the variables in their constructor.
*/

for(int i = 0; i < 15; i++)
{
    //Here we have closure = a function inside a function. I isn't released
    //becuase the lambdas functions keep it in memory. the last value of i is 15
    //so 15 anonymous functions will run with this value!
    iterators.Add(() => {Console.WriteLine(i); });
}

foreach (var iterator in iterators)
    iterator();