namespace Hitek.Loxone.MHM.Shared.Models
{
    public class LL
        {
            public string control { get; set; }
            public string value { get; set; }
            public string Code { get; set; }
        }

        public class LoxoneResponse
        {
            public LL LL { get; set; }
        }
}
