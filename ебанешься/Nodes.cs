namespace ебанешься
{
    public class User   
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Post { get; set; }
        public string Tel { get; set; }
        public string Age { get; set; }
        public string Experience { get; set; }
        public string Department {  get; set; }
    }
    public class Otdel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Money { get; set; }
        public string Tel { get; set; }

    }
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int needed_experience { get; set; }
    }

    public class Zadacha
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Deadline { get; set; }
        public int Value { get; set; }
    }
    public class Education
    {
        public int Id { get; set; }
        public string Degree { get; set; }
        public string Institution { get; set; }
    }
    
}