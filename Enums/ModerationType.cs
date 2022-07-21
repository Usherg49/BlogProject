using System.ComponentModel;

namespace BlogProject.Enums
{
    public enum ModerationType
    {
        [Description("Unacceptable political content")]
        Political,
        [Description("Innapropriate language")]
        Language,
        [Description("Reference to drugs")]
        Drugs,
        [Description("Threatning content")]
        Threatning,
        [Description("Hate speech")]
        HateSpeech,
        [Description("Offensive language")]
        Offensive
    }
}
