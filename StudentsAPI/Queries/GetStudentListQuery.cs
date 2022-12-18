using StudentsAPI.Models;
using MediatR;

namespace StudentsAPI.Queries
{
    public class GetStudentListQuery :  IRequest<List<StudentDetails>>
    {
    }
}
