﻿module Optimization.Tests.case
open Optimization.Gomory
open Optimization.FloatOperators

let case0 () =
  let c = rowvec [2.0; -5.0; 0.0; 0.0; 0.0;]
  
  let A = matrix [[-2.0; -1.0; 1.0; 0.0; 0.0];
                  [ 3.0;  1.0; 0.0; 1.0; 0.0;];
                  [-1.0;  1.0; 0.0; 0.0; 1.0]]

  let b = vector [-1.0; 
                   10.0; 
                   3.0]

  let J = [0..A.NumCols - 1]
  let I = J
  
  ()

let case01 () =
  let c = rowvec [21.0; 11.0; 0.0]
  let A = matrix [[7.0; 4.0; 1.0;]]

  let b = vector [13.0;] 
  let I = [0..c.Length - 1]
  
  ()

let case1 () =
  let c = rowvec [7.0; -2.0; 6.0; 0.0; 5.0; 2.0;]
  
  let A = matrix [[1.0; -5.0; 3.0; 1.0; 0.0; 0.0;];
                  [4.0; -1.0; 1.0; 0.0; 1.0; 0.0;];
                  [2.0;  4.0; 2.0; 0.0; 0.0; 1.0;];]

  let b = vector [-8.0; 
                  22.0; 
                  30.0]

  let I = [0..A.NumCols - 1]
  let expected = Some (rowvec [1.0; 1.0; 1.0; 1.0; 1.0; 1.0; 1.0;])
  
  ((A, b, c, I), expected)

let case2 () =
  let c = rowvec [-1.0; 5.0; -2.0; 4.0; 3.0; 1.0; 2.0; 8.0; 3.0]
  
  let A = matrix [[1.0; -3.0;  2.0; 0.0; 1.0; -1.0; 4.0; -1.0; 0.0;];  
                  [1.0; -1.0;  6.0; 1.0; 0.0; -2.0; 2.0;  2.0; 0.0;];  
                  [2.0;  2.0; -1.0; 1.0; 0.0; -3.0; 8.0; -1.0; 1.0;];  
                  [4.0;  1.0;  0.0; 0.0; 1.0; -1.0; 0.0; -1.0; 1.0;];  
                  [1.0;  1.0;  1.0; 1.0; 1.0;  1.0; 1.0;  1.0; 1.0;];]

  let b = vector [3.0; 
                  9.0; 
                  9.0;
                  5.0;
                  9.0;]

  let I = [0..A.NumCols - 1]
  let expected = Some (rowvec [1.0; 1.0; 1.0; 1.0; 1.0; 1.0; 1.0;])
  
  ((A, b, c, I), expected)

let case3 () =
  let c = rowvec [2.0; 1.0; -2.0; -1.0; 4.0; -5.0; 5.0; 5.0]
  
  let A = matrix [[1.0; 0.0; 0.0; 12.0;  1.0; -3.0;  4.0; -1.0;]
                  [0.0; 1.0; 0.0; 11.0; 12.0;  3.0;  5.0;  3.0;] 
                  [0.0; 0.0; 1.0;  1.0;  0.0; 22.0; -2.0;  1.0;];]

  let b = vector [ 40.0;
                  107.0;
                   61.0;]

  let I = [0..A.NumCols - 1]
  let expected = Some (rowvec [1.0; 1.0; 1.0; 1.0; 1.0; 1.0; 1.0;])
  
  ((A, b, c, I), expected)

let case4 () =
  let c = rowvec [2.0; 1.0; -2.0; -1.0; 4.0; -5.0; 5.0; 5.0; 1.0; 2.0]
  
  let A = matrix [[1.0; 2.0; 3.0; 12.0;  1.0; -3.0;  4.0; -1.0; 2.0; 3.0;];
                  [0.0; 2.0; 0.0; 11.0; 12.0;  3.0;  5.0;  3.0; 4.0; 5.0;]; 
                  [0.0; 0.0; 2.0;  1.0;  0.0; 22.0; -2.0;  1.0; 6.0; 7.0;];]

  let b = vector [153.0;
                  123.0;
                  112.0;]

  let I = [0..A.NumCols - 1]
  let expected = Some (rowvec [1.0; 1.0; 1.0; 1.0; 1.0; 1.0; 1.0;])
  
  ((A, b, c, I), expected)

let case5 () =
  let c = rowvec [1.0; 2.0; 1.0; -1.0; 2.0; 3.0;]
  
  let A = matrix [[2.0;  1.0; -1.0; -3.0; 4.0; 7.0;];
                  [0.0;  1.0;  1.0;  1.0; 2.0; 4.0;];
                  [6.0; -3.0; -2.0;  1.0; 1.0; 1.0;];]

  let b = vector [7.0;
                  16.0;
                  6.0;]

  let I = [0..A.NumCols - 1]
  let expected = Some (rowvec [5.0; 1.0; 11.0; 0.0; 0.0; 1.0;])

  ((A, b, c, I), expected)

