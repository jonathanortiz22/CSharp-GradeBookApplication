using GradeBook.Enums;
using GradeBook.GradeBooks;
using System;

namespace GradeBook
{
    class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook(string name, bool IsWeighted) : base(name, IsWeighted)
        {
            Type = GradeBookType.Standard;
        }
    }
}
