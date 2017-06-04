namespace AutoMapperInheritance
{
    using AutoMapper;
    using Models;

    class Startup
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Order, OrderDto>()
                .Include<OnlineOrder, OnlineOrderDto>()
                .Include<MailOrder, MailOrderDto>();
                cfg.CreateMap<OnlineOrder, OnlineOrderDto>();
                cfg.CreateMap<MailOrder, MailOrderDto>();
            });

            OnlineOrder order = new OnlineOrder
            {
                TrackingInfo = "wfq8734ikdqwd",
                BrowserVersion = "Mozzila"
            };

            OnlineOrderDto dto = Mapper.Map<OnlineOrderDto>(order);
        }
    }
}
