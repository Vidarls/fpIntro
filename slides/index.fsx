(**
- title : Intro to FP
- description : Introduction to functional programming
- author : Vidar Løvbrekke Sømme
- theme : sky
- transition : default

***

### Welcome to the functional programming introduction

***

### Vidar Løvbrekke Sømme

* Responsible for development in Vetserve

***

### What is functional programming?

---

* Many definitions
* Mathematical functions
* Immutability
* Pure functions
* Monads
* Lambdas

---

Functional programming is when functions are your unit of composition.

***

### A little bit about F#

---

* Is a .Net language
* Runs on the CLR
* Is a multi paradigm language, with a functional first approach

---

### Is really fun

And you can easily use it in your normal .Net projects

***

### Some code

*)

let makeHello str = sprintf "Hello %s" str
let hello = makeHello "world"

(**
 value of `hello`:
*)
(*** include-value: hello ***)

(**

***

### Composing?

* OO -> Objects and interfaces
* Dependency injection

---

    [lang=cs]
    
    class DoDbStuff
    {
        IDbInterface db;

        public DoDbStuff(IDbInterface db)
        {
            this.db = db;
        }

        public string GetStuff(int id) {
            return db.Things.GetById(id);
        }
    }

---

### Function signatures are single method interfaces

*)

let getStuff (getById:int->string) (id:int) = getById id 

(**

***

### Combining functions

*)

let isMoreThan10 v = v > 10
let asAString v = sprintf "%b" v 

let isMoreThan10asAString1 v = 
    let result = isMoreThan10 v
    asAString result

let isMoreThan10AsAString2 v = v |> isMoreThan10 |> asAString

let isMoreThan10AsAString3 = isMoreThan10 >> asAString

(**

***

### Partial application

*)

let getById id = "some value"

let getStuffWithDependency = getStuff getById

let getBooleanAsString = sprintf "%b"

(**

***

### Immutability

* Immutable by default
* No need to "trust" other parts of code
* Good for concurrency

***

### Null and friends

* Immutable by default means no nulls, have to assign values
* F# types does not support null

---

### Option, a nice alternative to nulls

* Nulls are often used to represent no value, and this causes pain
* Option represents a value that may or may not be there
* Forces handling of both cases

*)

type Option<'t> =
| Some of 't
| None

(**

---

### Built in null checks with higher order functions

*)

module Option =
    let map2 f a b =
        match (a,b) with
        | Some a, Some b -> Some (f a b)
        | _ -> None

let val1 = Some 1
let val2 = Some 2
let val3 = None
let add = Option.map2 (+)
let allThere = add val1 val2
let oneMissing = add val1 val3

(**

Content of `allThere`:
*)
(*** include-value: allThere ***)
(**
Content of `oneMissing`:
*)
(*** include-value: oneMissing ***)
(**

***

### More syntax

*)

let aList = [1;2;3]
let anArray = [|1;2;3|]
let aSequence = seq {yield 1;yield 2; yield 3}

let asyncString = async { Async.Sleep 1000; return "hello"} |> Async.RunSynchronously

type ARecord = { FieldOne: string; Field2: int}
let recordValue = { FieldOne = "Hello"; Field2 = 0}
let otherRecordValue = { recordValue with Field2 = 2}

let aTuple = (1, "one")
let first,second = aTuple

(**

***

### Getting started

* [Fsharp.org](http://fsharp.org/)

---

### Good resources

* Fsharp for fun and profit - http://fsharpforfunandprofit.com/
* Category theory for programmers - http://blog.ploeh.dk/2017/10/04/from-design-patterns-to-category-theory/

--- 

### Cool projects

* Fable - http://fable.io/
* SAFE stack - https://www.safestack.io/
* Fake build - https://fake.build/
* Fsharp.Data - https://fsharp.github.io/FSharp.Data/

***

### Question and example time

* Ask away, I will try to explain and show with code as best I can



*)