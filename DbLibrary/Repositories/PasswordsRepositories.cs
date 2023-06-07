using DbLibrary.Context;
using DbLibrary.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbContext = DbLibrary.Context.DbContext;

namespace DbLibrary.Repositories
{
    public class PasswordsRepositories
    {
        private static string sqlStoredProcedure = "sp_Insert_Passwords @name @okpo @password @date_create @comment";
        public async Task<List<Passwords>> GetAll()
        {
            using (var dbContext = new DbContext())
            {
                return await dbContext.Passwords.ToListAsync();
            }
        }

        public Passwords GetById(int id)
        {
            using (var dbContext = new DbContext())
            {
                return dbContext.Passwords.FirstOrDefault(p => p.Id.Equals(id));
            }
        }

        public List<Passwords> GetByName(string name)
        {
            using (var dbContext = new DbContext())
            {
                return dbContext.Passwords.Where(p => p.Name.Equals(name)).ToList();
            }
        }
        public List<Passwords> GetByOkpo(string okpo)
        {
            using (var dbContext = new DbContext())
            {
                return dbContext.Passwords.Where(p => p.Name.Equals(okpo)).ToList();
            }
        }

        public async Task<int> AddAsync(Passwords dataRespondent)
        {
            using (var dbContext = new DbContext())
            {
                dbContext.Passwords.Add(dataRespondent);
                return await dbContext.SaveChangesAsync();
            }
        }

        public async Task<int> Update(Passwords dataRespondentUpdate)
        {
            using (var dbContext = new DbContext())
            {
                dbContext.Passwords.Update(dataRespondentUpdate);
                return await dbContext.SaveChangesAsync();
            }
        }

        public async Task<int> Delete(Passwords dataRespondentDelete)
        {
            using (var dbContext = new DbContext())
            {
                dbContext.Passwords.Remove(dataRespondentDelete);
                return await dbContext.SaveChangesAsync();
            }
        }

        public void AddStoredProcedure(List<Passwords> dataLoadRespondents)
        {
            var sqlParameters = new List<SqlParameter>();

            foreach (var data in dataLoadRespondents)
            {
                sqlParameters.Add(new SqlParameter
                {
                    ParameterName = "@name",
                    Value = data.Name
                });

                sqlParameters.Add(new SqlParameter
                {
                    ParameterName = "@okpo",
                    Value = data.Okpo
                });

                sqlParameters.Add(new SqlParameter
                {
                    ParameterName = "@password",
                    Value = data.Password
                });

                sqlParameters.Add(new SqlParameter
                {
                    ParameterName = "@password",
                    Value = data.Password
                });

                sqlParameters.Add(new SqlParameter
                {
                    ParameterName = "@date_create",
                    Value = data.DateCreate
                });

                sqlParameters.Add(new SqlParameter
                {
                    ParameterName = "@comment",
                    Value = data.Comment
                });
            }

            using (var dbContext = new DbContext())
            {
                dbContext.Passwords.FromSqlRaw(sqlStoredProcedure, sqlParameters);
            }
        }
    }
}
