function solve(args){
  let len = Number(args[0]);
  let arr = [];
  for (let i = 0; i < len; i++) {
    arr[i] = 0;
  }

  for (let i = 1; i < args.length; i++) {
    let params = args[i].split(' - ').map(Number);
    arr[params[0]] = params[1] ;
  }
  arr.forEach(function(elem) {
    console.log(elem);
  });
}
