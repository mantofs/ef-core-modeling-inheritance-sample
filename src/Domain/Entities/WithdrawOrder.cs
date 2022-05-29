namespace Domain.Entities;

public class WithdrawOrder : Order
{
    public WithdrawOrder(Guid customerId) : base(customerId)
    {
    }

    public double Earnings { get; set; }
}


