using StudentsAPI.Models;
using StudentsAPI.Queries;
using StudentsAPI.Repositories;
using MediatR;

namespace StudentsAPI.Handlers
{
    public class GetStudentListHandler :  IRequestHandler<GetStudentListQuery, List<StudentDetails>>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentListHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentDetails>> Handle(GetStudentListQuery query, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetStudentListAsync();
        }
    }
}
