using StudentsAPI.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace StudentsAPI.Services.Cache
{
    public class StudentCache : IStudentCache
    {
        private readonly IDistributedCache _cache;

        public StudentCache(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<StudentDetails> GetStudentByIdAsync(int id)
        {
            string recordKey = $"student-{id}";
            return await _cache.GetRecordAsync<StudentDetails>(recordKey);
        }

        public async Task<bool> SetStudent(int id, StudentDetails student)
        {
            string recordKey = $"student-{id}";
            await _cache.SetRecordAsync(recordKey, student);
            return true;
        }
    }
}
