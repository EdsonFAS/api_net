using ApiTarefasNet80.DTOs;
using ApiTarefasNet80.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefasNet80.Controllers
{ 
    [Route("categoria")]
        [ApiController]
    public class CategoriaController : Controller
    {
       
        
            [HttpGet]
            public IActionResult Get()
            {
                try
                {
                    List<Categoria> listaTarefas = new CategoriaDAO().List();

                    return Ok(listaTarefas);
                }
                catch (Exception)
                {
                    return Problem($"Ocorreram erros ao processar a solicitação");
                }
            }

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                try
                {
                    var tarefa = new CategoriaDAO().GetById(id);

                    if (tarefa == null)
                    {
                        return NotFound();
                    }

                    return Ok(tarefa);
                }
                catch (Exception)
                {
                    return Problem("Ocorreram erros ao processar a solicitação");
                }
            }

            [HttpPost]
            public IActionResult Post([FromBody] CategoriaDTO item)
            {
                var categoria = new Categoria();

                categoria.Nome = item.Nome;


                try
                {
                    var dao = new CategoriaDAO();
                    categoria.Id = dao.Insert(categoria);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }


                return Created("", categoria);
            }

            [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody] TarefaDTO item)
            {
                try
                {
                    var categoria = new CategoriaDAO().GetById(id);

                    if (categoria == null)
                    {
                        return NotFound();
                    }

                    categoria.Nome = item.Descricao;

                    new CategoriaDAO().Update(categoria);

                    return Ok(categoria);
                }
                catch (Exception e)
                {
                    return Problem(e.Message);
                }
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                try
                {
                    var tarefa = new TarefaDAO().GetById(id);

                    if (tarefa == null)
                    {
                        return NotFound();
                    }

                    new TarefaDAO().Delete(tarefa.Id);

                    return Ok();
                }
                catch (Exception e)
                {
                    return Problem(e.Message);
                }
            }
        }
    }

