using System.Data;
using Microsoft.Data.SqlClient;
using LpuApplicationForm.Models;

namespace LpuApplicationForm.Repository
{
    public class StudentRepository
    {
        private readonly string _connectionString;
        public StudentRepository(IConfiguration configuration) 
        { 
            _connectionString = configuration.GetConnectionString("LpuDbConn") 
                ?? throw new InvalidOperationException("Connection string 'LpuDbConn' not found.");
        }

        public bool CheckDuplicate(string email, string mobile, int? id = null)
        {
            using SqlConnection con = new SqlConnection(_connectionString);
            string sql = "SELECT COUNT(*) FROM LpuStudents WHERE (Email=@e OR Mobile=@m)";
            if (id.HasValue) sql += " AND StudentId != @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@e", email);
            cmd.Parameters.AddWithValue("@m", mobile);
            if (id.HasValue) cmd.Parameters.AddWithValue("@id", id.Value);
            con.Open();
            return (int)cmd.ExecuteScalar() > 0;
        }

        public bool AddStudent(StudentModel s)
        {
            using SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("InsertStudent", con) { CommandType = CommandType.StoredProcedure };
            MapParams(cmd, s);
            con.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool UpdateStudent(StudentModel s)
        {
            using SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("UpdateStudent", con) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@StudentId", s.StudentId);
            MapParams(cmd, s);
            con.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        private void MapParams(SqlCommand cmd, StudentModel s)
        {
            cmd.Parameters.AddWithValue("@FullName", s.FullName);
            cmd.Parameters.AddWithValue("@Email", s.Email);
            cmd.Parameters.AddWithValue("@Mobile", s.Mobile);
            cmd.Parameters.AddWithValue("@Gender", s.Gender);
            cmd.Parameters.AddWithValue("@DOB", s.DOB);
            cmd.Parameters.AddWithValue("@Address", s.Address);
            cmd.Parameters.AddWithValue("@City", s.City);
            cmd.Parameters.AddWithValue("@State", s.State);
            cmd.Parameters.AddWithValue("@Pincode", s.Pincode);
            cmd.Parameters.AddWithValue("@HighSchoolMarks", s.HighSchoolMarks);
            cmd.Parameters.AddWithValue("@IntermediateMarks", s.IntermediateMarks);
            cmd.Parameters.AddWithValue("@CourseApplied", s.CourseApplied);
            cmd.Parameters.AddWithValue("@ProfileImage", (object?)s.ProfileImage ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ImageExtension", (object?)s.ImageExtension ?? DBNull.Value);
        }

        public List<StudentModel> GetAllStudent()
        {
            var list = new List<StudentModel>();
            using SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM LpuStudents", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(new StudentModel
                {
                    StudentId = (int)rdr["StudentId"],
                    FullName = rdr["FullName"].ToString()!,
                    Email = rdr["Email"].ToString()!,
                    Mobile = rdr["Mobile"].ToString()!,
                    CourseApplied = rdr["CourseApplied"].ToString()!,
                    ProfileImage = rdr["ProfileImage"] == DBNull.Value ? null : (byte[])rdr["ProfileImage"],
                    ImageExtension = rdr["ImageExtension"] == DBNull.Value ? null : rdr["ImageExtension"].ToString()
                });
            }
            return list;
        }

        public StudentModel? GetStudentById(int id)
        {
            using SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM LpuStudents WHERE StudentId=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (!rdr.Read()) return null;
            return new StudentModel
            {
                StudentId = (int)rdr["StudentId"],
                FullName = rdr["FullName"].ToString()!,
                Email = rdr["Email"].ToString()!,
                Mobile = rdr["Mobile"].ToString()!,
                Gender = rdr["Gender"].ToString()!,
                DOB = (DateTime)rdr["DOB"],
                Address = rdr["Address"].ToString()!,
                City = rdr["City"].ToString()!,
                State = rdr["State"].ToString()!,
                Pincode = rdr["Pincode"].ToString()!,
                HighSchoolMarks = (decimal)rdr["HighSchoolMarks"],
                IntermediateMarks = (decimal)rdr["IntermediateMarks"],
                CourseApplied = rdr["CourseApplied"].ToString()!,
                ProfileImage = rdr["ProfileImage"] == DBNull.Value ? null : (byte[])rdr["ProfileImage"],
                ImageExtension = rdr["ImageExtension"] == DBNull.Value ? null : rdr["ImageExtension"].ToString()
            };
        }

        public bool DeleteStudent(int id)
        {
            using SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("DELETE FROM LpuStudents WHERE StudentId=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}