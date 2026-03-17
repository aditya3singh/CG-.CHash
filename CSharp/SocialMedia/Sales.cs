using System;
using System.Collections.Generic;

class Sale
{
    // public List<Customers> customer_data;
    public List<Products> Product_data;
    class Customers
    {
        public int customer_id;
        public string first_name;
        public string last_name;
        public string phone;
        public string email;
        public string street;
        public string city;
        public string state;
        public string zip_code;

        public void addCustomer()

        {
            Console.WriteLine("Enter Customer ID: ");
            while (true)
            {
                int c_id = Convert.ToInt32(Console.ReadLine());

                if (c_id > 0)
                {
                    customer_id = c_id;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid ID greater than 0:");
                }
            }

            Console.WriteLine("Enter Customer First Name: ");
            while (true)
            {
                if (!string.IsNullOrWhiteSpace(first_name))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("First Name cannot be empty. Please enter a valid name:");
                    first_name = Console.ReadLine();
                }
            }


            Console.WriteLine("Enter Customer Last Name: ");
            while (true)
            {
                if (!string.IsNullOrWhiteSpace(last_name))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Last Name cannot be empty. Please enter a valid name:");
                    last_name = Console.ReadLine();
                }
            }
            Console.WriteLine("Enter Customer Phone Number: ");
            while (true)
            {
                string phoneNumber = Convert.ToInt32(Console.ReadLine());
                if (phoneNumber.Length == 10)
                {
                    phone = phoneNumber;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid phone number greater than 0:");
                }
            }

            Console.WriteLine("Enter Customer Email Id: ");

            while (true)
            {
                if (!string.IsNullOrWhiteSpace(email) && email.Contains("@\\^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$\""))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid email address:");
                    email = Console.ReadLine();
                }
            }
            Console.WriteLine("Enter Customer Street: ");
            while (true)
            {
                if (!string.IsNullOrWhiteSpace(street))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Street cannot be empty. Please enter a valid street:");
                    street = Console.ReadLine();
                }
            }
            Console.WriteLine("Enter Customer City: ");
            while (true)
            {
                if (!string.IsNullOrWhiteSpace(city))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("City cannot be empty. Please enter a valid city:");
                    city = Console.ReadLine();
                }
            }
            Console.WriteLine("Enter Customer State: ");
            while (true)
            {
                if (!string.IsNullOrWhiteSpace(state))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("State cannot be empty. Please enter a valid state:");
                    state = Console.ReadLine();
                }
            }
            Console.WriteLine("Enter Customer Zip Code: ");
            while (true)
            {
                if (!string.IsNullOrWhiteSpace(zip_code))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Zip Code cannot be empty. Please enter a valid zip code:");
                    zip_code = Console.ReadLine();
                }
            }

        }
    }

    class Staffs
    {
        public int staff_id;
        public string first_name;
        public string last_name;
        public int phone;
        public string email;
        public bool active;
        public int store_id;
        public int manage_id;
    }

    class Orders
    {
        public string Orders_id;
        public string customer_id;
        public string order_status;
        public DateTime order_date;
        public DateTime required_date;
        public DateTime shipped_date;
        public string store_id;
        public int staff_id;
    }

    class Stores
    {
        public int store_id;
        public string store_name;
        public int phone;
        public string email;
        public string street;
        public string city;
        public string state;
        public string zip_code;
    }

    class Order_Item
    {
        public int Orders_id;
        public int item_id;
        public int product_id;
        public int quantity;
        public List<double> list_price;
        public double discount;
    }

    public class Products
    {
        public int product_id;
        public string product_name;
        public string brand_id;
        public string category_id;
        public string model_year;

        public void staff_addProduct()
        {
            while (true)
            {
                Console.WriteLine("Enter Product id: ");
                product_id = Convert.ToInt32(Console.ReadLine());
                if (product_id > 0)
                {

                }

            }
        }


    }


}