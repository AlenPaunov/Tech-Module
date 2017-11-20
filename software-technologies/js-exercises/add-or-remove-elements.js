function addRemoveElement(args){
  var arr = [];

  args.forEach(function(elem) {
    let params = elem.split(' ');
    if (params[0]==="add") {
      arr.push(Number(params[1]))
    }
    else if (params[0]==="remove") {
      arr.splice(Number(params[1]),1);
    }
  });

  arr.forEach(function(elem) {
    console.log(elem);
  });
}
