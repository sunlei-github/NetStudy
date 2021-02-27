using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentClassroom_AggregationMicroservice.IServices
{
    public interface IStudentClientService
    {
        void Create();

        string GetList();

        void PollyTimeOut();

        void PollyDown();
    }
}
