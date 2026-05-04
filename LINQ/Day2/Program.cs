using L2O___D09;
using System.Xml;
using System.Xml.Linq;

namespace LinqLab2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var OutOfStock = ListGenerators.ProductList.Where(p => p.UnitsInStock == 0).ToList();
            foreach (var item in OutOfStock)
            {
                Console.WriteLine(item);
            }

            ===============================================================================

            var InStockAndMoreThan3PU = ListGenerators.ProductList.Where(p => p.UnitsInStock != 0 && p.UnitPrice > 3.00M).ToList();
            foreach (var item in InStockAndMoreThan3PU)
            {
                Console.WriteLine(item);
            }

            ==============================================================================

            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }
            ;

            var result = Arr
                .Select((value, index) => new { value, index })
                .Where(x => x.value.Length < x.index)
                .Select(x => x.value);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            ==============================================================================

            var FirstpOutOfStock = ListGenerators.ProductList.FirstOrDefault(p => p.UnitsInStock == 0);
            Console.WriteLine(FirstpOutOfStock);

            ==============================================================================

            var SinglepPrice = ListGenerators.ProductList.SingleOrDefault(p => p.UnitPrice > 1000m);
            Console.WriteLine(SinglepPrice);

            ==============================================================================

            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }
            ;

            var x = Arr.Where(n => n > 5).ElementAt(1);

            Console.WriteLine(x);

            ==============================================================================

            var UniqueCat = ListGenerators.ProductList.Select(p => p.Category).Distinct().ToList();

            foreach (var item in UniqueCat)
            {
                Console.WriteLine(item);
            }

            ==============================================================================

            var x = ListGenerators.ProductList.Select(p => p.ProductName);
            var y = ListGenerators.CustomerList.Select(p => p.CustomerName);

            var res = x.Select(p => p[0]).Union(y.Select(p => p[0])).ToList();
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }

            ==============================================================================

            var x = ListGenerators.ProductList.Select(p => p.ProductName);
            var y = ListGenerators.CustomerList.Select(p => p.CustomerName);

            var res = x.Select(p => p[0]).Intersect(y.Select(p => p[0])).ToList();
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }

            =============================================================================

            var x = ListGenerators.ProductList.Select(p => p.ProductName);
            var y = ListGenerators.CustomerList.Select(p => p.CustomerName);

            var res = x.Select(p => p[0]).Except(y.Select(p => p[0])).ToList();
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }

            =============================================================================

            var x = ListGenerators.ProductList.Select(p => p.ProductName);
            var y = ListGenerators.CustomerList.Select(p => p.CustomerName);

            var res =
            x.Select(p => p.Length >= 3 ? p.Substring(p.Length - 3) : p)
            .Concat(y.Select(c => c.Length >= 3 ? c.Substring(c.Length - 3) : c)).ToList();

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }

            =============================================================================

            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }
            ;

            var x = Arr.Count(p => p % 2 != 0);
            Console.WriteLine(x);

            =============================================================================

            var x = ListGenerators.CustomerList.Select(p => new
            {
                name = p.CustomerName,
                NoOfOrders = p.Orders.Count()
            }).ToList();

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }

            =============================================================================

            var result = ListGenerators.ProductList
                         .GroupBy(p => p.Category)
                         .Select(g => new
                         {
                             Category = g.Key,
                             ProductsCount = g.Count()
                         });

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            ===============================================================================

            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }
            ;

            int x = Arr.Sum(x => x);

            Console.WriteLine(x);

            ===============================================================================

            string[] data = File.ReadAllLines("dictionary_english.txt");

            long res = data.Sum(x => x.Length);

            Console.WriteLine(res);

            ===============================================================================

            var x = ListGenerators.ProductList.GroupBy(x => x.Category).
                Select(x => new
                {
                    category = x.Key,
                    NoOfItemsInStock = x.Count(p => p.UnitsInStock > 0),
                }).ToList();

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }

            ===============================================================================

            string[] words = File.ReadAllLines("dictionary_english.txt");

            int shortestLength = words
                .Min(w => w.Length);

            Console.WriteLine(shortestLength);

            ================================================================================

            decimal xv = ListGenerators.ProductList.Min(x => x.UnitPrice);

            Console.WriteLine(xv);

            ================================================================================

            var result =
            from p in ListGenerators.ProductList
            group p by p.Category into g
            let minPrice = g.Min(p => p.UnitPrice)
            from p in g
            where p.UnitPrice == minPrice
            select new
            {
                Category = g.Key,
                ProductName = p.ProductName,
                Price = p.UnitPrice
            };

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            ================================================================================

            string[] words = File.ReadAllLines("dictionary_english.txt");

            int shortestLength = words
                .Max(w => w.Length);

            Console.WriteLine(shortestLength);

            ================================================================================

            decimal xv = ListGenerators.ProductList.Max(x => x.UnitPrice);

            Console.WriteLine(xv);

            ================================================================================

            var result =
            from p in ListGenerators.ProductList
            group p by p.Category into g
            let minPrice = g.Max(p => p.UnitPrice)
            from p in g
            where p.UnitPrice == minPrice
            select new
            {
                Category = g.Key,
                ProductName = p.ProductName,
                Price = p.UnitPrice
            };

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            ===============================================================

            string[] words = File.ReadAllLines("dictionary_english.txt");

            double x = words.Average(x => x.Length);

            Console.WriteLine(x);

            ====================================================================

            var x = ListGenerators.ProductList.GroupBy(x => x.Category).Select(x => new
            {
                cat = x.Key,
                avg = x.Average(p => p.UnitPrice)
            });

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }

            =====================================================================

            var x = ListGenerators.ProductList.OrderBy(p => p.ProductName).ToList();

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }

            ====================================================================

            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" }
            ;

            Array.Sort(Arr, new CaseInsensitiveComparer());

            foreach (var item in Arr)
            {
                Console.WriteLine(item);
            }

            ===================================================================

            var x = ListGenerators.ProductList.OrderByDescending(p => p.UnitsInStock).ToList();

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }

            ===================================================================

            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }
            ;

            var x = Arr.OrderBy(p => p.Length).ThenBy(p => p).ToList();

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }

            ==================================================================

            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" }
            ;

            var result = words
                .OrderBy(x => x.Length)
                .ThenBy(x => x, StringComparer.OrdinalIgnoreCase)
                .ToArray();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            ==================================================================

            var x = ListGenerators.ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice).ToList();

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }

            =====================================================================

            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" }
            ;

            var x = Arr.OrderBy(p => p.Length).ThenBy(p => p, StringComparer.OrdinalIgnoreCase).ToArray();

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }

            =====================================================================

            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }
            ;

            var x = Arr.Reverse().Where(p => p[1] == 'i');

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }

            =======================================================================

            var x = ListGenerators.CustomerList
            .Where(c => c.City == "Washington")
            .SelectMany(c => c.Orders)
            .Take(3).ToList();

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }

            =====================================================================

            var x = ListGenerators.CustomerList
            .Where(c => c.City == "Washington")
            .SelectMany(c => c.Orders)
            .Skip(3).ToList();

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }

            =====================================================================

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }
            ;

            var x = numbers.TakeWhile((p, y) => p >= y).ToArray();

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }

            =====================================================================

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }
            ;

            var x = numbers.SkipWhile(p => p % 3 != 0);

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }

            ==========================================================================

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }
            ;

            var x = numbers.SkipWhile((z, y) => z >= y);

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }

            =======================================================================

            var x = ListGenerators.ProductList.Select(P => P.ProductName).ToList();

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }

            ============================================================================

            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" }
            ;

            var x = words.Select(w => new
            {
                Upper = w.ToUpper(),
                Lower = w.ToLower()
            });

            foreach (var item in x)
            {
                Console.WriteLine($"Upper: {item.Upper}, Lower: {item.Lower}");
            }

            ==============================================================================

            var x = ListGenerators.ProductList.Select(p => new
            {
                name = p.ProductName,
                price = p.UnitPrice
            }).ToList();

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }

            =============================================================================

            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }
            ;

            var x = Arr.Select((z, y) => z == y).ToList();

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }

            ================================================================================

            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 }
            ;
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var result = numbersA
                .SelectMany(a => numbersB
                    .Where(b => a < b)
                    .Select(b => $"{a} is less than {b}")
                );

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            ==============================================================================

            var x = ListGenerators.CustomerList.SelectMany(p => p.Orders).Where(p => p.Total > 5000).ToList();

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }

            ================================================================================

            var x = ListGenerators.CustomerList.SelectMany(p => p.Orders).Where(p => p.OrderDate.Year >= 1998);

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }

            =================================================================================

            string[] words = File.ReadAllLines("dictionary_english.txt");

            var x = words.Contains("ei");

            Console.WriteLine(x);

            =================================================================================

            var result = ListGenerators.ProductList.GroupBy(p => p.Category)
                .Where(g => g.Any(p => p.UnitsInStock == 0)).Select(g => new
                {
                    Category = g.Key,
                    Products = g.ToList()
                });

            foreach (var item in result)
            {
                Console.WriteLine($"Category: {item.Category}");

                foreach (var p in item.Products)
                {
                    Console.WriteLine($"   Product: {p.ProductName} - Stock: {p.UnitsInStock}");
                }

                Console.WriteLine("-------------------");
            }

            ================================================================================

            var result = ListGenerators.ProductList.GroupBy(p => p.Category)
                .Where(g => g.All(p => p.UnitsInStock != 0)).Select(g => new
                {
                    Category = g.Key,
                    Products = g.ToList()
                });

            foreach (var item in result)
            {
                Console.WriteLine($"Category: {item.Category}");

                foreach (var p in item.Products)
                {
                    Console.WriteLine($"   Product: {p.ProductName} - Stock: {p.UnitsInStock}");
                }

                Console.WriteLine("-------------------");
            }

            ==================================================================================

            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }
            ;

            var x = nums
                .GroupBy(n => n % 5)
                .OrderBy(g => g.Key);

            foreach (var group in x)
            {
                Console.WriteLine($"Numbers with a remainder of {group.Key} when divided by 5:");

                foreach (var item in group.OrderBy(n => n))
                {
                    Console.WriteLine(item);
                }
            }

            ====================================================================================

            string[] words = File.ReadAllLines("dictionary_english.txt");

            var x = words.GroupBy(p => p[0]);

            foreach (var item in x)
            {
                Console.WriteLine(item.Key);

                foreach (var item1 in item)
                {
                    Console.WriteLine(item1);
                }

                Console.WriteLine("======================");
            }

            ===================================================================================

            string[] Arr = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " }
            ;

            var result = Arr.GroupBy(w => w, new AnagramComparer());

            foreach (var group in result)
            {
                Console.WriteLine("...");

                foreach (var word in group)
                {
                    Console.WriteLine(word);
                }

            }

        }

        class AnagramComparer : IEqualityComparer<string>
        {
            private string Normalize(string word)
            {
                return string.Concat(
                    word.Trim().ToLower().OrderBy(c => c)
                );
            }

            public bool Equals(string x, string y)
            {
                return Normalize(x) == Normalize(y);
            }

            public int GetHashCode(string obj)
            {
                return Normalize(obj).GetHashCode();
            }
        }

        class CaseInsensitiveComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}






XDocument doc = XDocument.Load("customers.xml");

var customers = doc.Root.Elements("customer");

List<Customer> cst = new List<Customer>();

foreach (var item in customers)
{
    Customer c = new Customer
    {
        CustomerID = (string)item.Element("id"),
        CompanyName = (string)item.Element("name"),
        Address = (string)item.Element("address"),
        City = (string)item.Element("city"),
        Country = (string)item.Element("country"),
        Phone = (string)item.Element("phone"),
        Fax = (string)item.Element("fax"),
        Orders = item.Element("orders")
         .Elements("order")
         .Select(o => new Order
         {
             OrderID = (int)o.Element("id"),
             OrderDate = (DateTime)o.Element("orderdate"),
             Total = (decimal)o.Element("total")
         })
         .ToArray()
    };


    cst.Add(c);
}

var outOfStockProducts = ListGenerators.ProductList
                                       .Where(p => p.UnitsInStock == 0)
                                       .ToList();

foreach (var p in outOfStockProducts)
{
    Console.WriteLine(p.ProductName);
}