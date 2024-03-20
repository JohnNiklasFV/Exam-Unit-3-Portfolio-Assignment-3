namespace FunctionsAreAPopping;

    public class Task1
    {
        //functions-----------------------------------------------
        double Square(double num)
        {
            return num * num;
        }
        double InchesToMM(double num)
        {
            return num * 25.4;
        }
        double SquareRoot(double num)
        {
            return Math.Sqrt(num);
        }
        double Cube(double num)
        {
            return num * num * num;
        }
        double Area(double num)
        {
            return 3.14 * num * num;
        }
        string Greeting(string name)
        {
            return $"Greetings, {name}!";
        }
        //actual code/test being runned----------------------------
        public void Execute()
        {
           Tests(25,Square(5), "square of 5");
           Tests(254,InchesToMM(10), "10 inches into milimeter");
           Tests(4,SquareRoot(16), "square root of 16");
           Tests(27,Cube(3), "cube of 3");
           Tests(314,Area(10), "area of a circle given the radius of 10");
           StringTest("Greetings, Tony!", Greeting("Tony"), "Greetings: ");


        }
        //Tester---------------------------------------------------
        public void Tests(double expected, double given, string result = "Tests")
        {
            if (expected == given)
            {
                Console.WriteLine($"🟢 Test Worked! {result} expected:{expected}, received:{given}");
            }
            else
            {
                Console.WriteLine($"🔴 Test Failed! {result} expected:{expected}, received:{given}");
            }
        }   

        public void StringTest(string expected, string given, string result = "Tests")
        {
            if (expected == given)
            {
                Console.WriteLine($"🟢 Test Worked! {result} expected:{expected}, received:{given}");
            }
            else
            {
                Console.WriteLine($"🔴 Test Failed! {result} expected:{expected}, received:{given}");
            }
        }   

    }



