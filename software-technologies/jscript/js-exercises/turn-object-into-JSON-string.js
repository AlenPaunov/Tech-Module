function solve(args) {
  let obj = {}
  for (var i = 0; i < args.length; i++) {
    let pair = args[i].split(" -> ");
    let value = pair[1];
    if (!Number.isNaN(Number(value))) {
      value = Number(value);
    }
    obj[pair[0]] = value;
  }
  console.log(JSON.stringify(obj));
}
