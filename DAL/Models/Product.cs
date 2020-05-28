namespace DAL
{
    /// <summary>
    /// Модель товара
    /// </summary>
    public partial class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string Info { get; set; }
    }
}
