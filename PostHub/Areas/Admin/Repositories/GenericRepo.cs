using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using PostHub.Data;
using System.Linq.Expressions;

namespace PostHub.Areas.Admin.Repositories
{
    public abstract class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected readonly PostHubDbContext _context;
        public GenericRepo(PostHubDbContext context)
        {
            _context = context;
        }
        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges ? _context.Set<T>() : _context.Set<T>().AsNoTracking();
        }
        public IQueryable<T> PageLinkAsync(int page, int pageSize, bool trackChanges)
        {
            return FindAll(trackChanges)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }
        public IQueryable<T> FindById(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges ? _context.Set<T>().Where(expression) : _context.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public async Task<int> Count()
        {
            return await _context.Set<T>().AsNoTracking().CountAsync();
        }
    }
}
