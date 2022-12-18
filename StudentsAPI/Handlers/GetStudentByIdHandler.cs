using StudentsAPI.Models;
using StudentsAPI.Queries;
using StudentsAPI.Repositories;
using MediatR;
using StudentsAPI.Services.Cache;

namespace StudentsAPI.Handlers
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, StudentDetails>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentCache _studentCache;

        public GetStudentByIdHandler(IStudentRepository studentRepository, IStudentCache studentCache)
        {
            _studentRepository = studentRepository;
            _studentCache = studentCache;
        }

        public async Task<StudentDetails> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
        {
            var student = await _studentCache.GetStudentByIdAsync(query.Id);
            if (student != null)
            {
                return student;
            }

            student = await _studentRepository.GetStudentByIdAsync(query.Id);
            await _studentCache.SetStudent(query.Id, student);

            return student;
        }
    }
}
