# fibonacci-benchmark
This simple console application will compare 2 recursive approaches to calculate the *n*-th fibonacci number.

### Naive approach
Just a recursive function, with no data-storing.
* Time complexity: O(2<sup>n</sup>)
* Space complexity
  * Stack: O(n)

```javascript
function fib(n) {
  if(n == 0) return 0;
  if(n == 1) return 1;
  
  return fib(n-1) + fib(n-2);
}
```

### More performant approach
To improve the above algorithm an extra data structure will be used.  
This data structure is a key/value-pair-like structure which will store previous computed fibonacci numbers.
* Time complexity: O(n)
* Space complexity
  * Stack: O(n)
  * Dictionary: O(n)
  
```javascript
var keyValue<int, int> kvp;

function fib(n) {
  if(n == 0) return 0;
  if(n == 1) return 1;
  
  if(kvp.containsKey(n) return kvp.getValue(n);
  
  var result = fib(n-1) + fib(n-2);
  
  kvp.addKeyValue(n, result);
  
  return result;
}
```
#### Improvements
* Use an array instead of a key value pair. This way the used space will be a half.
  * In Big O notation dividing by 2 have no effect on space complexity, but in absolute terms it has.
