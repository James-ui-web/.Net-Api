using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TpdpApi.Models;
using TpdpApi.Api;

namespace TpdpApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestModelsController : ControllerBase
    {
        private readonly TestModelContext _context;
        private readonly string _test;
        private object _results = null;


        InplayApi api = new InplayApi();

        public TestModelsController(TestModelContext context)
        {
            _context = context;
        }

//         // GET: api/TestModels
//         [HttpGet]
//         public IEnumerable<TestModel> GetTestModel()
//         {
//             object results;
//             bool status = api.getSport(1, results);
// 
//             //return await _context.TestItems.ToListAsync();
//         }

        // GET: api/TestModels/5
        [HttpGet("{id}")]
        public object GetTestModel(int id)
        {
            return NotFound();

        }

        // PUT: api/TestModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestModel(long id, TestModel testModel)
        {
            if (id != testModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(testModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

//         // POST: api/TestModels
//         // To protect from overposting attacks, enable the specific properties you want to bind to, for
//         // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//         [HttpPost]
//         public async Task<ActionResult<TestModel>> PostTestModel(TestModel testModel)
//         {
//             _context.TodoItems.Add(testModel);
//             await _context.SaveChangesAsync();
// 
//             return CreatedAtAction("GetTestModel", new { id = testModel.Id }, testModel);
//         }
// 
//         // DELETE: api/TestModels/5
//         [HttpDelete("{id}")]
//         public async Task<ActionResult<TestModel>> DeleteTestModel(long id)
//         {
//             var testModel = await _context.TodoItems.FindAsync(id);
//             if (testModel == null)
//             {
//                 return NotFound();
//             }
// 
//             _context.TodoItems.Remove(testModel);
//             await _context.SaveChangesAsync();
// 
//             return testModel;
//         }
// 
        private bool TestModelExists(long id)
        {
            return _context.TestItems.Any(e => e.Id == id);
        }

    }

}
