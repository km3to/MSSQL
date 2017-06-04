namespace OrganizerLive
{
    using Organizer.Data;
    using ScreenElements;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;


            var element = new Label(5, 3, "Hello, TUI!");

            var element2 = new Label(5, 6, "Sample text.");

            List<string> para = new List<string>();
            para.Add("This is a parahraph.");
            para.Add("Second line.");

            var element3 = new Paragraph(5, 9, para);

            List<ScreenElement> list = new List<ScreenElement>();
            list.Add(element);
            list.Add(element2);
            list.Add(element3);

            var screen = new ScreenElementsCollection(list);
            screen.Print();

            Console.ReadKey(true);
        }
    }
}
