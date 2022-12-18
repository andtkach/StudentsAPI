using StudentsAPI.Models;

namespace StudentsAPI.Services.Cache
{
    public interface IStudentCache
    {
        Task<StudentDetails> GetStudentByIdAsync(int id);
        Task<bool> SetStudent(int id, StudentDetails student);
    }
}
