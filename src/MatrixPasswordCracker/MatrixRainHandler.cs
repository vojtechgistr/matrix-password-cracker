namespace MatrixRain
{
    class MatrixRainHandler
    {
        Random rand = new Random();
        public int Width { get; set; }
        public int Height { get; set; }
        public int[] Y { get; set; }

        public MatrixRainHandler()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WindowLeft = Console.WindowTop = 0;
            Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;
            Console.CursorVisible = false;

            int width, height;
            int[] y;

            Initialize(out width, out height, out y);
            Width = width;
            Height = height;
            Y = y;
        }



        public void UpdateAllColumns(int width, int height, int[] y, string character)
        {
            int x;
            for (x = 0; x < width; ++x)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(x, y[x]);
                Console.Write(character);
                
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                int temp = y[x] - 2;
                Console.SetCursorPosition(x, inScreenYPosition(temp, height));
                Console.Write(character);

                int temp1 = y[x] - 20;
                Console.SetCursorPosition(x, inScreenYPosition(temp1, height));
                Console.Write(' ');

                y[x] = inScreenYPosition(y[x] + 1, height);
            }
        }

        public int inScreenYPosition(int yPosition, int height)
        {
            if (yPosition < 0)
                return yPosition + height;
            else if (yPosition < height)
                return yPosition;
            else
                return 0;
        }

        private void Initialize(out int width, out int height, out int[] y)
        {
            height = Console.WindowHeight;
            width = Console.WindowWidth - 1;
            y = new int[width];
            Console.Clear();

            for (int x = 0; x < width; ++x)
            {
                y[x] = rand.Next(height);
            }
        }
    }
}