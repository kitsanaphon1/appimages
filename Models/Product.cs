namespace WebAppProject.Models
{
    public class Product
    {
        public int Id { get; set; }

        // ✅ วิธีที่ 1: ใช้ required (ถ้าใช้ C# 11 ขึ้นไป)
        public required string Name { get; set; }

        // ✅ หรือ วิธีที่ 2: ทำให้ nullable (ถ้าใช้ C# 10 หรือต่ำกว่า)
        // public string? Name { get; set; }

        public decimal Price { get; set; }
    }
}
