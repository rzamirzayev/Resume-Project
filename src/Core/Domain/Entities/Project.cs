namespace Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ImagePath { get; set; }
        public string? Url { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public ICollection<ProjectCategory> ProjectCategories { get; set; }
    }
}
