using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApp4
{
    static class Extensions
    {
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
        => self.Select((item, index) => (item, index));
    }

    

    public class Drinks
    {
        public Money Money { get; }

        public decimal MoneyInMachine
        {
            get
            {
                return this.Money.MoneyInMachine;
            }
        }
        public Drinks()
        {
            this.Money = new Money();

        }
        public string name { get; set; }
        public decimal price { get; set; }
        public int water_ml { get; set; }
        public int coffee_g { get; set; }
        public int milk_ml { get; set; }
        public int frothed_milk_ml { get; set; }
        public int cocoa_g { get; set; }
        public object drink { get; private set; }


        public object[] DisplayDrinks(decimal MoneyInMachine)

        {
            List<Drinks> drinks = new List<Drinks>(4);
            

            Drinks BlackCoffee = new ();
            BlackCoffee.name = "Black Coffee";
            BlackCoffee.price = 1.5M;
            BlackCoffee.water_ml = 50;
            BlackCoffee.coffee_g = 7;
           

            Drinks Cappucino = new();
            Cappucino.name = "Cappucino";
            Cappucino.price = 2M;
            Cappucino.water_ml = 50;
            Cappucino.coffee_g = 7;
            Cappucino.frothed_milk_ml = 20;
            

            Drinks MilkCoffee = new();
            MilkCoffee.name = "Milk Coffee";
            MilkCoffee.price = 1.5M;
            MilkCoffee.water_ml = 50;
            MilkCoffee.coffee_g = 7;
            MilkCoffee.milk_ml = 20;

            Drinks Cocoa = new();
            Cocoa.name = "Cocoa";
            Cocoa.price = 1M;
            Cocoa.milk_ml = 50;
            Cocoa.cocoa_g = 10;

            drinks.Add(BlackCoffee);
            drinks.Add(Cappucino);
            drinks.Add(MilkCoffee);
            drinks.Add(Cocoa);

            
            
            Console.Clear();
            
            

            Console.WriteLine($"\n\nMoney: { MoneyInMachine } Euro(s)");
            Console.WriteLine($"\n{ "#  Product".PadRight(20) } { "Price"}\n");
            foreach (var (drink, index) in drinks.WithIndex())
            {
                var index_ = index;

                string name = drink.name.PadRight(17);
                string price = drink.price + " Euro(s)";

                Console.WriteLine($"{index+1}. {name} {price}");
            }
            Console.WriteLine("\nQ. Back");

            Console.Write("\nSelect option to buy: ");

            string input = Console.ReadLine();
            
            

            int num;
            int.TryParse(input, out num);
            if (input.ToUpper() == "Q") { return null; }
            while (num > 4 || num < 1 || !int.TryParse(input, out _))
            {
                Console.Write("Select option to buy (try again): ");
                input = Console.ReadLine();

                int.TryParse(input, out num);
                
            }
            
            var array = drinks[num - 1];
            if (MoneyInMachine >= array.price) { 
                this.drink = array;
                object[] data = new object[9];
                data[0] = array.name;
                data[1] = array.price;
                data[2] = array.water_ml;
                data[3] = array.coffee_g;
                data[4] = array.milk_ml;
                data[5] = array.frothed_milk_ml;
                data[6] = array.cocoa_g;

                Console.Clear();
                Console.WriteLine("How much sugar?");
                Console.WriteLine("1. 1");
                Console.WriteLine("2. 2");
                Console.WriteLine("3. 3");
                Console.WriteLine("4. No sugar\n");
                Console.Write("Input: ");
                input = Console.ReadLine();
                        
                        
                int.TryParse(input, out num);
                while (num > 4 || num < 1 || !int.TryParse(input, out _)) 
                {
                    Console.Write("Input (try again): ");
                    input = Console.ReadLine();

                    int.TryParse(input, out num);
                }


                        
                            
                data[7] = input;
                if (input == "4")
                {
                    data[7] = "No Sugar (No stirring stick)";
                }
                            
                            
                Console.Clear();
                Console.WriteLine("Are you using your own cup?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                Console.Write("Input: ");
                input = Console.ReadLine();

                
                int.TryParse(input, out num);
                
                while (num > 2 || num < 1 || !int.TryParse(input, out _))
                {
                    Console.Write("Input (try again): ");
                    input = Console.ReadLine();

                    int.TryParse(input, out num);

                }
                
                data[8] = input;
                if (input == "1")
                {
                    data[8] = "Yes";
                }
                else if (input == "2")
                {
                    data[8] = "No (Adding cup)";
                }
                return data;
                
                        
                        

            } else
            {
                Console.Clear();
                Console.WriteLine("Not enough money.");
                return null;
            }

                
                  

            


        }

        


    }
}
