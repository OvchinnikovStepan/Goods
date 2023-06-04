namespace Goods
{
    internal class Program
    {
        class Good
        {
            public int Id;
            public string name;
            public Good(int Id,string name)
            {
                this.Id = Id;
                this.name = name;
            }
        }
        class Trader
        {
            public int Id;
            public string name;
            public Trader(int Id,string name)
            {
                this.Id = Id;
                this.name = name;
            }
        }
        class Deal
        {
            public int good;
            public int trader;
            public int number;
            public string date;
            public Deal(int good,int trader, int number, string date)
            {
                this.good = good;
                this.trader =trader;
                this.number = number;
                this.date = date;
            }
        }
        static void Main(string[] args)
        {
           List<Good> list_good = new List<Good>();
           List<Trader> list_trader = new List<Trader>();
           List<Deal> list_deal = new List<Deal>();

           while (true)
            {
                Console.WriteLine(@"
1.Добавить поставщика
2.Добавить товар
3.Добавить поставку
4.Поиск по дате
5.Поиск по товару
6.Поиск по поcтавщику
7.Выход");
                string a=Console.ReadLine();
                if (a == "1")
                {
                    string name=Console.ReadLine();
                    list_trader.Add(new Trader(list_trader.Count+1,name));
                }
                else if (a == "2")
                {
                    string name=Console.ReadLine();
                    list_good.Add(new Good(list_good.Count+1,name));
                }
                else if (a == "3")
                {
                    int good =Convert.ToInt32( Console.ReadLine());
                    int trader = Convert.ToInt32(Console.ReadLine());
                    int number = Convert.ToInt32( Console.ReadLine());
                    string date = Console.ReadLine();
                    list_deal.Add(new Deal(good,trader,number,date));
                }
                else if(a == "4")
                {
                    string date=Console.ReadLine();
                    for (int i=0;i<list_deal.Count;i++) 
                    {
                        if (list_deal[i].date == date)
                        {
                            Console.WriteLine("Номер товара:{0}\nНомер поставщика{1}\nКоличество товара:{2}",
                                list_deal[i].good, list_deal[i].trader, list_deal[i].number);
                        }
                    }
                }
                else if(a=="5")
                {
                    SortedSet<string> A=new SortedSet<string>();
                    int id = Convert.ToInt32( Console.ReadLine());
                    for (int i=0;i < list_deal.Count;i++)
                    {
                        if (list_deal[i].good == id)
                        {
                            for (int j = 0; j < list_trader.Count; j++)
                            {
                                if (list_deal[i].trader == list_trader[j].Id) 
                                {
                                    A.Add(list_trader[j].name);
                                }
                            }
                        }
                    }
                    foreach(string s in A)
                    {
                        Console.WriteLine(s);
                    }
                }
                else if(a == "6")
                {
                    SortedSet<string> A = new SortedSet<string>();
                    int id = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < list_deal.Count; i++)
                    {
                        if (list_deal[i].trader == id)
                        {
                            for (int j = 0; j < list_good.Count; j++)
                            {
                                if (list_deal[i].good == list_good[j].Id)
                                {
                                    A.Add(list_good[j].name);
                                }
                            }
                        }
                    }
                    foreach (string s in A)
                    {
                        Console.WriteLine(s);
                    }
                }
                else if (a == "7")
                {
                    break;
                }
                Console.Clear();
            }
        }
    }
}