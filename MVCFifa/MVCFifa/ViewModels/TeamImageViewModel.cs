namespace MVCFifa.ViewModels
{
    public class TeamImageViewModel
    {
        public int Id { get; set; }
        public string? ImageLink { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
