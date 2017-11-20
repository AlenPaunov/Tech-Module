function solve(args) {
  let numbers = args.map(Number);
  let n = numbers[0];
  let x = numbers[1];
  let result;

  if (x>=n) {
    result = n*x;
  }
  else {
    result = n/x;
  }

  console.log(result);
}
