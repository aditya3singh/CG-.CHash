using System.Collections.Generic;
using System.Linq;
using Domain;
using Exceptions;

namespace Services
{
    public class SupportUtility
    {
\        private readonly SortedDictionary<int, Queue<SupportTicket>> _ticketPool
            = new SortedDictionary<int, Queue<SupportTicket>>();

        public void AddTicket(SupportTicket ticket)
        {
            ticket.Validate();

            if (_ticketPool.Values.Any(q => q.Any(t => t.Id == ticket.Id)))
                throw new CustomBaseException($"Ticket ID {ticket.Id} already exists.");

            if (!_ticketPool.ContainsKey(ticket.SeverityLevel))
                _ticketPool[ticket.SeverityLevel] = new Queue<SupportTicket>();

            _ticketPool[ticket.SeverityLevel].Enqueue(ticket);
        }

        public void EscalateTicket(string ticketId)
        {
            SupportTicket targetTicket = null;
            int currentSeverity = -1;

            foreach (var entry in _ticketPool)
            {
                targetTicket = entry.Value.FirstOrDefault(t => t.Id == ticketId);
                if (targetTicket != null)
                {
                    currentSeverity = entry.Key;
                    break;
                }
            }

            if (targetTicket == null) throw new TicketNotFoundException("Ticket not found.");
            if (currentSeverity <= 1) throw new CustomBaseException("Ticket is already at maximum severity.");

            var updatedQueue = new Queue<SupportTicket>(_ticketPool[currentSeverity].Where(t => t.Id != ticketId));
            _ticketPool[currentSeverity] = updatedQueue;

            if (_ticketPool[currentSeverity].Count == 0) _ticketPool.Remove(currentSeverity);

            targetTicket.SeverityLevel -= 1; 
            AddTicket(targetTicket);
        }

        public IEnumerable<SupportTicket> GetAllTickets()
        {
            return _ticketPool.Values.SelectMany(q => q);
        }
    }
}