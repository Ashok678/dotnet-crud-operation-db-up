using System;
using System.Data;
using Dapper;
using dot7.API.Data.Entities;

public class userRepository
{
    private readonly IDbConnection _dbConnection;

    public userRepository(IDbConnection dbConnection)
    {
        _dbConnection =dbConnection;
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true; //match data of pascel case

    }
    public async Task<IEnumerable<Students>> getAllAsync()
    {
        string query = "select * from\"Students\"";
        IEnumerable<Students> students= await _dbConnection.QueryAsync<Students>(query);
        return students;
    }
    public async Task<Students> GetByIDAsync(Guid id)
    {
        string query ="SELECT id,first_name,last_name,age,gender from \"Students\" where id=@ID";
        Students student = await _dbConnection.QueryFirstOrDefaultAsync<Students>(query, new{ID =id});
        return student;
    }

    public async Task<Students> InsertAsync (Students student)
    {
        //   Console.WriteLine("Hit");
        string query = "INSERT INTO \"Students\" (id,first_name,last_name,age,gender) VALUES(@ID,@FirstName,@LastName,@Age,@Gender)";
        // Console.WriteLine(student.ToString());
        var result =  await _dbConnection.ExecuteAsync(query,student);
        //   Console.WriteLine(query);
        //     Console.WriteLine(result);
        return student;
    }

    //delete data from table using reference as id

    public async Task<Students> RemoveAsync (Guid id)
    {
        string query = "DELETE FROM \"Students\" where id=@ID";
        Students student = await _dbConnection.QueryFirstOrDefaultAsync<Students> (query, new{ID =id} );
        return student;

    }
    // update data from table using reference as id
    public async Task<Students> UpdateAsync (Students student)
    {
        string query ="UPDATE \"Students\"  SET  first_name = @FirstName, last_name = @LastName, age = @Age, gender = @Gender where id=@ID";
        await _dbConnection.ExecuteAsync (query, student);
         return student;
    }

    




}