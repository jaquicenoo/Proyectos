class WithOutHash {

    constructor() {
        this.list = [];
    }

    get(x) {
        let result;
        this.list.forEach(pairs => {
            if (pairs[0] === x) {
                result = pairs[1];
            }
        });
        return result;
    }

    set(x, y) {
        this.list.push([x, y]);
    }
}

class WithHash {
    constructor() {
        this.list = [];
    }

    get(x) {
        return this.list[this.hashCode(x)];
    }

    set(x, y) {
        this.list[this.hashCode(x)] = y;
    }

    hashCode(s) {
        return s.split("").reduce(function(a, b) { a = ((a << 5) - a) + b.charCodeAt(0); return a & a }, 0);
    }
}

let m = new WithOutHash();

for (x = 0; x < 100000; x++) {
    m.set(`element${x}`, x);
}


console.time('tiempo que tardo sin hash');
m.get('I_DONT_EXIST');
console.timeEnd('tiempo que tardo sin hash');
console.log(m.get('element10'));
console.log(m.list);



let s = new WithHash();

for (x = 0; x < 100000; x++) {
    s.set(`element${x}`, x);
}

console.time('tiempo que tardo con hash');
s.get('I_DONT_EXIST');
console.timeEnd('tiempo que tardo con hash');
console.log(m.get('element10'));
console.log(s.list);