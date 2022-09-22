using AutoMapper;
using System;

namespace AuthServer.Service.DtoMapper
{
    public static class ObjectMapper
    {
        //bu Lazy sınfı biz çagırdıgımızda gelecek belleği yükten kurtarmak için yapıyoruz.
        //Lazy Loading, geç çalışıyor.
        //()=> parametre almayan demektir.
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoMapper>();
            });
            return config.CreateMapper();
        });
        //public static IMapper Mapper => lazy.Value; 
        //ikiside aynı aslınad
        // public static IMapper Mapper { get; set; } = lazy.Value;

        public static IMapper Mapper => lazy.Value;
    }
}
