namespace AngularDotnetCore.Dto
{
    public class PostSearchCriteriaDto
    {
        public int? FromPostId { get; set; }
        public string TitleContain { get; set; }
        public int CityId { get; set; }
        public int CategoryId { get; set; }

    }
}
