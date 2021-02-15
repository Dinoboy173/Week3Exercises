using System;

namespace Week3Exercises
{

    class Animal
    {
        public string name = "";

        public Animal(string name)
        {
            this.name = name;
        }
        public virtual void MakeNoise()
        {
            Console.WriteLine(name + ": makes noise");
        }
    }

    class Dog : Animal
    {
        public Dog() : base("Dog")
        {
        }
        public override void MakeNoise()
        {
            Console.WriteLine("WOOF WOOF WOOF");
        }
    }

    class Cat : Animal
    {
        public Cat() : base("Cat")
        {
        }
    }
    
    class Bird : Animal
    { 
       public Bird() : base("Bird")
       {
       }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Dog dog = new Dog();
            // dog.MakeNoise();
            // 
            // Cat cat = new Cat();
            // cat.MakeNoise();
            // 
            // Bird bird = new Bird();
            // bird.MakeNoise();
            // 
            // Animal someAnimal = new Animal("animal");
            // someAnimal.MakeNoise();

            Animal dog = new Dog();
            Animal cat = new Cat();
            Animal bird = new Bird();

            dog.MakeNoise();
            cat.MakeNoise(); 
            bird.MakeNoise();
        }
    }
}
