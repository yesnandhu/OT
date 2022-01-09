using OT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OT.Services
{
    public interface IQuestions
    {
        List<questionsModel> getQuestions(string myDb1ConnectionString);

    }
}
