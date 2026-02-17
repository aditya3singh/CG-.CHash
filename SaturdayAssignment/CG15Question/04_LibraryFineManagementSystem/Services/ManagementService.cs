using System.Collections.Generic;
using System.Linq;
using Domain;
using Exceptions;

namespace Services
{
    public class DescendingIntComparer : IComparer<int>
    {
        public int Compare(int x, int y) => y.CompareTo(x);
    }

    public class LibraryUtility
    {
        private readonly SortedDictionary<int, List<Member>> _fineRegistry
            = new SortedDictionary<int, List<Member>>(new DescendingIntComparer());

        public void AddMember(Member member)
        {
            member.Validate();

            if (_fineRegistry.Values.Any(list => list.Any(m => m.Id == member.Id)))
                throw new CustomBaseException("Member already exists.");

            if (!_fineRegistry.ContainsKey(member.FineAmount))
                _fineRegistry[member.FineAmount] = new List<Member>();

            _fineRegistry[member.FineAmount].Add(member);
        }

        public void PayFine(string memberId, int paymentAmount)
        {
            Member member = null;
            int currentFine = -1;

            foreach (var entry in _fineRegistry)
            {
                member = entry.Value.FirstOrDefault(m => m.Id == memberId);
                if (member != null)
                {
                    currentFine = entry.Key;
                    break;
                }
            }

            if (member == null) throw new MemberNotFoundException("Member not found.");
            if (paymentAmount > currentFine) throw new InvalidFineException("Payment exceeds fine amount.");

            _fineRegistry[currentFine].Remove(member);
            if (_fineRegistry[currentFine].Count == 0) _fineRegistry.Remove(currentFine);

            member.FineAmount -= paymentAmount;
            AddMember(member); 
        }

        public IEnumerable<Member> GetMembersSortedByFine()
        {
            return _fineRegistry.Values.SelectMany(list => list);
        }
    }
}