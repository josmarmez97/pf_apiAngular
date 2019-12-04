using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto_final.Models;

namespace proyecto_final.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsuariosController: ControllerBase
    {
                [HttpGet("{a?}")]
                [ProducesResponseType(StatusCodes.Status201Created)]
                [ProducesResponseType(StatusCodes.Status400BadRequest)]
                public IActionResult VerUsuarios(int? a)
                {
                    using(var context = new blogContext()){
                        if(a == null)
                            {
                                var usuarios = context.Usuarios.ToList();
                                return Ok(usuarios); 
                            }
                        else
                            {
                                var usuario = context.Usuarios.Single(x => x.id_usuario == a);
                                return Ok(usuario);
                            }

                    }
                    
                }

                [HttpPost]
                [ProducesResponseType(StatusCodes.Status201Created)]
                [ProducesResponseType(StatusCodes.Status400BadRequest)]
                public IActionResult NuevoUsuario(Usuarios u)
                {
                    using(var context = new blogContext())
                    {
                        var nuevoUsuario = new Usuarios()
                        {   //No es necesario poner el id, porque es incrementable
                            //id_usuario=u.id_usuario,                                                     
                            userid=u.userid,
                            pass=u.pass,
                            id_rol=u.id_rol
                        };
                        context.Usuarios.Add(nuevoUsuario);
                        context.SaveChanges();
                        return Ok();
                    }
                }

                [HttpPut]
                [ProducesResponseType(StatusCodes.Status201Created)]
                [ProducesResponseType(StatusCodes.Status400BadRequest)]
                public IActionResult ActualizarUsuario(Usuarios u)
                {
                        using(var context = new blogContext())
                        {
                            var uActualizar = context.Usuarios.Single(x=>x.id_usuario==u.id_usuario);
                            
                            uActualizar.id_usuario=u.id_usuario;
                            uActualizar.userid = u.userid;
                            uActualizar.pass = u.pass;
                            uActualizar.id_rol=u.id_rol;

                            context.Update(uActualizar);
                            context.SaveChanges();
                            return Ok();
                        }
                }

                [HttpDelete("{id_usuario}")]
                [ProducesResponseType(StatusCodes.Status201Created)]
                [ProducesResponseType(StatusCodes.Status400BadRequest)]

                public IActionResult EliminarUsuario(int id_usuario)
                {
                    using(var context = new blogContext())
                    {
                      //  var eliminarU = new Usuarios(){id_usuario = id_u};
                        var usuarios = context.Usuarios.Single(x=>x.id_usuario==id_usuario);
                        context.Usuarios.Remove(usuarios);
                        context.SaveChanges();
                        return Ok();
                    }
                }
    }
}