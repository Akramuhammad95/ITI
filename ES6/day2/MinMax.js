export function MinMax(...arr) {
    let max = arr[0];
    let min = arr[0];

    for (const element of arr) {
        if (element > max) {
            max = element;
        }

        if (element < min) {
            min = element;
        }
    }

    return { max, min };
}