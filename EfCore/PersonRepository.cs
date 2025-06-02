namespace VG.EfCore
{
    using Dapper;
    using System.Data;
    using VG.Domain.Entities.Person;
    using VG.EfCore.Interfaces;

    public class PersonRepository : IPersonRepository
    {
        private readonly IDbConnection _db;

        public PersonRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<List<Person>> GetAllAsync()
        {
            var sql = "SELECT * FROM People";
            var people = await _db.QueryAsync<Person>(sql);
            return people.ToList();
        }

        public async Task<Person?> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM People WHERE Id = @Id";
            return await _db.QuerySingleOrDefaultAsync<Person>(sql, new { Id = id });
        }

        public async Task AddAsync(Person person)
        {
            var sql = @"INSERT INTO People (FirstName, LastName, ...) 
                    VALUES (@FirstName, @LastName, ...)";
            await _db.ExecuteAsync(sql, person);
        }

        public async Task UpdateAsync(Person person)
        {
            var sql = @"UPDATE People SET FirstName = @FirstName, LastName = @LastName, ...
                    WHERE Id = @Id";
            await _db.ExecuteAsync(sql, person);
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM People WHERE Id = @Id";
            await _db.ExecuteAsync(sql, new { Id = id });
        }
    }
}
