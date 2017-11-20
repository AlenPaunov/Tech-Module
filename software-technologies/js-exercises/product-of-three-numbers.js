function checkProductPolaris(args){
  if (args.map(Number).filter(function(a){return a<0;}).length%2!=0) {
    console.log("Negative");
  }
  else {
    console.log("Positive");
  }
}
