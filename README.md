My understanding of constructors is that whenever you choose to instantiaze an object, the properties within the constructor can be immediateley used?

E.g. 
namespace IExample;

public instance IExample{
    string WordCombine();
}

public Class Example{
    public string x;
    public string y;
    
    public Example(string A, string B){
        x = A;
        y = B;
    }

    public string WordCombine(){
        return $"{x} {y}";
    }
}


Program file...
using IExample;

{
Example new = new Example(Hello, World);
Console.WriteLine(new.WordCombine);
}
