using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Repository
{

    public class DeliveryRepository
    {
        public DeliveryRepository()
        {
            Seed();
        }
        private List<Delivery> _deliveryDb = new List<Delivery>();
        private int _count = 0;

        //C.R.U.D

        //Create
        public bool AddDelivery(Delivery delivery)
        {
            if (delivery is null)
            {
                return false;
            }
            else
            {
                _count++;
                delivery.DeliveryID = _count;
                _deliveryDb.Add(delivery);
                return true;
            }
        }

        //Read All
        public List<Delivery> GetDeliveries()
        {
            return _deliveryDb;
        }

        //Read by ID
        public Delivery GetDeliveryByID(int DeliveryID)
        {
            foreach (Delivery delivery in _deliveryDb)
            {
                if (delivery.DeliveryID == DeliveryID)
                {
                    return delivery;
                }
            }
            return null!;
        }
        // List all en route deliveries 
        public List<Delivery> GetAllEnrouteDeliveries()
        {
            return _deliveryDb.Where(d => d.OrderStatus == OrderStatus.EnRoute).ToList();
        }
        // List all completed deliveries (Read)
        public List<Delivery> GetAllCompleteDeliveries()
        {
            return _deliveryDb.Where(d => d.OrderStatus == OrderStatus.Complete).ToList();
        }
        //Update
        public bool UpdateDeliveryData(int deliveryId, Delivery newDeliveryDataFromUI)
        {
            // helper method:            
            Delivery oldDeliveryData = GetDeliveryByID(deliveryId);

            if (oldDeliveryData != null)
            {
                oldDeliveryData.DeliveryID = newDeliveryDataFromUI.DeliveryID;
                oldDeliveryData.OrderDate = newDeliveryDataFromUI.OrderDate;
                oldDeliveryData.DeliveryDate = newDeliveryDataFromUI.DeliveryDate;
                oldDeliveryData.OrderStatus = newDeliveryDataFromUI.OrderStatus;
                oldDeliveryData.ItemNumber = newDeliveryDataFromUI.ItemNumber;
                oldDeliveryData.ItemQuantity = newDeliveryDataFromUI.ItemQuantity;
                oldDeliveryData.CustomerID = newDeliveryDataFromUI.CustomerID;
                return true;
            }
            return false;
        }

        //Delete
        public bool RemoveDelivery(int deliveryId)
        {
            return _deliveryDb.Remove(GetDeliveryByID(deliveryId));
        }

        public void Seed()
        {
            var delOne = new Delivery(new DateTime(2023, 5, 20), new DateTime(2023, 5, 20).AddDays(7), 001, 5, 1);
            var delTwo = new Delivery(new DateTime(2023, 7, 20), new DateTime(2023, 5, 20).AddDays(7), 001, 5, 1);
            var delThree = new Delivery(new DateTime(2023, 8, 20), new DateTime(2023, 5, 20).AddDays(7), 001, 5, 1);
            delThree.OrderStatus = OrderStatus.EnRoute;
            var delFour = new Delivery(new DateTime(2023, 9, 20), new DateTime(2023, 5, 20).AddDays(7), 001, 5, 1);
            delFour.OrderStatus = OrderStatus.Complete;
            var delFive = new Delivery(new DateTime(2023, 10, 20), new DateTime(2023, 5, 20).AddDays(7), 001, 5, 1);
            delFive.OrderStatus = OrderStatus.Complete;
            AddDelivery(delOne);
            AddDelivery(delTwo);
            AddDelivery(delThree);
            AddDelivery(delFour);
            AddDelivery(delFive);
        }
    }

}