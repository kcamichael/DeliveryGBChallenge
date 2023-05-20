
using DeliveryService.Repository;

public class ProgramUI
{
    //Globally scoped variable container that points to the repo
    private DeliveryRepository _dRepo = new DeliveryRepository();

    public void Run()
    {
        RunApplication();
    }

    private void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            System.Console.WriteLine($"Welcome to Warner Transit Federal\n" +
                "=============Delivery Status============\n" +
                "1. List Enroute Deliveries\n" +
                "2. List Completed Deliveries\n" +
                "============Manage Deliveries===========\n" +
                "3. Add a Delivery\n" +
                "4. Cancel a Delivery\n" +
                "5. Update Delivery Status\n" +
                "==================Exit=================\n" +
                "00. Exit Application\n");

            int userInput = int.Parse(Console.ReadLine()!);

            switch (userInput)
            {
                case 1:
                    ListEnrouteDeliveries();
                    break;
                case 2:
                    ListCompletedDeliveries();
                    break;
                case 3:
                    CreateDelivery();
                    break;
                case 4:
                    DeleteDelivery();
                    break;
                case 5:
                    UpdateDelivery();
                    break;
                case 00:
                    isRunning = ExitApplication();
                    break;
                default:
                    System.Console.WriteLine("Invalid key entry!");
                    PressAnyKey();
                    break;
            }
        }
    }

    private void PressAnyKey()
    {
        System.Console.WriteLine("Press Any Key To Continue.");
        Console.ReadKey();
    }
    private bool ExitApplication()
    {
        Console.Clear();
        System.Console.WriteLine("Thank you!!");
        PressAnyKey();
        Console.Clear();
        return false;
    }

    private void ListEnrouteDeliveries()
    {
        Console.Clear();
        var enRouteDeliveriesInDb = _dRepo.GetAllEnrouteDeliveries();
        if (enRouteDeliveriesInDb.Count > 0)
        {   
            foreach(var d in enRouteDeliveriesInDb)
            {
                System.Console.WriteLine(d);
            }
        }
        else
        {
            System.Console.WriteLine("There are no Enroute Deliveries available!");
        }
        PressAnyKey();
    }

    private void ListCompletedDeliveries()
    {
        throw new NotImplementedException();
    }

    private void DeleteDelivery()
    {
        throw new NotImplementedException();
    }

// Update Delivery
    private void UpdateDelivery()
    {
        Console.Clear();
        try
        {
            System.Console.WriteLine("== Update Delivery ==");

            foreach (var delivery in _dRepo.GetDeliveries())
            {
                System.Console.WriteLine($"{delivery.DeliveryID}");
            }
            System.Console.WriteLine("=============================\n");

            System.Console.WriteLine("Please input a Delivery Id");
            int userInputDeliveryId = int.Parse(Console.ReadLine()!);

            Delivery selectedDelivery = _dRepo.GetDeliveryByID(userInputDeliveryId);

            if (selectedDelivery != null)
            {
                Console.Clear();

                //create an empty form 
                Delivery deliveryForm = new Delivery();

                System.Console.WriteLine("Please enter an Order Date: YYYY/MM/DD");
                deliveryForm.OrderDate = DateTime.Parse(Console.ReadLine()!);

                System.Console.WriteLine("Please enter a Delivery Date: YYYY/MM/DD");
                deliveryForm.DeliveryDate = DateTime.Parse(Console.ReadLine()!);

                System.Console.WriteLine("Please enter an Order Status: \n" +
                                        "0. Scheduled\n" +
                                        "1. EnRoute\n" +
                                        "2. Complete\n" +
                                        "3. Canceled\n");
                int userInput = int.Parse(Console.ReadLine()!);
                OrderStatus status = (OrderStatus)userInput;
                deliveryForm.OrderStatus = status;

                System.Console.WriteLine("Please enter an Item Number:");
                deliveryForm.ItemNumber = int.Parse(Console.ReadLine()!);

                System.Console.WriteLine("Please enter an Item Quantity:");
                deliveryForm.ItemQuantity = int.Parse(Console.ReadLine()!);

                System.Console.WriteLine("Please enter a Customer ID:");
                deliveryForm.CustomerID = int.Parse(Console.ReadLine()!);

                if (_dRepo.UpdateDeliveryData(selectedDelivery.DeliveryID, deliveryForm))
                {
                    System.Console.WriteLine("SUCCESS!");
                }
                else
                {
                    System.Console.WriteLine("FAIL!");
                }
            }
            else
            {
                System.Console.WriteLine($"The Delivery with the id: {userInputDeliveryId} doesn't Exist!");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }

        PressAnyKey();
    }

    // Create Delivery
    private void CreateDelivery()
    {
        Console.Clear();
        try
        {
            System.Console.WriteLine("== Create Delivery ==");

            Console.Clear();

            //create an empty form 
            Delivery deliveryForm = new Delivery();

            System.Console.WriteLine("Please enter an Order Date: YYYY/MM/DD");
            deliveryForm.OrderDate = DateTime.Parse(Console.ReadLine()!);

            System.Console.WriteLine("Please enter a Delivery Date: YYYY/MM/DD");
            deliveryForm.DeliveryDate = DateTime.Parse(Console.ReadLine()!);

            System.Console.WriteLine("Please enter an Item Number:");
            deliveryForm.ItemNumber = int.Parse(Console.ReadLine()!);

            System.Console.WriteLine("Please enter an Item Quantity:");
            deliveryForm.ItemQuantity = int.Parse(Console.ReadLine()!);

            System.Console.WriteLine("Please enter a Customer ID:");
            deliveryForm.CustomerID = int.Parse(Console.ReadLine()!);

            if (_dRepo.AddDelivery(deliveryForm))
            {
                System.Console.WriteLine("SUCCESS!");
            }
            else
            {
                System.Console.WriteLine("FAIL!");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        PressAnyKey();
    }
}
