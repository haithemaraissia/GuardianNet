using System.IO;

namespace GuardianNet.Extensions
{
    public static class GuardianApiExtensions
    {
        public static string LoadToken(this GuardianApi guardian, string path)
            => return File.ReadAllText(path);
    }
}
