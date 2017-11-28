function printLines(args){
  for (var i = 0; i < args.length; i++) {
    if (args[i]== "Stop") {
      return;
    }
    else{
      console.log(args[i]);
    }
  }
}
