namespace OrganizerLive.ScreenElements
{
    using System;
    using System.Collections.Generic;

    public class Paragraph : ScreenElement
    {
        private List<string> content;

        public Paragraph(int x, int y, List<string> content) 
            : base(x, y)
        {
            this.content = content;
        }

        public override void Print()
        {
            for (int row = 0; row < this.content.Count; row++)
            {
                Console.SetCursorPosition(this.x, this.y + row);
                Console.Write(this.content[row]);
            }
        }
    }
}
