function solve(args){
  var dict = {};
  for (var i = 0; i < args.length-1; i++) {
    let pair = args[i].split(' ');
    let key = pair[0];
    let value = pair[1];
    if (!(key in dict)) {
      dict[key] = [];
    }
    dict[key].push(value);
  }
  if (args[args.length-1] in dict) {
    dict[args[args.length-1]].forEach(function(elem) {
      console.log(elem);
    });
  }
  else {
    console.log("None");
  }
}
