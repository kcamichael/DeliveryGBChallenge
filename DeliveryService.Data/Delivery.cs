using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// POCOs
public class Delivery
{
    public Delivery()
    {
        OrderStatus = OrderStatus.Scheduled;
    }
    public Delivery(DateTime orderDate, DateTime deliveryDate, int itemNumber, int itemQuantity, int customerID)
    {
        OrderDate = orderDate;
        DeliveryDate = deliveryDate;
        ItemNumber = itemNumber;
        ItemQuantity = itemQuantity;
        CustomerID = customerID;
        OrderStatus = OrderStatus.Scheduled;
    }
    public int DeliveryID { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public OrderStatus OrderStatus { get; set; }          
    public int ItemNumber { get; set; }
    public int ItemQuantity { get; set; }
    public int CustomerID { get; set; }

    public override string ToString()
    {
        string str = $"OrderDate: {OrderDate}\n" +
                    $"Delivery Date: {DeliveryDate}\n" +
                    $"Order Status: {OrderStatus}\n" +
                    $"Item Number: {ItemNumber}\n" +
                    $"Item Quantity: {ItemQuantity}\n" +
                    $"Customer Account Number: {CustomerID}\n" +
                    "=============================\n";
        return str;
    }
    // Delivery delivery = new Delivery
    // {
    //     OrderDate = DateOnly.
    //     DeliveryDate = DateTime.Now.AddDays(5), //...Maybe?
    //     OrderStatus = DeliveryStatus.Scheduled,
    //     ItemNumber = 123,
    //     ItemQuantity = 2,
    //     CustomerID = 0001
    // // };
    // Console.WriteLineNewStruct(.ToString());

}
