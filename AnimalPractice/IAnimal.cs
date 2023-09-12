namespace Animals
{
    interface Animal
    {
        string Speak();
        string Eat();
    }
    public class Dog : Animal
    {
        public string _name;

        public Dog(string name)
        {
            _name = name;
        }

        public string Eat()
        {
            return $"{_name} is eating";
        }

        public string Speak()
        {
            return "Woof!";
        }
    }

    public class Cat : Animal
    {
        public string _name;
        public Cat(string name)
        {
            _name = name;
        }

        public string Eat()
        {
            return $"{_name} is eating";
        }
        public string Speak()
        {
            return $"Meow!";
        }
    }

}