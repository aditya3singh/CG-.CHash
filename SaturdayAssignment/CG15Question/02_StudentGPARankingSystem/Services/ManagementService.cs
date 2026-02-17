using System.Collections.Generic;
using System.Linq;
using Domain;
using Exceptions;

namespace Services
{
    public class DescendingComparer<T> : IComparer<T> where T : System.IComparable<T>
    {
        public int Compare(T x, T y) => y.CompareTo(x);
    }

    public class StudentUtility
    {
        private readonly SortedDictionary<double, List<Student>> _ranking
            = new SortedDictionary<double, List<Student>>(new DescendingComparer<double>());

        public void AddStudent(Student student)
        {
            student.Validate();

            if (_ranking.Values.Any(list => list.Any(s => s.Id == student.Id)))
                throw new DuplicateStudentException($"Student with ID {student.Id} is already enrolled.");

            if (!_ranking.ContainsKey(student.GPA))
                _ranking[student.GPA] = new List<Student>();

            _ranking[student.GPA].Add(student);
        }

        public void UpdateGPA(string id, double newGPA)
        {
            if (newGPA < 0 || newGPA > 10) throw new InvalidGPAException("Invalid GPA range.");

            Student targetStudent = null;
            double oldGPA = -1;

            foreach (var entry in _ranking)
            {
                targetStudent = entry.Value.FirstOrDefault(s => s.Id == id);
                if (targetStudent != null)
                {
                    oldGPA = entry.Key;
                    break;
                }
            }

            if (targetStudent == null) throw new StudentNotFoundException($"Student {id} not found.");

            _ranking[oldGPA].Remove(targetStudent);
            if (_ranking[oldGPA].Count == 0) _ranking.Remove(oldGPA);

            targetStudent.GPA = newGPA;
            AddStudent(targetStudent);
        }

        public IEnumerable<Student> GetRanking()
        {
            return _ranking.Values.SelectMany(list => list);
        }
    }
}