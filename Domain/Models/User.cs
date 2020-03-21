namespace FullStack_Project_IE_2.Domain.Models
{
    public class User
    {
        public int Id { get; set;}
        public string Name { get; set;}
        public ERole role { set; get;}

        public EClass ST { set; get;}
        public EClass LA { set; get; }

        public int PointsST { set; get; }
        public int PointsLA { set; get; }

        public Couple Couple { set; get; }

    }
}
