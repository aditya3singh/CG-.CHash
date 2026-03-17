using System;
using System.Collections.Generic;

namespace RealEstateManagement
{
    public class RealEstateListing
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Location { get; set; }
    }

    public class RealEstateApp
    {
        private List<RealEstateListing> listings = new List<RealEstateListing>();

        public void AddListing(RealEstateListing listing)
        {
            listings.Add(listing);
        }

        public void RemoveListing(int id)
        {
            RealEstateListing listing = listings.Find(l => l.Id == id);
            if (listing != null)
            {
                listings.Remove(listing);
            }
        }

        public void UpdateListing(RealEstateListing updatedListing)
        {
            RealEstateListing listing = listings.Find(l => l.Id == updatedListing.Id);
            if (listing != null)
            {
                listing.Title = updatedListing.Title;
                listing.Description = updatedListing.Description;
                listing.Price = updatedListing.Price;
                listing.Location = updatedListing.Location;
            }
        }

        public List<RealEstateListing> GetListings()
        {
            return listings;
        }

        public List<RealEstateListing> GetListingsByLocation(string location)
        {
            return listings.FindAll(l => l.Location == location);
        }

        public List<RealEstateListing> GetListingsByPriceRange(int minPrice, int maxPrice)
        {
            return listings.FindAll(l => l.Price >= minPrice && l.Price <= maxPrice);
        }
    }

    class Real
    {
        public static void real()
        {
            RealEstateApp app = new RealEstateApp();

            app.AddListing(new RealEstateListing
            {
                Id = 1,
                Title = "Luxury Villa",
                Description = "Sea facing villa",
                Price = 5000000,
                Location = "Goa"
            });

            app.AddListing(new RealEstateListing
            {
                Id = 2,
                Title = "City Apartment",
                Description = "2 BHK flat",
                Price = 1500000,
                Location = "Mumbai"
            });

            app.AddListing(new RealEstateListing
            {
                Id = 3,
                Title = "Farm House",
                Description = "Spacious farm house",
                Price = 3000000,
                Location = "Goa"
            });

            app.UpdateListing(new RealEstateListing
            {
                Id = 2,
                Title = "City Apartment",
                Description = "3 BHK flat",
                Price = 1800000,
                Location = "Mumbai"
            });

            app.RemoveListing(1);

            Console.WriteLine("All Listings:");
            foreach (var l in app.GetListings())
            {
                Console.WriteLine($"{l.Id} | {l.Title} | {l.Price} | {l.Location}");
            }

            Console.WriteLine("\nListings in Goa:");
            foreach (var l in app.GetListingsByLocation("Goa"))
            {
                Console.WriteLine($"{l.Title} - {l.Price}");
            }

            Console.WriteLine("\nListings between 1,000,000 and 3,000,000:");
            foreach (var l in app.GetListingsByPriceRange(1000000, 3000000))
            {
                Console.WriteLine($"{l.Title} - {l.Price}");
            }
        }
    }
}