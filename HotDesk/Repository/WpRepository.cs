using System;
using System.Linq;
using System.Linq.Expressions;
using HotDesk.Models;

namespace HotDesk.Repository
{
    // TODO: use repo to control file access
    // Avoid concurrent issue

    public class WpRepository : IRepository<WpModel>
    {
        protected IQueryable<WpModel> DataSet;

        public WpRepository()
        {
            var ids = Helpers.FileHelper.GetAppData();
            DataSet = ids.Select(id => new WpModel { Id = id }).AsQueryable();
        }

        #region IRepository<T> Members

        public void Insert(WpModel entity)
        {
            Helpers.FileHelper.UpdateAppData(entity.Id, true);
        }

        public void Delete(WpModel entity)
        {
            Helpers.FileHelper.UpdateAppData(entity.Id, false);
        }

        public IQueryable<WpModel> SearchFor(Expression<Func<WpModel, bool>> predicate)
        {
            return DataSet.Where(predicate);
        }

        IQueryable<WpModel> IRepository<WpModel>.GetAll()
        {
            return DataSet;
        }

        WpModel IRepository<WpModel>.GetById(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        public IQueryable<int> GetWpListByLevel(int level)
        {
            return DataSet.Where(p => p.Id / 1000 == level).Select(p => p.Id % 1000).OrderBy(num => num);
        }

        public void SetWpAvailability(int id, bool available)
        {
            Helpers.FileHelper.UpdateAppData(id, available);
        }
    }

}