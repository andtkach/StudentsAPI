using StudentsAPI.Models;
using MediatR;

namespace StudentsAPI.Queries
{
    public class GetStudentByIdQuery : IRequest<StudentDetails>
    {
        public int Id { get; set; }
    }
}
