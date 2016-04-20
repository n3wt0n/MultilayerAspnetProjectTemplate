using System.Collections.Generic;
using System.Web.Mvc;
using $safeprojectname$.Entities;
using System;

namespace $safeprojectname$
{
    public interface IExamplesBL : IDisposable
    {
        int AddExample(Example example);
        void DeleteExample(int id);
        void DeleteExamplePhysical(int id);
        Example GetExample(int id);
        List<Example> GetExamples();
        IEnumerable<SelectListItem> GetExamplesSelectList();
        void UpdateExample(Example example);
    }
}