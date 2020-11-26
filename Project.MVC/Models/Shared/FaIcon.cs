namespace Project.MVC.Models.Shared
{
    public class FaIcon
    {
        public FaIcon(string iconClassNameSufix)
        {
            IconClassName = $"{IconClassNamePrefix}{iconClassNameSufix}";
        }

        private string IconClassNamePrefix { get; } = "fas fa-";
        public string IconClassName { get; private set; }

        public static string GetFaIconClassName(string iconClassNameSufix)
        {
            var iconClassName = new FaIcon(iconClassNameSufix).ToString();

            return iconClassName;
        }
    }
}
