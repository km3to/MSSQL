namespace BookCatalog.Data
{
    public static class Init
    {
        public static void InitDb()
        {
            var context = new BookEntites();
            context.Database.Initialize(true);
        }
    }
}
