  function printInReversedOrder(args){
    let stack = [];
    for (var i = 0; i < args.length; i++) {
      stack.push(args[i]);
    }

    while (stack.length>0) {
      console.log(stack.pop());
    }
  }
