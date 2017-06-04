namespace TeamBuilder.Data
{
    using System;

    public static class Utility
    {
        public static void InitDB()
        {
            var context = new TeamBuilderContext();
            context.Database.Initialize(true);
        }
    }
}
