using System;
namespace Core.Services
{
    public class ProviderService
    {
        public Provider GetProviderName(string phoneNumber)
        {
           return phoneNumber.Substring(4,2) switch
            {
                "0888800900" => Provider.Mpamba,
                "AirtelMoney" => Provider.AirtelMoney,
                _ => Provider.None
            };
        }

        public IPaymentService ServiceFromProviderFactory(Provider provider, String phone, String message)
        {
            return provider switch
            {
                Provider.Mpamba => new MpambaService(message, phone),
                _ => new MpambaService(message, phone)
            };
        }
    }

    public enum Provider
    {
        Mpamba,
        AirtelMoney,
        None
    }

}