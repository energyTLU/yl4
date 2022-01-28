using System;


namespace ConsoleApp4
{
    
    public class Menu
    {
        public Drinks Drinks { get; }
        public Money Money { get; }

        public Menu()
        {
            this.Drinks = new Drinks();
            this.Money = new Money();

        }
        

        public decimal MoneyInMachine
        {
            get
            {
                return this.Money.MoneyInMachine;
            }
        }

        public object[] drink { get; set; }

        public void Display()
        {
            Drinks d = new ();
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.WriteLine($"Money in Machine: {this.MoneyInMachine.ToString()} Euros");
                Console.WriteLine("1. Display drink machine items");
                Console.WriteLine("2. Insert coins");
                Console.WriteLine("3. End transaction");
                Console.WriteLine("\nQ. Quit");
                Console.Write("\n\nInput: ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("Displaying Items");
                    this.drink = d.DisplayDrinks(MoneyInMachine);
                    if (this.drink is object[]) {
              
                        decimal price = (decimal)drink[1];
                        this.Money.RemoveMoney(price);
                        Console.Clear();
                        Console.WriteLine($"Making drink {drink[0]}. (Contents: {drink[2]} ml Water, {drink[3]} grams Coffee, {drink[4]} ml Milk, {drink[5]} ml Frothed Milk, {drink[6]} grams Cocoa powder. Sugar: {drink[7]}. Own cup: {drink[8]})");
                        Console.WriteLine($"You have {MoneyInMachine} euro(s) left.");

                    }
                    if (input != "")
                    {
                        
                    }

                }
                else if (input == "2")
                
                    
                {
                    Console.Clear();
                    Console.WriteLine(">>> How much do you want to insert?");
                    while (true)
                    {
                        

                        Console.WriteLine("1) 10 cents");
                        Console.WriteLine("2) 20 cents");
                        Console.WriteLine("3) 50 cents");
                        Console.WriteLine("4) 1 euro");
                        Console.WriteLine("5) 2 euros");
                        Console.WriteLine("\nQ) Back");

                        Console.WriteLine($"Money in machine: {this.Money.MoneyInMachine.ToString()} Euros");
                        input = Console.ReadLine();
                        string amountToAdd = "0";
                        if (input == "1")
                        {
                            amountToAdd = "0.10";
                        }
                        else if (input == "2")
                        {
                            amountToAdd = "0.20";
                        }
                        else if (input == "3")
                        {
                            amountToAdd = "0.50";
                        }
                        else if (input == "4")
                        {
                            amountToAdd = "1";
                        }
                        else if (input == "5")
                        {
                            amountToAdd = "2";
                        }
                        else if (input != "")
                        {
                            Console.Clear();
                            Console.WriteLine("Try again");
                        }
                        else if (input.ToUpper() == "Q")
                        {
                            break;
                            
                        }


                        if (this.Money.AddMoney(amountToAdd))
                        {
                            Console.Clear();
                            
                        }
                        
                        if (input.ToUpper() == "Q")
                        {
                            break;
                        }
                        
                    }

                }
                else if (input == "3")
                {
                    Console.Clear();
                    Console.WriteLine(Money.GiveChange()); 
                }


                else if (input.ToUpper() == "Q")
                {
                    Console.WriteLine("Quitting");
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Try again");
                    
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
