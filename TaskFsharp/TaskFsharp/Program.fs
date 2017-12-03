module FSharpTask

//1
//Посчитать числа Фибоначчи (за линейное время)
//2
//Реализовать функцию обращения списка (за линейное время)
//3
//Написать mergesort: функцию, которая принимает список и
//возвращает отсортированный список
//4
//Посчитать значение дерева разбора арифметического выражения, 
//заданного через вложенные discriminated union-ы
//5    
//Реализовать функцию, генерирующую бесконечную последовательность простых чисел
module hw = 
    //1
    let rec helper firstVal secondVal number = 
        if number > 0 then helper (firstVal + secondVal) firstVal (number - 1)
        else firstVal
    
    let fib n = helper 0I 1I n
    
    //2
    let reverse listx = 
        let rec rev listx listOut = 
            match listx with
            | x :: xs -> rev xs (x :: listOut)
            | [] -> listOut
        rev listx []
    
    //3
    let rec merge = 
        function 
        | [], ys -> ys
        | xs, [] -> xs
        | x :: xs, y :: ys -> 
            if x < y then x :: merge (xs, y :: ys)
            else y :: merge (x :: xs, ys)
    
    let rec split = 
        function 
        | [] -> [], []
        | [ a ] -> [ a ], []
        | x :: x1 :: xs -> 
            let (X, Y) = split xs
            (x :: X, x1 :: Y)
    
    let rec mergesort list = 
        match list with
        | [] -> []
        | [ x ] -> [ x ]
        | _ -> 
            let left, right = split list
            //                List.splitAt (List.length list / 2) list
            merge (mergesort left, mergesort right)
    
    //4
    type Expression = 
        | Value of int
        | Add of Expression * Expression
        | Multiply of Expression * Expression
        | Div of Expression * Expression
        | Sub of Expression * Expression
        | Mod of Expression * Expression
    
    let rec exec = 
        function 
        | Value n -> n
        | Add(x, y) -> exec x + exec y
        | Multiply(x, y) -> exec x * exec y
        | Div(x, y) -> 
            match (x, exec y) with
            | _, 0 -> failwith ("divide  by zero")
            | _, b -> exec x / b
        | Sub(x, y) -> exec x - exec y
        | Mod(x, y) -> exec x % exec y
    
    //4 version 2
    type Expr<'a, 'b> = 
        | Expr of Expr<'a, 'b> * 'a * Expr<'a, 'b>
        | Val of 'b
    
    let rec calculate T = 
        match T with
        | Expr(left, op, right) -> 
            match op with
            | '+' -> calculate left + calculate right
            | '-' -> calculate left - calculate right
            | '*' -> calculate left * calculate right
            | '/' -> 
                let checkZero = calculate right
                if (checkZero = 0) then failwith ("divide  by zero")
                else calculate left / checkZero
            | _ -> failwith ("Invalid operation")
        | Val x -> x
    
    //5
    let rec isPrime x = 
        primes
        |> Seq.takeWhile (fun i -> i * i <= x)
        |> Seq.forall (fun i -> x % i <> 0)
    
    and primes = 
        seq { 
            yield 2
            yield! Seq.unfold (fun i -> Some(i, i + 2)) 3 |> Seq.filter isPrime
        }
    
    //5 version 2
    let isPrime1 n = not ((Seq.exists (fun x -> n % x = 0)) (seq { 2..n / 2 }))
    let primes1 = Seq.filter isPrime1 (Seq.initInfinite (fun x -> x + 2))

module Tests = 
    open hw
    
    [<EntryPoint>]
    let main args = 
        //1
        assert (fib 5 = 5I)
        //2
        assert (reverse [ 1; 2; 3 ] = [ 3; 2; 1 ])
        assert (reverse [ 1 ] = [ 1 ])
        assert (reverse [] = [])
        let list = [ 1..1000 ]
        assert (reverse list = List.rev (list))
        //3
        assert (mergesort [] = [])
        assert (mergesort [ 2, 1 ] = [ 1, 2 ])
        assert (mergesort [ 1000..1 ] = [ 1..1000 ])
        //4
        let addTree = Add(Value 1, Value 2)
        assert (exec addTree = 3)
        let addTree = Add(Value 1, Multiply(Value 2, Value 2))
        assert (exec addTree = 5)
        let addTree = Add(Div(Value 6, Value 3), Multiply(Value 2, Value 2))
        assert (exec addTree = 6)
        let testTree0 = Expr(Expr(Val 2, '+', Val 3), '*', Expr(Val 3, '+', Val 2))
        assert (calculate testTree0 = 36)
        let testTree1 = Expr(Expr(Val 2, '+', Val 3), '/', Expr(Val 2, '-', Val 2))
        try 
            printf "%d\n" (calculate testTree1)
        with Failure(msg) -> printfn "%s" msg
        let testTree2 = Expr(Expr(Val 2, '+', Val 3), '*', Expr(Val 3, '-', Expr(Val 2, '+', Val 100)))
        assert (calculate testTree2 = 6 * (3 - 2 + 100))
        let testTree3 = Expr(Val 2, '.', Val 3)
        try 
            printf "%d\n" (calculate testTree3)
        with Failure(msg) -> printfn "%s" msg
        //5
        printfn "Prime %A" primes
        printfn "Prime %A" primes1
        assert (Seq.take 0 primes = seq [])
        assert (Seq.take 1 primes = seq [ 2 ])
        assert (Seq.take 2 primes = seq [ 2; 3 ])
        assert (Seq.take 3 primes = seq [ 2; 3; 5 ])
        assert (Seq.take 5 primes = seq [ 2; 3; 5; 7; 11 ])
        assert (Seq.take 0 primes1 = seq [])
        assert (Seq.take 1 primes1 = seq [ 2 ])
        assert (Seq.take 2 primes1 = seq [ 2; 3 ])
        assert (Seq.take 3 primes1 = seq [ 2; 3; 5 ])
        assert (Seq.take 5 primes1 = seq [ 2; 3; 5; 7; 11 ])
        printfn "OK test"
        0
