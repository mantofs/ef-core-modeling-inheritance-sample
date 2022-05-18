namespace Domain.Entities;

public class Order
{
  private List<Item> items;
  public Order(Guid customerId)
  {
    CustomerId = customerId;
    Id = Guid.NewGuid();
    items = new();
  }
  public Guid Id { get; private set; }
  public Guid CustomerId { get; private set; }
  public DateTime Created { get; private set; }
  public virtual IReadOnlyCollection<Item> Items => items;
  public virtual Customer? Customer { get; private set; }
  public void AddItem(Item item)
  {
    items.Add(item);
  }
}