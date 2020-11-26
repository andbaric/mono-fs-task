namespace Project.MVC.Models.Shared.Navigation
{
    public abstract class Link
    {
        public string ControllerName { get; set; }
        public string ControllerAction { get; set; }
        public string RouteParams { get; set; }
    }
}
