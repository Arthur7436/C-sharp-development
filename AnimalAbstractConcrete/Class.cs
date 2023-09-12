namespace AnimalAbstractConcrete.AnimalClass
{
    public abstract class AnimalClass
    {
        public abstract string Speak();
        public abstract string Name();
        public abstract string Eat();
    }

    public class Lion : AnimalClass
    {
        public override string Speak()
        {
            return "This is a Lion... ROAR!!";
        }

        public override string Name()
        {
            return "The Lion's name is LEO!!";
        }

        public override string Eat()
        {
            return "The lion is eating now...";
        }
    }
}