namespace Comic.Backend.Model
{
    public class Hero
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Publisher { get; set; }
        public string FirstAppearance { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Image { get; set; } = "";
        public string ImageHero { get; set; } = "";
    }

}
