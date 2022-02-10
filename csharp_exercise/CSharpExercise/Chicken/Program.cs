using System;

namespace Chicken
{
    public interface IBird
    {
        Egg Lay();
    }

    public class Chicken : IBird
    {
        public Chicken() {}
            
        public Egg Lay()
        {
           return new Egg(new Func<Chicken>(() => new Chicken()));
        }

    }

    public class Egg
    {
        int hatchCount = 0;
        Func<IBird> create;
        
        public Egg(Func<IBird> createBird)
        {   
            this.create = createBird;
           
        }

        public IBird Hatch()
        {
            if (this.hatchCount > 0)
            {
                throw new System.InvalidOperationException();
            }

            this.hatchCount++;
            return this.create();
        }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var chicken1 = new Chicken();
            var egg = chicken1.Lay();
            var childChicken = egg.Hatch();
            Console.ReadLine();
        }
    }
}
