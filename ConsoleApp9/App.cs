using System;
using System.Collections.Generic;

namespace ConsoleApp9
{
    internal class App
    {
        internal void Run()
        {
            var options = new List<string> { "Option 1", "Option 2", "Option 3", "Option 4" };
            var i = ArrowKeyOptionMenu("Choose an option:", options);

            if (i != null)
                Console.WriteLine($"Selected item {i}, value {options[(int)i]}");
            else
                Console.WriteLine("Bye...");
        }

        private int? ArrowKeyOptionMenu(string header, List<string> options)
        {
            var fg = Console.ForegroundColor;
            var bg = Console.BackgroundColor;

            void Highlight()
            {
                Console.ForegroundColor = bg;
                Console.BackgroundColor = fg;
            }

            void ResetHighlight()
            {
                Console.ForegroundColor = fg;
                Console.BackgroundColor = bg;
            }

            int selector = 0;
            int count = options.Count;


            do
            {
                Console.Clear();
                Console.WriteLine(header);

                for (int i = 0; i < count; ++i)
                {
                    if (i == selector) Highlight();

                    Console.WriteLine($"  {options[i]}");

                    ResetHighlight();
                }

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        selector++;
                        selector %= count;
                        break;
                    case ConsoleKey.UpArrow:
                        selector--;
                        selector = (selector + count) % count;
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.Enter:
                        return selector;
                    case ConsoleKey.Q:
                        return null;
                }
            } while (true);
        }
    }
}