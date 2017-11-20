function solve(args){
  let dict = {};
  for (var i = 0; i < args.length-1; i++) {
    let pair = args[i].split(' ');
    dict[pair[0]]=pair[1];
  }

  if (args[args.length-1] in dict) {
    console.log(dict[args[args.length-1]]);
  }
  else {
    console.log("None");
  }
}
