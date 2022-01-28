
using System;
namespace ConsoleApp4
{
     
    public class Money
    {
       

        public Money()
        {
            this.MoneyInMachine = 0;
            
           
        }
        

        public decimal MoneyInMachine { get; private set; }

        


        public bool AddMoney(string amount)
        {
            if (!decimal.TryParse(amount, out decimal amountInserted))
            {
                amountInserted = 0;
                return false;
            }

            this.MoneyInMachine += amountInserted;


            return true;
        }

        public bool RemoveMoney(decimal amountToRemove)
        {
            if (this.MoneyInMachine <= 0)
            {
                return false;
            }

            this.MoneyInMachine -= amountToRemove;
            return true;
        }

        public string GiveChange()
        {
            string result = string.Empty;
            
            int s_50 = 0;
            int s_20 = 0;
            int s_10 = 0;





            
            if (this.MoneyInMachine > 0)
            {
                while (this.MoneyInMachine > 0)
                {
                    

                    if (this.MoneyInMachine >= 0.50M)
                    {
                        s_50++;
                        this.RemoveMoney(0.50M);
                    }
                    else if (this.MoneyInMachine >= 0.20M)
                    {
                        s_20++;
                        this.RemoveMoney(0.20M);
                    }
                    else if (this.MoneyInMachine >= 0.10M)
                    {
                        s_10++;
                        this.RemoveMoney(0.10M);
                    }
                }

                result = GetMessage(s_50, s_20, s_10);

                

                
            }
            else
            {
                result = "No change.";
            }

            return result;
        }

        private string GetMessage(int s_50, int s_20, int s_10)
        {
            
            string string_50 = string.Empty;
            string string_20 = string.Empty;
            string string_10 = string.Empty;

            

            if (s_50 > 0)
            {
                string_50 = $"{s_50} x 50 cents";
            }

            if (s_20 > 0)
            {
                string_20 = $"{s_20} x 20 cents";
            }

            if (s_10 > 0)
            {
                string_10 = $"{s_10} x 10 cents";
            }

            string result = $"Your change: ";

            

            if (s_50 > 0 && s_20 > 0 && s_10 > 0)
            {
                result += $"{string_50}, {string_20} and {string_10}";
            }
            else if (s_50 > 0 && s_10 > 0)
            {
                result += $"{string_50} and {string_10}";
            }
            else if (s_50 > 0 && s_20 > 0)
            {
                result += $"{string_50} and {string_20}";
            }
            else if (s_20 > 0 && s_10 > 0)
            {
                result += $"{string_20} and {string_10}";
            }
            else if (s_50 > 0 || s_20 > 0 || s_10 > 0)
            {
                result += $"{string_50}{string_20}{string_10}";
            }
            else if (s_50 > 0 && s_20 == 0 && s_10 == 0 )
            {
                result = "No change.";
            }

            return result;
        }
    }
}
