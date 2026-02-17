using System.Collections.Generic;
using System.Linq;
using Domain;
using Exceptions;

namespace Services
{
    public class FlightFareUtility
    {
        private readonly SortedDictionary<int, List<Ticket>> _fareRegistry
            = new SortedDictionary<int, List<Ticket>>();

        public void AddTicket(Ticket ticket)
        {
            ticket.Validate();

            if (_fareRegistry.Values.Any(list => list.Any(t => t.Id == ticket.Id)))
                throw new DuplicateTicketException($"Ticket {ticket.Id} already exists.");

            if (!_fareRegistry.ContainsKey(ticket.Fare))
            {
                _fareRegistry[ticket.Fare] = new List<Ticket>();
            }

            _fareRegistry[ticket.Fare].Add(ticket);
        }

        public void UpdateFare(string ticketId, int newFare)
        {
            Ticket targetTicket = null;
            int oldFare = -1;

            foreach (var entry in _fareRegistry)
            {
                targetTicket = entry.Value.FirstOrDefault(t => t.Id == ticketId);
                if (targetTicket != null)
                {
                    oldFare = entry.Key;
                    break;
                }
            }

            if (targetTicket == null) throw new TicketNotFoundException("Ticket not found.");

            _fareRegistry[oldFare].Remove(targetTicket);
            if (_fareRegistry[oldFare].Count == 0) _fareRegistry.Remove(oldFare);

            targetTicket.Fare = newFare;
            AddTicket(targetTicket);
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return _fareRegistry.Values.SelectMany(list => list);
        }
    }
}