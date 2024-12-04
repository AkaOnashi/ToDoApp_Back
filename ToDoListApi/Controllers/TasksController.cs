using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoListApi.Contracts;
using ToDoListApi.Data;
using ToDoListApi.Models;

namespace ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        // GET: api/<TasksController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasks()
        {
            var tasks = await _taskRepository.GetAllAsync();

            var records = _mapper.Map<List<TaskDto>>(tasks);
            return Ok(records);
        }

        // GET: api/<TasksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetTask(int id)
        {
            var task = await _taskRepository.GetAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            var record = _mapper.Map<TaskDto>(task);
            return Ok(record);
        }

        // POST: api/<TasksController>
        [HttpPost]
        public async Task<ActionResult<Data.Task>> CreateTask([FromBody] TaskDto taskDto)
        {
            var task = _mapper.Map<Data.Task>(taskDto);

            await _taskRepository.AddAsync(task);

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Data.Task>> UpdateTask(int id, [FromBody] TaskDto taskDto)
        {
            if (id != taskDto.Id)
            {
                return BadRequest();
            }

            var task = await _taskRepository.GetAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            _mapper.Map(taskDto, task);

            try
            {
                await _taskRepository.UpdateAsync(task);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TaskExists(id))
                {
                    return NotFound(id);
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // GET: api/<TasksController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Data.Task>> DeleteTask(int id)
        {
            await _taskRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> TaskExists(int id)
        {
            return await _taskRepository.Exists(id);
        }
    }
}
