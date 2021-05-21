namespace Course.api.Business.Entities
{
    public class Current
    {
        public int code { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public int codeUser { get; set; }

        public virtual User User { get; set; }
    }
}
