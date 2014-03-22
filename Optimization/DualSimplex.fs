﻿open Optimization.Utils
open System.Collections.Generic

let memoize (f: 'a -> 'b) =
   let cache = new Dictionary<_, _>()

   (fun x ->
      match cache.TryGetValue(x) with
      | true, cachedValue -> cachedValue
      | _ -> 
          let result = f x
          cache.Add(x, result)
          result)

let fst3 (x, y, z) = x
let snd3 (x, y, z) = y
let thrd (x, y, z) = z

(*
  Transportation theory task.
    n: int - count of product types
    m: int - count of resource types
    b: m vector - count of recources available
    c: n vector - profit from products
    A: (m,n) matrix - cost of product production
    J: n list - list of all indices 
    J'b: list - basis indices
    d'down: n vector - lower restrictions for x vector
    d'up: n vector - upper restriction for x vector

    c'x -> max
    Ax = b
    d'down <= x <= d'up
*)

let dualSimplex (A, b: vector, c, d, J, J'b) =
  let (d'down: float list, d'up: float list) = d
  let J'n = J |> List.without J'b
  let A'b = A |> Matrix.fromColumns J'b
  let B = A'b |> Matrix.inv
  let c'b = c |> RowVector.items J'b
  let m, n = A.NumRows, A.NumCols

  let y = c'b * B
  let delta = J 
              |> List.map (fun j ->
                   let A'j = A.Column j
                   let c'j = c.[j]
              
                   y.Transpose 
                   |> Vector.dot A'j
                   |> (fun num -> num - c'j) 
                 ) 

  let ``J'n+``, ``J'n-`` = 
    J'n |> List.partition (fun j -> 
             let delta'j = delta.[j]
             j >= 0
           )

  let x'n = J'n 
            |> List.map (fun j ->
                 match j with
                 | In ``J'n+`` -> d'down.[j]
                 | In ``J'n-`` -> d'up.[j]
               )    

  let x'b = J'n 
            |> Seq.map (fun j ->
                 let A'j = A.Column j
                 let x'j = x'n.[j]
               
                 A'j * x'j
               ) 
            |> Seq.reduce (+)
            |> (fun sum ->
                 B * (b - sum)
               )

  let x = J |> List.map (fun j -> 
                 match j with
                 | In J'b -> x'b.[j]
                 | In J'n -> x'n.[j]
                 | _ -> failwith "No more indices expected."
               )

  let criteriaRes = 
    J |> List.map (fun j ->
           let x'j = x.[j] 
           let min = d'down.[j]
           let max = d'up.[j]
           let satisfiesDown = min <= x'j
           let satisfiesUp = x'j <= max

           let satisfies = satisfiesDown && satisfiesUp
           let m'j = if satisfies then 0.0
                     else if satisfiesUp then -1.0
                     else 1.0

           j, satisfies, m'j
         ) 

  let isOptimal = criteriaRes 
                  |> Seq.map snd3 
                  |> Seq.reduce (&&)

  match isOptimal with
  | true -> Some(x)
  | false ->
      let (j'k, _, m'jk) = criteriaRes 
                           |> List.find (snd3 >> not)

      let k = J |> List.find ((=) j'k)
      let e'k = RowVector.E m k
      let delta'y = m'jk * (e'k * B)

      //todo must have length as J, cause using indexation for access
      let M = J'n |> List.map (fun j -> 
                       let A'j = A.Column j
                       delta'y * A'j
                     )
      
      let steps = 
        J'n |> Seq.map (fun j -> 
                 let m'j = M.[j]
                 match (j, m'j) with
                 | (In ``J'n+``, Less 0.0) 
                 | (In ``J'n-``, Bigger 0.0) -> 
                    let delta'j = delta.[j]
                    j, -delta'j / m'j
                 | _ -> j, infinity
               )

      let (j'0, step'0) = steps |> Seq.minBy snd

      match step'0 with
      | Equals infinity -> None
      | _ -> 
        let newY = J 
                   |> List.map (fun j -> 
                        match j with
                        | In J'n | Equals j'k -> 
                            let y'j = y.[j]
                            let m'j = M.[j]
                            y'j + step'0 * m'j
                        | In J'b -> 0.0
                        | _ -> failwith "No more indices expected"
                      )

        let newJ'b = J'b |> List.replace j'k j'0 
        let newJ'n = J |> List.without newJ'b
        let ``newJ'n+`` = match (m'jk, j'0) with
                          | (1.0, In ``J'n+``) -> ``J'n+`` |> List.replace j'0 j'k
                          | (-1.0, In ``J'n+``) -> ``J'n+`` |> List.without [j'0]
                          | (1.0, NotIn ``J'n+``) -> j'k :: ``J'n+`` 
                          | _ -> failwith "No more variants expected"

        let ``newJ'n-`` = newJ'n |> List.without ``newJ'n+``

        //todo change input parameters
        // todo define outer func
        None


      







                
  

