namespace CsharpFunda
{
    class Program : Program4
    {
        String name;
        public Program(String name)
        {
            this.name = name;
        }
        public void getName()
        {
            Console.WriteLine("My name is" + this.name);
        }
        public void getData()
        {
            Console.WriteLine("i am inside the method");
        }
        static void Main(string[] args)
        {
            Program p = new Program("Rahul");
            p.getData();
            p.SetData();
            p.getName();

            Console.WriteLine("helloworld");
            int a = 4;
            Console.WriteLine("variable number is " + a);
            String name = "Rahul";
            Console.WriteLine("Name is " + name);
            Console.WriteLine($"Name is {name}");

            var age = 23;
            Console.WriteLine("Age is " + age);

            dynamic height = 13.2;
            Console.WriteLine($"Height is {height}");

            height = "hello";
            Console.WriteLine($"Height is {height}");


        }
    }
}
