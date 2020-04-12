using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto_final.Models;

namespace proyecto_final.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ComentarioController: ControllerBase
    {
                [HttpGet("{id_com?}")]
                [ProducesResponseType(StatusCodes.Status201Created)]
                [ProducesResponseType(StatusCodes.Status400BadRequest)]
                public IActionResult VerComentarios(int? id_com)
                {
                    using(var context = new blogContext()){
                        if(id_com == null)
                            {
                                var comentarios = context.Comentarios.ToList();
                                return Ok(comentarios); 
                            }
                        else
                            {
                                var comentario = context.Comentarios.Single(x => x.id_com == -id_com);
                                return Ok(comentario);
                            }

                    }
                    
                }

                [HttpPost]
                [ProducesResponseType(StatusCodes.Status201Created)]
                [ProducesResponseType(StatusCodes.Status400BadRequest)]
                public IActionResult NuevoComentario(Comentarios c)
                {   
                    using(var context = new blogContext())
                    {
                        var nuevoComentario = new Comentarios()
                        {   //No es necesario poner el id, porque es incrementable
                            //id_com = c.id_com,                                                     
                            t_com       = c.t_com,
                            comentario  = c.comentario,
                            id_usuarios = c.id_usuarios
                        };
                        context.Comentarios.Add(nuevoComentario);
                        context.SaveChanges();
                        return Ok();
                    }
                }

                [HttpPut("{id}")]
                [ProducesResponseType(StatusCodes.Status201Created)]
                [ProducesResponseType(StatusCodes.Status400BadRequest)]
                public IActionResult ActualizarComentario(Comentarios c,int id)
                {
                        using(var context = new blogContext())
                        {
                            var cActualizar = context.Comentarios.Single(x=>x.id_com==c.id_com);
                            
                            cActualizar.t_com     = c.t_com;
                            cActualizar.comentario = c.comentario;                            

                            context.Update(cActualizar);
                            context.SaveChanges();
                            return Ok();
                        }
                }

                [HttpDelete("{id_com}")]
                [ProducesResponseType(StatusCodes.Status201Created)]
                [ProducesResponseType(StatusCodes.Status400BadRequest)]

                public IActionResult EliminarComentario(int id_com)
                {
                    using(var context = new blogContext())
                    {
                      
                        var comentario = context.Comentarios.Single(x=>x.id_com==id_com);
                        context.Comentarios.Remove(comentario);
                        context.SaveChanges();
                        return Ok();
                    }
                }
    }
}