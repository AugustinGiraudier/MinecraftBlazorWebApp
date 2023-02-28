namespace TPBlazorApp.Models
{
    public class Item : IEquatable<Item>
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public int StackSize { get; set; }
        public int MaxDurability { get; set; }
        public List<string> EnchantCategories { get; set; }
        public List<string> RepairWith { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string ImageBase64 { get; set; }

        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            if(obj.GetType() != typeof(Item)) return false;
            Item other = (Item)obj;
            return Equals(other);
        }

        public bool Equals(Item? other)
        {
            if(ReferenceEquals(null, other)) return false;
            if(ReferenceEquals(this, other)) return true;
            if(Name != other.Name) return false;
            return true;
        }
    }
}
