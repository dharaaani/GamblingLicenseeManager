// Models/Licensee.cs
public class Licensee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<int> LicensedProductIds { get; set; } = new List<int>();
}