let case6 () =
  let c = rowvec [10.0; 2.0; 1.0; 7.0; 6.0; 3.0; 1.0;]
  
  let A = matrix [[0.0; 7.0; 1.0; -1.0; -4.0; 2.0; 4.0];  
                  [5.0; 1.0; 4.0;  3.0; -5.0; 2.0; 1.0]; 
                  [2.0; 0.0; 3.0;  1.0;  0.0; 1.0; 5.0];]

  let b = vector [12.0;
                  27.0;
                  19.0;]

  let I = [0..A.NumCols - 1]
  let expected = Some (rowvec [5.0; 6.0; 0.0; 8.0; 6.0; 1.0; 0.0;])

  ((A, b, c, I), expected)

let case7 () =
  let c = rowvec [2.0; 9.0; 3.0; 5.0; 1.0; 2.0; 4.0;]
  
  let A = matrix [[0.0; 7.0; -8.0; -1.0;  5.0; 2.0; 1.0;];
                  [3.0; 2.0;  1.0; -3.0; -1.0; 1.0; 0.0;]; 
                  [1.0; 5.0;  3.0; -1.0; -2.0; 1.0; 0.0;]; 
                  [1.0; 1.0;  1.0;  1.0;  1.0; 1.0; 1.0;];]

  let b = vector [6.0;
                  3.0;
                  7.0;
                  7.0;]

  let I = [0..A.NumCols - 1]
  let expected = Some (rowvec [1.0; 1.0; 1.0; 1.0; 1.0; 1.0; 1.0;])

  ((A, b, c, I), expected)

let case8 () =
  let c = rowvec [-1.0; -3.0; -7.0; 0.0; -4.0; 0.0; -1.0;]
  
  let A = matrix [[1.0; 0.0; -1.0;  3.0; -2.0; 0.0;  1.0;]; 
                  [0.0; 2.0;  1.0; -1.0;  0.0; 3.0; -1.0;];
                  [1.0; 2.0;  1.0;  4.0;  2.0; 1.0;  1.0;];]

  let b = vector [4.0;
                  8.0;
                  24.0;]

  let I = [0..A.NumCols - 1]
  let expected = Some (rowvec [1.0; 1.0; 0.0; 3.0; 3.0; 3.0; 0.0;])

  ((A, b, c, I), expected)

let case9 () =
  let c = rowvec [-1.0; 5.0; -2.0; 4.0; 3.0; 1.0; 2.0; 8.0; 3.0;]
  
  let A = matrix [[1.0; -3.0;  2.0; 0.0; 1.0; -1.0; 4.0; -1.0; 0.0;]; 
                  [1.0; -1.0;  6.0; 1.0; 0.0; -2.0; 2.0;  2.0; 0.0;]; 
                  [2.0;  2.0; -1.0; 1.0; 0.0; -3.0; 2.0; -1.0; 1.0;]; 
                  [4.0;  1.0;  0.0; 0.0; 1.0; -1.0; 0.0; -1.0; 1.0;]; 
                  [1.0;  1.0;  1.0; 1.0; 1.0;  1.0; 1.0;  1.0; 1.0;];]

  let b = vector [3.0;
                  9.0;
                  9.0;
                  5.0;
                  9.0;]

  let I = [0..A.NumCols - 1]
  let expected = Some (rowvec [0.0; 1.0; 1.0; 2.0; 0.0; 0.0; 1.0; 0.0; 4.0;])

  ((A, b, c, I), expected)

let test data = 
  let (task, expected) = data
  let result = task |> gomory

  match expected, result with
  | (None, None) -> true
  | (Some _, None) -> false
  | (None, Some _) -> false
  | (Some expected, Some result) -> 
    
    if not (result |> equalSeq expected) then false
    else true

let cases = 
  [case1;
   case2;
   case3;
   case4;
   case5;
   case6;
   case7;
   case8;
   case9;]

let results =
  cases
  |> Seq.map ((|>) ())
  |> Seq.map (fun data ->
       printfn "Test started"
       test data
     )
  |> Seq.toList

let succeed = results |> Seq.forall id

if not succeed then
  let fails = 
    results
    |> Seq.mapi (fun i res -> i, res) 
    |> Seq.filter (id << not << snd)
    |> Seq.map fst 
    |> Seq.fold (fun st i -> sprintf "%s №%d," st i) ""

  failwith <| sprintf "Tests %s failed" fails
