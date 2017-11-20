function solve(args){
  var objs = []
  args.forEach(function(elem) {
    objs.push(JSON.parse(elem))
  });
  objs.forEach(function(person) {
    console.log("Name: "+person.name);
    console.log("Age: "+person.age);
    console.log("Date: "+person.date);
  });
}
