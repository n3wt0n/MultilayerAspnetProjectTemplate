using MVCMultiLayer.Business.Entities;
using MVCMultiLayer.Business.Mappers;
using MVCMultiLayer.Interfaces.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMultiLayer.Business
{
    public class ExamplesBL : BaseBL, IExamplesBL
    {
        IRepository<DAL.Entities.Example> repo;

        public ExamplesBL(IRepository<DAL.Entities.Example> repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Get ALL the Examples 
        /// </summary>
        /// <returns></returns>
        public List<Example> GetExamples()
            => repo.GetAll().OrderBy(ct => ct.MyStringProperty).ToList().Map();

        public IEnumerable<SelectListItem> GetExamplesSelectList()
        {
            var examples = new List<SelectListItem>();

            examples.Add(new SelectListItem() { Text = null, Value = null, Selected = true });

            examples.AddRange(GetExamples()
                .Select(example => new SelectListItem()
                {
                    Text = example.MyStringProperty,
                    Value = example.ID.ToString(),
                    Selected = false
                }));

            return examples;
        }

        public Example GetExample(int id)
            => GetExamples().Where(ct => ct.ID == id).SingleOrDefault();

        /// <summary>
        /// Add a new Consignment Type and return the ID
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public int AddExample(Example example)
        {
            example.UserCreation = HttpContext.Current.User.Identity.Name;
            example.DateCreation = DateTime.Now;

            var exampleEF = example.MapInverse();

            repo.Add(exampleEF);
            return exampleEF.ID;
        }

        /// <summary>
        /// Update the edited Consignment Type
        /// </summary>
        /// <param name="customer"></param>
        public void UpdateExample(Example example)
        {
            var exampleEF = repo.GetById(example.ID);

            exampleEF = example.MapInverse(exampleEF);
            MarkAsUpdated(exampleEF);
            repo.Update(exampleEF);
        }

        /// <summary>
        /// Mark as Deleted the customer Category with the given ID from the DB
        /// </summary>
        /// <param name="id"></param>
        public void DeleteExample(int id)
        {
            var entity = repo.GetById(id);

            MarkAsDeleted(entity);
            repo.Update(entity);
        }

        /// <summary>
        /// Physically Delete the customer Category with the given ID from the DB
        /// </summary>
        /// <param name="id"></param>
        public void DeleteExamplePhysical(int id)
            => repo.Delete(id);

        protected override void Dispose(bool all)
        {
            if (repo != null)
                repo = null;

            base.Dispose(all);
        }
    }
}