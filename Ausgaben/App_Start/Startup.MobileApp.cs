namespace Ausgaben
{
    using System.Configuration;
    using System.Web.Http;

    using Ausgaben.Data;

    using Microsoft.Azure.Mobile.Server;
    using Microsoft.Azure.Mobile.Server.Authentication;
    using Microsoft.Azure.Mobile.Server.Config;

    using Owin;

    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            new MobileAppConfiguration().UseDefaultConfiguration().ApplyTo(config);

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                app.UseAppServiceAuthentication(
                    new AppServiceAuthenticationOptions
                        {
                            // This middleware is intended to be used locally for debugging. By default, HostName will
                            // only have a value when running in an App Service application.
                            SigningKey = ConfigurationManager.AppSettings["SigningKey"], 
                            ValidAudiences =
                                new[]
                                    {
                                        ConfigurationManager.AppSettings["ValidAudience"]
                                    }, 
                            ValidIssuers =
                                new[]
                                    {
                                       ConfigurationManager.AppSettings["ValidIssuer"] 
                                    }, 
                            TokenHandler = config.GetAppServiceTokenHandler()
                        });
            }

#if !DEBUG
            config.Filters.Add(new HttpsAttribute());
            config.Filters.Add(new AuthorizeAttribute());
#endif

            app.UseWebApi(config);

            AutoMapper.Mapper.Initialize(
                configuration =>
                    {
                        configuration.CreateMap<Account, AccountEntity>()
                            .ForMember(
                                accountEntity => accountEntity.Id, 
                                map => map.MapFrom(account => account.Id.ToString()));
                        configuration.CreateMap<AccountEntity, Account>()
                            .ForMember(
                                account => account.Id, 
                                map => map.MapFrom(accountEntity => Mappers.ToGuid(accountEntity.Id)));
                        configuration.CreateMap<Payment, PaymentEntity>()
                            .ForMember(
                                paymentEntity => paymentEntity.Id, 
                                map => map.MapFrom(payment => payment.Id.ToString()));
                        configuration.CreateMap<PaymentEntity, Payment>()
                            .ForMember(
                                payment => payment.Id, 
                                map => map.MapFrom(paymentEntity => Mappers.ToGuid(paymentEntity.Id)));
                    });
        }
    }
}