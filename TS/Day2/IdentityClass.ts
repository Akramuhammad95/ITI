//generic class implement interface  IidentityFn
export class IdentityClass<T> {
    //generic function
    identity(arg: T): T {
        return arg;
    }
    
}
