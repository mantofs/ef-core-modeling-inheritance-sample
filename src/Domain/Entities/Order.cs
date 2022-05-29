namespace Domain.Entities;

public abstract class Order
{

    public Order(Guid customerId)
    {
        CustomerId = customerId;
        Id = Guid.NewGuid();
        Items = new HashSet<Item>();
    }

    public Guid Id { get; private set; }

    public Guid CustomerId { get; private set; }

    public DateTime Created { get; private set; }

    public virtual ICollection<Item> Items { get; private set; }

    public virtual Customer? Customer { get; private set; }

    public void AddItem(Item item)
    {
        Items?.Add(item);
    }

    public void RemoveItem(Item item)
    {
        Items?.Remove(item);
    }
}


