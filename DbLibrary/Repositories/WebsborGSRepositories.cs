using DbLibrary.Context;
using DbLibrary.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbContext = DbLibrary.Context.DbContext;

namespace DbLibrary.Repositories
{
    public class WebsborGSRepositories
    {
        public WebsborGS GetById(int id)
        {
            using (var dbcontext = new DbContext())
            {
                return dbcontext.WebsborGS.FirstOrDefault(w => w.Id.Equals(id));
            }
        }
        public List<WebsborGS> GetByOkpo(string okpo)
        {
            using (var dbcontext = new DbContext())
            {
                return dbcontext.WebsborGS.Where(w => w.OkpoGS.Equals(okpo)).ToList();
            }
        }

        public List<WebsborGS> GetByOkpoUl(string okpoUl)
        {
            using (var dbcontext = new DbContext())
            {
                return dbcontext.WebsborGS.Where(w => w.OkpoUlGS.Equals(okpoUl)).ToList();
            }
        }
        public async Task<List<WebsborGS>> GetByName(string name)
        {
            using (var dbcontext = new DbContext())
            {
                return await dbcontext.WebsborGS.Where(w => w.NameGS.Equals(name)).ToListAsync();
            }
        }

        public List<WebsborGS> GetByShortName(string shortName)
        {
            using (var dbcontext = new DbContext())
            {
                return dbcontext.WebsborGS.Where(w => w.ShortNameGS.Equals(shortName)).ToList();
            }
        }

        public List<WebsborGS> GetAll()
        {
            using (var dbcontext = new DbContext())
            {
                return dbcontext.WebsborGS.ToList();
            }
        }

        public async Task<int> Add(WebsborGS websborGS)
        {
            using (var dbcontext = new DbContext())
            {
                dbcontext.WebsborGS.Add(websborGS);
                return await dbcontext.SaveChangesAsync();
            }
        }

        public void AddFromList(List<WebsborGS> dataWebsborGS)
        {
            using (var dbcontext = new DbContext())
            {
                dbcontext.WebsborGS.AddRange(dataWebsborGS);
                dbcontext.SaveChanges();
            }
        }
        public async Task<int> Delete(WebsborGS websborGS)
        {
            using (var dbcontext = new DbContext())
            {
                dbcontext.WebsborGS.Remove(websborGS);
                return await dbcontext.SaveChangesAsync();
            }
        }

        public async Task<int> Update(WebsborGS websborGS)
        {
            using (var dbcontext = new DbContext())
            {
                dbcontext.WebsborGS.Update(websborGS);
                return await dbcontext.SaveChangesAsync();
            }
        }
    }
}
