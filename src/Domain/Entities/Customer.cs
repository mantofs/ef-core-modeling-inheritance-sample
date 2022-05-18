namespace Domain.Entities;
public class Customer
{
  public Customer(string name)
  {
    Name = name;
    Id = Guid.NewGuid();
  }
  public Guid Id { get; private set; }
  public string Name { get; private set; }
  public DateTime Created { get; private set; }

  public virtual ICollection<Order>? Orders { get; private set; }

}
