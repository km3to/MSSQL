namespace OrganizerLive
{
    using ScreenElements;
    using System;
    using System.Collections.Generic;

    public class ScreenElementsCollection
    {
        private List<ScreenElement> content;

        public ScreenElementsCollection(List<ScreenElement> content)
        {
            this.content = content;
        }

        public void Print()
        {
            foreach (var item in this.content)
            {
                item.Print();
            }
        }
    }
}
