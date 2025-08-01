using System.Collections.Generic;
using System.Text;

public class Order
{
  private List<Product> _products = new List<Product>();
  private Customer _customer;

  public Order(Customer customer)
  {
    _customer = customer;
  }

  public void AddProduct(Product product)
  {
    _products.Add(product);
  }

  public decimal GetTotalCost()
  {
    decimal total = 0;
    foreach (var product in _products)
    {
      total += product.GetTotalCost();
    }

    total += _customer.LivesInUSA() ? 5 : 35;
    return total;
  }

  public string GetPackingLabel()
  {
    StringBuilder sb = new StringBuilder();
    foreach (var product in _products)
    {
      sb.AppendLine(product.GetPackingLabel());
    }
    return sb.ToString();
  }

  public string GetShippingLabel()
  {
    return $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
  }
}