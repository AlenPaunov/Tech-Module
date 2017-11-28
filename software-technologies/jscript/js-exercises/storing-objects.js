function solve(args){
  let persons = [];
  args.forEach(function(elem) {
    let params = elem.split(' -> ')
    persons.push({name:params[0], age:Number(params[1]), grade: params[2]})
  });

  persons.forEach(function(person) {
    console.log("Name: "+person.name);
    console.log("Age: "+person.age);
    console.log("Grade: "+person.grade);
  });

}
