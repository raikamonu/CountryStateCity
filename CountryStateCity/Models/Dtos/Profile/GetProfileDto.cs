namespace CountryStateCity.Models.Dtos.Profile
{
    public class GetProfileDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Id { get; internal set; }
    }
}
