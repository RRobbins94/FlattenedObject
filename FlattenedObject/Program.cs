using System;

namespace FlattenedObject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var obj1 = new
            {
                CompanyName = "Zoopla",
                CompanyAddress =
                new
                {
                    Number = 123,
                    Street = "buxton street",
                    Town = "London",
                    PostCode = "NW11 7FD"
                },
                Employees =
                new[]{
                    new{
                        Name = "Adam", Surname = "Bobbins", Age = 55
                    },
                    new{
                        Name = "Susan", Surname = "Moore", Age = 30
                    }
                }
            };

            var flatObj1 = FlattenObject.Flattern(obj1);


            foreach(var prop in flatObj1)
            {
                Console.WriteLine("Property Name: " + prop.Item1);
                Console.WriteLine("Property Value: " + prop.Item2);
            }



            var obj2 = new
            {
                CompanyName = "RightMove",
                CompanyAddress =
                new
                {
                    Number = 123,
                    Street = "bleh street",
                    Town = "London",
                    PostCode = "NW11 7FD"
                },
                Employees =
                new[]{
                    new{
                        Name = "Carl", Surname = "Evens", Age = 55
                    },
                    new{
                        Name = "Lisa", Surname = "Jenkins", Age = 30
                    }
                }
            };
            var flatObj2 = FlattenObject.Flattern(obj2);


            foreach (var prop in flatObj2)
            {
                Console.WriteLine("Property Name: " + prop.Item1);
                Console.WriteLine("Property Value: " + prop.Item2);
            }


        }



    }
}
