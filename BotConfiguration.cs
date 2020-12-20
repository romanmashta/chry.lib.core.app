using Cherry.Lib.Core.Localization;

namespace Cherry.Lib.Core.App
{
    public class BotConfiguration : LocalConfiguration
    {
        public static string SectionName = "Bot";

        public bool UseRegistration { get; set; } = false;
        public bool NeedApproval { get; set; } = false;
        public string BucketName { get; set; }
        public string MenuMessage { get; set; }
        public bool NoMenu { get; set; }
        public bool ResetOnStart { get; set; }
    }
}