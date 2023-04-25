using Microsoft.AspNetCore.Mvc;
using dot7.API.Data.Entities;
[ApiController]
[Route("[controller]")]

public class Studentcontroller
{
    private readonly userRepository _userRepository;

    public Studentcontroller(userRepository userRepository )
    {
        _userRepository =userRepository;
    }
    [HttpGet]
    public async Task<IEnumerable<Students>> GetAllAsync()
    {
        return await _userRepository.getAllAsync();
    }
    [HttpGet("{id}")]
    public async Task<Students> GetByIDAsync (Guid id)
    {
        return await _userRepository.GetByIDAsync(id);
    }
    // delete by reference id
    [HttpDelete("{id}")]
    public async Task<Students> RemoveAsync(Guid id)
    {
        return await _userRepository. RemoveAsync(id);
    }
    //update
    [HttpPut("{id}")]
    public async Task<Students> UpdateAsync (Students student)
    {
        return await _userRepository.UpdateAsync(student);
    }
    //insert data
    [HttpPost]
    public async Task<Students> InsertAsync(Students student)
    {
        return await _userRepository.InsertAsync(student);
    }
//file upload
//    [HttpPost ("{id}")]
//    public Task UploadFile(IFormFile fileInput)
//    {
//      var  file = 
//    }

    }




// using dot7.API.Crud.Data;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using dot7.API.Data.Entities;

 
// namespace dot7.API.Controllers;
 
// [ApiController]
// [Route("[controller]")]
// public class StudentsController: ControllerBase
// {
//     private readonly MyWorldDbContext _myWorldDbContext;
//     public StudentsController(MyWorldDbContext myWorldDbContext)
//     {
//         _myWorldDbContext = myWorldDbContext;
//     }
    
//     [HttpGet]
// public async Task<IActionResult> GetAsync()
// {
// 	var students = await _myWorldDbContext.Students.ToListAsync();
// 	return Ok(students);
// }

// [HttpGet]
// [Route("get-student-by-id")]
// //add
// public async Task<IActionResult>GetActionResultAsync(int id)
// {
//     var student =await _myWorldDbContext.Students.FindAsync(id);
//     return Ok(student);
// }
// [HttpPost]
// public async Task<IActionResult> PostAsync(Students student)
// {
// 	_myWorldDbContext.Students.Add(student);
// 	await _myWorldDbContext.SaveChangesAsync();
// 	return Created($"/get-student-by-id?id={student.ID}", student);
// }
// //update
// [HttpPut]
// public async Task<IActionResult>PutAsync(Students studentupdate)
// {
//     _myWorldDbContext.Students.Update(studentupdate);
//     await _myWorldDbContext.SaveChangesAsync();
//     return NoContent();
// }

// //delete
// [Route("{id}")]
// [HttpDelete]
// public async Task<IActionResult>DeleteAsync(int id){
//     var studentToDelete =await_myWorldDbContext.Students.FindAsync(id);
//     if (studentToDelete==null)
//     {
//         return NotFound();
//     }
//     _myWorldDbContext.Students.Remove()
// }

 
