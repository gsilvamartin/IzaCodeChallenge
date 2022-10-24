using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IzaCodeChallenge.Model;
using IzaCodeChallenge.Model.Database;
using IzaCodeChallenge.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IzaCodeChallenge.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly IProdutoService _produtoService;

        public ClienteController(IClienteService clienteService, IProdutoService produtoService)
        {
            this._clienteService = clienteService;
            this._produtoService = produtoService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                var clientes = _clienteService.GetClientes();

                return Ok(new APIResponse
                {
                    Success = true,
                    Message = "Clientes recuperados com sucesso",
                    Data = clientes
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            try
            {
                var cliente = _clienteService.GetCliente(id);

                return Ok(new APIResponse
                {
                    Success = true,
                    Message = "Cliente recuperado com sucesso",
                    Data = cliente
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("/produtos/{userid}")]
        [Authorize]
        public IActionResult GetProdutos(int userid)
        {
            try
            {
                var cliente = _produtoService.GetProdutosByClienteId(userid);

                return Ok(new APIResponse
                {
                    Success = true,
                    Message = "Produtos recuperados com sucesso",
                    Data = cliente
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            try
            {
                var idCliente = _clienteService.InsertCliente(cliente);

                return Ok(new APIResponse
                {
                    Success = true,
                    Message = "Cliente cadastrado com sucesso",
                    Data = idCliente
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpPut]
        [Authorize]
        public IActionResult Put([FromBody] Cliente cliente)
        {
            try
            {
                _clienteService.UpdateCliente(cliente);

                return Ok(new APIResponse
                {
                    Success = true,
                    Message = "Cliente atualizado com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                _clienteService.DeleteCliente(id);

                return Ok(new APIResponse
                {
                    Success = true,
                    Message = "Clientes deletado com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }
    }
}

