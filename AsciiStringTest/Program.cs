namespace AsciiStringTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            AsciiString asc= new AsciiString('B', 'a', 'N','G');
            AsciiString upperAscii= asc.ToUpper1();
            Console.WriteLine("upper"+ upperAscii.ToString());
        }
    }
}