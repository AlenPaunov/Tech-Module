function solve(args) {
    let upperCaseWords = args
        .join(' ')
        .split(/\W+/)
        .filter(x=>x.length>0)
        .filter(x=>x === x.toUpperCase());

    console.log(upperCaseWords.join(', '));
}
