using GradeBook.Enums;
using GradeBook.GradeBooks;
using System;

namespace GradeBook
{
    class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Standard;
        }
    }
}
