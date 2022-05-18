namespace Domain.Entities;
public class Item
{
  public Item(string name, decimal value)
  {
    Name = name;
    Value = value;
    Id = Guid.NewGuid();
  }
  public Guid Id { get; private set; }
  public string Name { get; private set; }
  public decimal Value { get; private set; }
  public DateTime Created { get; private set; }
  public virtual Order? Order { get; private set; }

}
