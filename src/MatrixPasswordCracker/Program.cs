using MatrixRain;

namespace MatrixPasswordCracker
{
    internal class Program
    {
        static char[] Match =            {'0','c','d','e','f','g','1','2','3','4','5','a','b','h','i','6','7','8','9','j' ,'k','l','m','n','o','p',
                        'q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J','C','L','M','N','O','P',
                        'Q','R','S','T','U','V','X','Y','Z','!','?',' ','*','-','+'};
        
        static string FindPassword;
        static int Combi;
        static string space;
        static int Characters;
        private static MatrixRainHandler _program;

        static void Main(string[] args)
        {
            _program = new MatrixRainHandler();
            Console.Title = "Matrix Password Cracker";
            Console.ForegroundColor = ConsoleColor.White;
            int Count;
            space = " ";

            Console.WriteLine("Enter your Password:");
            FindPassword = Console.ReadLine();
            Characters = FindPassword.Length;

            Console.Clear();

            DateTime today = DateTime.Now;
            today.ToString("yyyy-MM-dd_HH:mm:ss");
            Console.WriteLine(space);
            Console.WriteLine("START:\t{0}", today);

            for (Count = 0; Count <= 15; Count++)
            {
                Recurse(Count, 0, "");
            }
        }

        static void Recurse(int Lenght, int Position, string BaseString)
        {
            for (int Count = 0; Count < Match.Length; Count++)
            {
                Combi++;
                if (Position < Lenght - 1)
                {
                    _program.UpdateAllColumns(_program.Width, _program.Height, _program.Y, BaseString);
                    Recurse(Lenght, Position + 1, BaseString + Match[Count]);
                }
                if (BaseString + Match[Count] == FindPassword)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Your password is: " + FindPassword);
                    Console.WriteLine("Your password is: " + Characters + " character(s) long");
                    Console.ForegroundColor = ConsoleColor.White;
                    DateTime today = DateTime.Now;
                    today.ToString("yyyy-MM-dd_HH:mm:ss");
                    Console.WriteLine(space);
                    Console.WriteLine("END:\t{0}\nCombi:\t{1}", today, Combi);
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
        }
    }
}