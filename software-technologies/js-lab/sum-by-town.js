function solve(args) {
    let objs= args.map(JSON.parse);
    let towns = {};

    for (let obj of objs) {
        if(obj.town in towns){
            towns[obj.town]+=obj.income;
        }else {
            towns[obj.town]=obj.income;
        }
    }

    let sorted=Object.keys(towns).sort();
    for(let town of sorted){
        console.log(`${town} -> ${towns[town]}`)
    }
}
