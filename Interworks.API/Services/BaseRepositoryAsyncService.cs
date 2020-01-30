using System;
using System.Linq;
using System.Threading.Tasks;
using Interworks.API.Interfaces;
using Interworks.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Interworks.API.Services {
    public class BaseRepositoryAsyncService<T>  : IRepositoryAsync<T> where T : class, IPrimaryEntity {
        
        protected readonly ApplicationDbContext db;

        protected readonly DbSet<T> dbset;
        
        public BaseRepositoryAsyncService(ApplicationDbContext db, DbSet<T> dbset) {
            this.db = db;
            this.dbset = dbset;
        }
        
        public IQueryable<T> find() {
            return dbset.AsQueryable();
        }
        
        public async Task<T> findAsync(Guid id) {
            var student = await dbset.SingleAsync(a => a.id == id);
            return student;
        }

        public async Task<bool> deleteAsync(Guid id) {
            try {
                
                // this happens on db DELETE FROM students WHERE this.id = id
                dbset.RemoveRange(
                    dbset.Where(a => a.id == id)
                );

                // return true if user is deleted
                // return false if user was not in db already
                return await db.SaveChangesAsync() == 1;
            }
            catch (DbUpdateException inv) {
                throw new Exception("Can not process your delete request", inv);
            }
        }

        public async Task<T> createAsync(T student) {
            student.created_at = DateTimeOffset.Now;
            await dbset.AddAsync(student);
            await db.SaveChangesAsync();
            return student;
        }

        public async Task<T> updateAsync(T student) {
            student.updated_at = DateTimeOffset.Now;
            dbset.Update(student);
            await db.SaveChangesAsync();
            return student;
        }
    }
}